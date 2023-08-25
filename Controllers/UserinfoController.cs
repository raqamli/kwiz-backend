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
    private readonly IKwizDbContext dbContext;
    public UserinfoController(
        IKwizDbContext dbContext
    )
    {
        this.dbContext = dbContext;
    }
    [Authorize]
    [HttpGet("interests")]
    public async Task<IActionResult> GetInterest(CancellationToken cancellationToken = default)
    {
        var userClaims = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userClaims))
            return Unauthorized();
        Console.WriteLine(userClaims);
        var interests = await dbContext.TechInterests
                                .FirstOrDefaultAsync(t => t.UserId.ToString() == userClaims, cancellationToken);
        if (interests is null)
            return NotFound();

        return Ok(new GetTechInterestDto(interests));
    }
    [Authorize]
    [HttpPost("interests")]
    public async Task<IActionResult> CreateInterest(
        [FromBody] CreateTechInterestDto createTechInterest,
        CancellationToken cancellationToken = default)
    {
        var userClaims = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userClaims))
            return Unauthorized();

        var interests = await dbContext.TechInterests
                                .FirstOrDefaultAsync(t => t.UserId.ToString() == userClaims, cancellationToken);
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