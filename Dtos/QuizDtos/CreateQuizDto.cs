namespace Kwiz.Api.Dtos.QuizDtos;
public class CreateQuizDto
{
    public Guid OwnerId { get; set;}
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime OpeningDateTime { get; set; }
    public DateTime ClosingDateTime { get; set; }
    public EQuizStatusDto Status { get; set; }
    public bool IsPublic { get; set; }
    public string[] Tags { get; set; }
    public string Code { get; set; }
}