namespace Kwiz.Api.Dtos.QuestionOptionDtos;
public class CreateQuestionOptionDto
{
    public Guid SubmissionId { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
    public bool IsRequired { get; set; }
    public string Explanation { get; set; }
}