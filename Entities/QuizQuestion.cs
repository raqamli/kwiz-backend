namespace X.Kwiz.Api.Entities;
public class QuizQuestion
{
    public int TimeLimitSeconds { get; set; }
    public string Content { get; set; }
    public List<string> Options { get; set; }
    public string[] Tags { get; set; }
}