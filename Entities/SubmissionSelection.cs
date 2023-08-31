namespace Kwiz.Api.Entities;
public class SubmissionSelection
{
    public Guid QuestionId { get; set; }
    public Guid Id { get; set; }
    public Guid SubmissionId { get; set; }
    public List<QuestionOption> SelectedOptions { get; set; }
    public bool IsSkipped { get; set; }
    public int TimeSpentOnQuestion { get; set; }
    public Submission Submission { get; set; }
}