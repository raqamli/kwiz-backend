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
    public async Task<IActionResult> GetInterest(
        [FromServices] IKwizDbContext dbContext,
        CancellationToken cancellationToken = default)
    {
        var userClaims = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var userId = Guid.Parse(idCliam);
        var interests = await dbContext.TechInterests.FirstOrDefaultAsync(t => t.UserId == userId, 
                                                    cancellationToken);
        if (interests is null)
            return NotFound();

        return Ok(new GetTechInterestDto(interests));
    }
    
    [Authorize]
    [HttpPost("interests")]
    public async Task<IActionResult> CreateInterest(
        [FromServices] IKwizDbContext dbContext,
        [FromBody] CreateTechInterestDto createTechInterest,
        CancellationToken cancellationToken = default)
    {
        var userClaims = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var userId = Guid.Parse(idCliam);
        var interests = await dbContext.TechInterests.FirstOrDefaultAsync(t => t.UserId == userId, 
                                                    cancellationToken);
        
        if (interests is null)
            return BadRequest("User has interests.");

        var interest = dbContext.TechInterests.Add(new TechInterest
        {
            UserId = Guid.Parse(userClaims),
            Interests = createTechInterest.Interests
        });

        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(interest.Entity.UserId);
    }
}