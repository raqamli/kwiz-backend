using Kwiz.Api.Entities;

namespace Kwiz.Api.Dtos.QuizDtos;
public class GetQuizDto
{
    public GetQuizDto(Quiz quiz)
    {
        Id = quiz.Id;
        OwnerId = quiz.OwnerId;
        Title = quiz.Title;
        Description = quiz.Description;
        CreatedAt = quiz.CreatedAt;
        UpdatedAt = quiz.UpdatedAt;
        OpeningDateTime = quiz.OpeningDateTime;
        ClosingDateTime = quiz.ClosingDateTime;
        Status = ToEnum(quiz.Status);
        IsPublic = quiz.IsPublic;
        Tags = quiz.Tags.ToArray();
        Code = quiz.Code;
    }
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime OpeningDateTime { get; set; }
    public DateTime ClosingDateTime { get; set; }
    public EQuizStatusDto Status { get; set; }
    public bool IsPublic { get; set; }
    public string[] Tags { get; set; }
    public string Code { get; set; }

    private EQuizStatusDto ToEnum(EQuizStatus entity)
    {
        return (EQuizStatusDto)entity;
    }
}