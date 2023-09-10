namespace Kwiz.Api.Entities;
public class TechInterest : IHasTime
{
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Technology> InterestedTechnologies { get; set; } = new List<Technology>();
}