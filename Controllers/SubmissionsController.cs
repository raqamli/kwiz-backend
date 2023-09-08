using System.Security.Claims;
using Kwiz.Api.Data;
using Kwiz.Api.Dtos;
using Kwiz.Api.Dtos.SubmissionDtos;
using Kwiz.Api.Dtos.SubmissionSelectionDtos;
using Kwiz.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.Api.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class SubmissionsController : ControllerBase
{
    [Authorize]
    [HttpPost("{quizId}")]
    public async Task<IActionResult> CrateSubmission(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid quizId,
        [FromBody] CreateSubmissionDto dto,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == quizId && q.OwnerId == userId && q.Status != EQuizStatus.Deleted)
            .FirstOrDefaultAsync(cancellationToken);

        Console.WriteLine("QuestionId : " + quizId);

        if (quiz == null)
            return BadRequest("Quiz not found with this id.");

        var persistedSubmission = dbContext.Submissions.Add(new Submission
        {
            Id = Guid.NewGuid(),
            OwnerId = userId,
            QuizId = quizId,
            StartedDateTime = dto.StartedDateTime,
            FinishedDateTime = dto.FinishedDateTime
        });
        await dbContext.SaveChangesAsync(cancellationToken);
        return Ok(new GetSubmissionDto(persistedSubmission.Entity));
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubmission(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var submission = await dbContext.Submissions
            .Where(s => s.Id == id && s.OwnerId == userId)
            .FirstOrDefaultAsync(cancellationToken);

        if (submission == null)
            return BadRequest("Submission not found");

        return Ok(new GetSubmissionDto(submission));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetSubmissions(
        [FromServices] IKwizDbContext dbContext,
        [FromQuery] DateTime startdate,
        [FromQuery] DateTime enddate,
        [FromQuery] int offset = 0,
        [FromQuery] int limit = 2,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var submissions = await dbContext.Submissions
            .Where(s => s.OwnerId == userId)
            .ToListAsync(cancellationToken);

        if (submissions == null)
            return BadRequest("Submissions not found");

        if (false == string.IsNullOrWhiteSpace(startdate.ToString()) && false == string.IsNullOrWhiteSpace(enddate.ToString()))
            submissions = submissions.Where(q => q.StartedDateTime >= startdate && q.FinishedDateTime <= enddate).ToList();

        var submissionPaginated = submissions
            .Skip(offset * limit)
            .Take(limit)
            .Select(q => new GetSubmissionDto(q))
            .ToList();

        var result = new PaginatedList<GetSubmissionDto>(submissionPaginated, submissions.Count(), offset + 1, limit);

        return Ok(result);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubmission(
        [FromServices] IKwizDbContext dbContext,
        [FromBody] UpdateSubmissionDto dto,
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var submission = await dbContext.Submissions
            .Where(s => s.Id == id && s.OwnerId == userId)
            .FirstOrDefaultAsync(cancellationToken);
        if (submission == null)
            return BadRequest("Submission not found");

        submission.StartedDateTime = dto.StartedDateTime;
        submission.FinishedDateTime = dto.FinishedDateTime;

        await dbContext.SaveChangesAsync(cancellationToken);
        return Ok(new GetSubmissionDto(submission));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubmission(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var submission = await dbContext.Submissions
            .Where(s => s.Id == id && s.OwnerId == userId)
            .FirstOrDefaultAsync(cancellationToken);

        if (submission == null)
            return BadRequest("Submission not found");

        dbContext.Submissions.Remove(submission);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Ok();
    }

    [Authorize]
    [HttpPost("{questionId}/submissionSelection")]
    public async Task<IActionResult> CreateSubmissionSelection(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid questionId,
        [FromBody] CreateSubmissionSelectionDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await dbContext.QuizQuestions
            .Where(q => q.Id == questionId)
            .Include(q => q.SubmissionSelections)
            .FirstOrDefaultAsync(cancellationToken);

        if (question == null)
            return BadRequest("Question not found.");

        var submissionSelection = dbContext.SubmissionSelections.Add(new SubmissionSelection
        {
            QuestionId = questionId,
            IsSkipped = dto.IsSkipped,
            TimeSpentOnQuestion = dto.TimeSpentOnQuestion
        });
        await dbContext.SaveChangesAsync(cancellationToken);
        return Ok(new GetSubmissionSelectionDto(submissionSelection.Entity));
    }

    [Authorize]
    [HttpGet("{questionId}/submissionSelection/{id}")]
    public async Task<IActionResult> GetSubmissionSelection(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid questionId,
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var question = await dbContext.QuizQuestions
            .Where(q => q.Id == questionId)
            .Include(q => q.SubmissionSelections)
            .FirstOrDefaultAsync(cancellationToken);

        if (question == null)
            return BadRequest("Question not found.");

        var submissionSelection = question.SubmissionSelections
            .FirstOrDefault(s => s.Id == id);

        if (submissionSelection == null)
            return BadRequest("SubmissionSelection not found.");

        return Ok(new GetSubmissionSelectionDto(submissionSelection));
    }

    [Authorize]
    [HttpPut("{questionId}/submissionSelection/{id}")]
    public async Task<IActionResult> UpdateSubmissionSelection(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid questionId,
        [FromRoute] Guid id,
        [FromBody] UpdateSubmissionSelectionDto dto,
        CancellationToken cancellationToken = default)
    {
        var question = await dbContext.QuizQuestions
            .Where(q => q.Id == questionId)
            .Include(q => q.SubmissionSelections)
            .FirstOrDefaultAsync(cancellationToken);

        if (question == null)
            return BadRequest("Question not found.");

        var submissionSelection = question.SubmissionSelections
            .FirstOrDefault(s => s.Id == id);
        if (submissionSelection == null)
            return BadRequest("SubmissionSelection not found.");

        submissionSelection.IsSkipped = dto.IsSkipped;
        submissionSelection.TimeSpentOnQuestion = dto.TimeSpentOnQuestion;
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new GetSubmissionSelectionDto(submissionSelection));
    }

    [Authorize]
    [HttpDelete("{questionId}/submissionSelection/{id}")]
    public async Task<IActionResult> DeleteSubmissionSelection(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid questionId,
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var question = await dbContext.QuizQuestions
            .Where(q => q.Id == questionId)
            .Include(q => q.SubmissionSelections)
            .FirstOrDefaultAsync(cancellationToken);

        if (question == null)
            return BadRequest("Question not found.");

        var submissionSelection = question.SubmissionSelections
            .FirstOrDefault(s => s.Id == id);

        if (submissionSelection == null)
            return BadRequest("SubmissionSelection not found.");

        dbContext.SubmissionSelections.Remove(submissionSelection);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Ok();
    }

}