using Kwiz.Api.Entities;

namespace Kwiz.Api.Dtos.QuizDtos;

public class GetQuizQuestionDto
{
    public GetQuizQuestionDto(QuizQuestion quiz)
    {
        Id = quiz.Id;
        TimeLimitSeconds = quiz.TimeLimitSeconds;
        Content = quiz.Content;
        Tags = quiz.Tags;
    }
    public Guid Id { get; set; }
    public int TimeLimitSeconds { get; set; }
    public string Content { get; set; }
    public string[] Tags { get; set; }
}