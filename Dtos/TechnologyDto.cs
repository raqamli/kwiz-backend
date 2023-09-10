namespace Kwiz.Api.Dtos;

public class TechnologyDto
{
    public TechnologyDto(Entities.Technology entity)
    {
        Id = entity.Id;
        Type = entity.Type;
        Name = entity.Name;
        Description = entity.Description;
        Tags = entity.Tags;
    }
    public Guid Id { get; set; }
    public string Type { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Tags { get; set; }
}