using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kwiz.Api.Data;
using Kwiz.Api.Dtos.TechInterestDto;
using Kwiz.Api.Entities;
using Microsoft.Extensions.FileProviders;

namespace Kwiz.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserinfoController : ControllerBase
{
    private readonly IFileProvider fileProvider;
    public UserinfoController(IWebHostEnvironment environment)
    {
        this.fileProvider = new PhysicalFileProvider(Path.Combine(environment.ContentRootPath,"StaticFiles"));
    }
    [Authorize]
    [HttpGet("interests")]
    public async Task<IActionResult> GetUserInterests(
        [FromServices] IKwizDbContext dbContext,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);
        var interests = await dbContext.TechInterests
            .FirstOrDefaultAsync(t => t.UserId == userId, cancellationToken);

        if (interests is null)
            return NoContent();

        return Ok(new GetTechInterestDto(interests));
    }

    [Authorize]
    [HttpPost("interests")]
    public async Task<IActionResult> CreateInterest(
        [FromServices] IKwizDbContext dbContext,
        [FromBody] IEnumerable<string> userSelectedInterests,
        CancellationToken cancellationToken = default)
    {
        if (userSelectedInterests.Any() is false)
            return BadRequest("User must select at least one interest.");

        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);
        var interests = await dbContext.TechInterests
            .FirstOrDefaultAsync(t => t.UserId == userId, cancellationToken);

        if (interests is not null)
            return Conflict("User already has tech interests selected.");

        var persistedInterests = dbContext.TechInterests.Add(new TechInterest
        {
            UserId = userId,
            Interests = userSelectedInterests.ToArray()
        });
        await dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetUserInterests), new GetTechInterestDto(persistedInterests.Entity));
    }

    [Authorize]
    [HttpPut("interests")]
    public async Task<IActionResult> UpdateInterest(
        [FromServices] IKwizDbContext dbContext,
        [FromBody] IEnumerable<string> userSelectedInterests,
        CancellationToken cancellationToken = default)
    {
        if (userSelectedInterests.Any() is false)
            return BadRequest("User must select at least one interest.");

        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);
        var interests = await dbContext.TechInterests
            .FirstOrDefaultAsync(t => t.UserId == userId, cancellationToken);

        if (interests is null)
            BadRequest("User has never selected interests before.");
        
        interests.Interests = userSelectedInterests.ToArray();
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new GetTechInterestDto(interests));
    }
    [Authorize]
    [HttpGet("technologies")]
    public IActionResult GetTechnologies()
    {
        var filePath = fileProvider.GetFileInfo("technologies.json");

        if(!filePath.Exists)
          {
            return NotFound("Technologies files not found!");
          }
        try
          {
            using(var stream = filePath.CreateReadStream())
            using(var reader = new StreamReader(stream))
              {
                var jsonContent = reader.ReadToEnd();
                var technologies = Newtonsoft.Json.JsonConvert.DeserializeObject<Technologies>(jsonContent);

                if(technologies is null)
                  {
                    return BadRequest("Invalid Json format in the technologies file");
                  };
                return Ok(technologies);
              }
          }
        catch(Exception ex)
          {
            return StatusCode(500,$"An error occured: {ex.Message}");
          }
    }
}