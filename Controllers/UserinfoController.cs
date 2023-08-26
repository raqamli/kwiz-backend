using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.Kwiz.Api.Data;
using X.Kwiz.Api.Dtos.TechInterestDto;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserinfoController : ControllerBase
{
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
        
        if(interests is null)
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
        if(userSelectedInterests.Any() is false)
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
}