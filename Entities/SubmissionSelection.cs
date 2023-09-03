namespace Kwiz.Api.Entities;
public class SubmissionSelection
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public bool IsSkipped { get; set; }
    public int TimeSpentOnQuestion { get; set; }
    public List<QuestionOption> SelectedOptions { get; set; }
    public QuizQuestion Question { get; set; }
}