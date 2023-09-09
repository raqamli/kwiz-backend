using Kwiz.Api.Data;
using Kwiz.Api.Dtos.SubmissionSelectionDtos;
using Kwiz.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.Api.Controllers;
public partial class SubmissionsController : ControllerBase
{
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