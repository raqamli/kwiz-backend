using System.Text.Json.Serialization;

namespace Kwiz.Api.Entities;
public class Technology
{
    [JsonIgnore]
    public Guid Id { get; set; } = Guid.NewGuid();
    [JsonPropertyName("type")]
    public string Type { get; set; } 
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("tags")]
    public string[] Tags { get; set; }
}