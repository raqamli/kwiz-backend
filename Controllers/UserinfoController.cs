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
        [FromBody] IEnumerable<Guid> userInterestedTechnologyIds,
        CancellationToken cancellationToken = default)
    {
        if (userInterestedTechnologyIds.Any() is false)
            return BadRequest("User must select at least one interest.");

        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var interests = await dbContext.TechInterests
            .Where(t => t.UserId == userId)
            .Include(t => t.InterestedTechnologies)
            .FirstOrDefaultAsync(cancellationToken);

        if (interests is not null)
            return Conflict("User already has tech interests selected.");

        var interestedTechnologies = await dbContext.Technologies
            .Where(t => userInterestedTechnologyIds.Contains(t.Id))
            .ToListAsync(cancellationToken);

        if(interestedTechnologies.Count() != userInterestedTechnologyIds.Count())
            return BadRequest("One or more selected technologies not found.");

        var persistedInterests = dbContext.TechInterests.Add(new TechInterest
        {
            UserId = userId,
            InterestedTechnologies = interestedTechnologies,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetUserInterests), new GetTechInterestDto(persistedInterests.Entity));
    }

    [Authorize]
    [HttpPut("interests")]
    public async Task<IActionResult> UpdateInterest(
        [FromServices] IKwizDbContext dbContext,
        [FromBody] IEnumerable<Guid> userInterestedTechnologyIds,
        CancellationToken cancellationToken = default)
    {
        if (userInterestedTechnologyIds.Any() is false)
            return BadRequest("User must select at least one interest.");

        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);
        var interests = await dbContext.TechInterests
            .Where(t => t.UserId == userId)
            .Include(t => t.InterestedTechnologies)
            .FirstOrDefaultAsync(cancellationToken);

        if (interests is null)
            return BadRequest("User has never selected interests before.");

        var interestedTechnologies = await dbContext.Technologies
            .Where(t => userInterestedTechnologyIds.Contains(t.Id))
            .ToListAsync(cancellationToken);
        
        if(interestedTechnologies.Count() != userInterestedTechnologyIds.Count())
            return BadRequest("One or more selected technologies not found.");
        
        interests.InterestedTechnologies.AddRange(interestedTechnologies);
        interests.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new GetTechInterestDto(interests));
    }
}