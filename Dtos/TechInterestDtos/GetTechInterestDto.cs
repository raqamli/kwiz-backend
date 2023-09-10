using Kwiz.Api.Entities;

namespace Kwiz.Api.Dtos.TechInterestDto;
public class GetTechInterestDto
{
    public GetTechInterestDto(TechInterest entity)
    {
        InterestedTechnologies = entity.InterestedTechnologies.Select(t => new TechnologyDto(t)).ToList();
        CreatedAt = entity.CreatedAt;
        UpdatedAt = entity.UpdatedAt;
    }
    public IEnumerable<TechnologyDto> InterestedTechnologies { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}