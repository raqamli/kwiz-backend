namespace Kwiz.Api.Entities;
public class Submission
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public Guid QuizId { get; set; }
    public DateTime StartedDateTime{ get; set; }
    public DateTime FinishedDateTime { get; set; }
    public List<SubmissionSelection> Selections { get; set; }
    public Quiz Quiz { get; set; }
}