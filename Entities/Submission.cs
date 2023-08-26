namespace X.Kwiz.Api.Entities;
public class Submission
{
    public int OwnerId { get;set;}
    public int QuizId {get;set;}
    public DateTime StartedDateTime{get;set;}
    public DateTime FinishedDateTime {get;set;}
}