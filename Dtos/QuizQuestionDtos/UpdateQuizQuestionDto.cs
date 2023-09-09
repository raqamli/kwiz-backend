namespace Kwiz.Api.Dtos.QuizDtos;

public class UpdateQuizQuestionDto
{
    public int TimeLimitSeconds { get; set; }
    public string Content { get; set; }
    public string[] Tags { get; set; }
}