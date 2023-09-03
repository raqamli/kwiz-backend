namespace Kwiz.Api.Entities;
public class Quiz : IHasTime
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set;}
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime OpeningDateTime { get; set; }
    public DateTime ClosingDateTime { get; set; }
    public EQuizStatus Status { get; set; }
    public bool IsPublic { get; set; }
    public string[] Tags { get; set; }
    public string Code { get; set; }
    public List<QuizQuestion> Questions { get; set; }
    public List<Submission> Submissions { get; set; }
}