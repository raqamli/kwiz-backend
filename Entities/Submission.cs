namespace Kwiz.Api.Entities;
public class Submission
{
    public Guid OwnerId { get; set; }
    public Guid QuizId { get; set; }
    public Guid Id { get; set; }
    public Guid SubmissionId { get; set; }
    public DateTime StartedDateTime{ get; set; }
    public DateTime FinishedDateTime { get; set; }
    public List<SubmissionSelection> Selections { get; set; }
}