namespace X.Kwiz.Api.Entities;
public class QuizQuestion
{
    public Guid Id { get; set; }
    public int TimeLimitSeconds { get; set; }
    public string Content { get; set; }
    public List<QuestionOption> Options { get; set; }
    public string[] Tags { get; set; }
    public List<Quiz> Quizzes { get; set; }
    public Guid QuizId { get; set; }
}