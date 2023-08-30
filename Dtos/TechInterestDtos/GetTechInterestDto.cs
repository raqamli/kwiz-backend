
using Kwiz.Api.Entities;

namespace Kwiz.Api.Dtos.TechInterestDto;
public class GetTechInterestDto
{
    public GetTechInterestDto(TechInterest entity)
    {
        Interests = entity.Interests;
        CreatedAt = entity.CreatedAt;
        UpdatedAt = entity.UpdatedAt;
    }
    public string[] Interests { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}