using Kwiz.Api.Data;
using Kwiz.Api.Dtos;
using Kwiz.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TechnologiesController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<TechnologyDto>> GetTechnologies(
        IKwizDbContext dbContext, 
        CancellationToken cancellationToken = default)
        => await dbContext.Technologies.Select(t => new TechnologyDto(t))
            .ToListAsync(cancellationToken);
}