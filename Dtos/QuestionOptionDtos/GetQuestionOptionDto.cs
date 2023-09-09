using Kwiz.Api.Entities;

namespace Kwiz.Api.Dtos.QuestionOptionDtos;
public class GetQuestionOptionDto
{
    public GetQuestionOptionDto(QuestionOption questionOption)
    {
        Id = questionOption.Id;
        QuestionId = questionOption.QuestionId;
        SubmissionId = questionOption.SubmissionId;
        Content = questionOption.Content;
        IsCorrect = questionOption.IsCorrect;
        IsRequired = questionOption.IsRequired;
        Explanation = questionOption.Explanation;
    }
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid SubmissionId { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
    public bool IsRequired { get; set; }
    public string Explanation { get; set; }
}