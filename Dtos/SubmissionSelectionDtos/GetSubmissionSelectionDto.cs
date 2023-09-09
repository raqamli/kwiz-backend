using Kwiz.Api.Entities;

namespace Kwiz.Api.Dtos.SubmissionSelectionDtos;
public class GetSubmissionSelectionDto
{
    public GetSubmissionSelectionDto(SubmissionSelection submissionSelection)
    {
        Id = submissionSelection.Id;
        QuestionId = submissionSelection.QuestionId;
        IsSkipped = submissionSelection.IsSkipped;
        TimeSpentOnQuestion = submissionSelection.TimeSpentOnQuestion;
    }

    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public bool IsSkipped { get; set; }
    public int TimeSpentOnQuestion { get; set; }
}