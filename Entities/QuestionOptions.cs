namespace Kwiz.Api.Entities;
public class QuestionOption
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
    public bool IsRequired { get; set; }
    public string Explanation { get; set; }
    public Guid QuestionId { get; set; }
    public QuizQuestion Question { get; set; }
    public SubmissionSelection SubmissionSelection { get; set; }
    public Guid SubmissionId { get; set; }
}