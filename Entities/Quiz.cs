namespace Kwiz.Api.Entities;
public class Quiz
{
    public Guid OwnerId {get;set;}
    public Guid Id { get; set; }
    public string Title {get;set;}
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime OpeningDateTime { get; set; }
    public DateTime ClosingDateTime { get; set; }
    public EQuizStatus Status { get; set; }
    public bool IsPublic { get; set; } 
    public string[] Tags { get; set; }
    public string Code { get; set; }
    public List<QuizQuestion> Questions { get; set; }
}