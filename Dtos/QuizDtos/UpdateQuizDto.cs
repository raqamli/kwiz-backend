namespace Kwiz.Api.Dtos.QuizDtos;
public class UpdateQuizDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime OpeningDateTime { get; set; }
    public DateTime ClosingDateTime { get; set; }
    public EQuizStatusDto Status { get; set; }
    public bool IsPublic { get; set; }
    public string[] Tags { get; set; }
    public string Code { get; set; }
}