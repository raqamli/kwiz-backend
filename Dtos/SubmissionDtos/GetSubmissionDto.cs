using Kwiz.Api.Entities;

namespace Kwiz.Api.Dtos.SubmissionDtos;
public class GetSubmissionDto
{
    public GetSubmissionDto(Submission submission)
    {
        Id = submission.Id;
        OwnerId = submission.OwnerId;
        QuizId = submission.QuizId;
        StartedDateTime = submission.StartedDateTime;
        FinishedDateTime = submission.FinishedDateTime;
    }
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public Guid QuizId { get; set; }
    public DateTime StartedDateTime { get; set; }
    public DateTime FinishedDateTime { get; set; }
}