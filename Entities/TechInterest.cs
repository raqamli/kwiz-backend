namespace X.Kwiz.Api.Entities;
public class TechInterest : IHasTime
{
    public Guid UserId { get; set; }
    public string[] Interests { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}