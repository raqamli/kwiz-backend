namespace Kwiz.Api.Entities;
public interface IHasTime
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}