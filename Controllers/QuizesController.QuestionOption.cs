using System.Security.Claims;
using Kwiz.Api.Data;
using Kwiz.Api.Dtos.QuestionOptionDtos;
using Kwiz.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.Api.Controllers;
public partial class QuizesController : ControllerBase
{
    [Authorize]
    [HttpPost("{questionId}/questionOptions")]
    public async Task<IActionResult> CreateQuizQuestionOptions(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid questionId,
        [FromBody] IEnumerable<CreateQuestionOptionDto> options,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var question = await dbContext.QuizQuestions
            .Where(q => q.Id == questionId)
            .FirstOrDefaultAsync(cancellationToken);

        if (question == null)
            return BadRequest("Question not found.");

        var questionoptions = question.Options = options.Select(o => new QuestionOption
        {
            QuestionId = questionId,
            SubmissionId = o.SubmissionId,
            Content = o.Content,
            IsCorrect = o.IsCorrect,
            IsRequired = o.IsRequired,
            Explanation = o.Explanation
        }).ToList();
        dbContext.QuestionOptions.AddRange(questionoptions);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(questionoptions.Select(o => new GetQuestionOptionDto(o)));
    }

    [Authorize]
    [HttpPost("{questionId}/questionOption")]
    public async Task<IActionResult> CreateQuizQuestionOption(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid questionId,
        [FromBody] CreateQuestionOptionDto option,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var question = await dbContext.QuizQuestions
            .Where(q => q.Id == questionId)
            .FirstOrDefaultAsync(cancellationToken);

        if (question == null)
            return BadRequest("Question not found.");

        var questionOption = new QuestionOption
        {
            QuestionId = questionId,
            SubmissionId = option.SubmissionId,
            Content = option.Content,
            IsCorrect = option.IsCorrect,
            IsRequired = option.IsRequired,
            Explanation = option.Explanation
        };
        question.Options.Add(questionOption);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Ok(new GetQuestionOptionDto(questionOption));
    }

    [Authorize]
    [HttpGet("{questionId}/questionOptions")]
    public async Task<IActionResult> GetQuizQuestionOptions(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid questionId,
        CancellationToken cancellationToken = default)
    {
        var question = await dbContext.QuizQuestions
            .Where(q => q.Id == questionId)
            .Include(q => q.Options)
            .FirstOrDefaultAsync(cancellationToken);

        if (question == null)
            return BadRequest("Question not found.");

        if (false == question.Options.Any())
            return BadRequest("questionOptions not found.");

        return Ok(question.Options.Select(o => new GetQuestionOptionDto(o)));
    }

    [Authorize]
    [HttpPut("{questionId}/questionOptions/{id}")]
    public async Task<IActionResult> UpdateQuizQuestionOption(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid questionId,
        [FromRoute] Guid id,
        [FromBody] UpdateQuestionOptionDto option,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var question = await dbContext.QuizQuestions
            .Where(q => q.Id == questionId)
            .Include(q => q.Options)
            .FirstOrDefaultAsync(cancellationToken);

        if (question == null)
            return BadRequest("Question not found.");

        var questionOption = question.Options.FirstOrDefault(o => o.Id == id);
        if (questionOption == null)
            return BadRequest("Option not found.");

        questionOption.SubmissionId = option.SubmissionId;
        questionOption.Content = option.Content;
        questionOption.IsCorrect = option.IsCorrect;
        questionOption.IsRequired = option.IsRequired;
        questionOption.Explanation = option.Explanation;
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new GetQuestionOptionDto(questionOption));
    }

    [Authorize]
    [HttpDelete("{questionId}/questionOptions/{id}")]
    public async Task<IActionResult> DeleteQuizQuestionOption(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid questionId,
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var question = await dbContext.QuizQuestions
            .Where(q => q.Id == questionId)
            .Include(q => q.Options)
            .FirstOrDefaultAsync(cancellationToken);

        if (question == null)
            return BadRequest("Question not found.");

        var questionOption = question.Options.FirstOrDefault(o => o.Id == id);
        if (questionOption == null)
            return BadRequest("Option not found.");

        question.Options.Remove(questionOption);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Ok(new GetQuestionOptionDto(questionOption));
    }
}