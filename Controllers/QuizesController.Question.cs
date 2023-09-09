using System.Security.Claims;
using Kwiz.Api.Data;
using Kwiz.Api.Dtos;
using Kwiz.Api.Dtos.QuizDtos;
using Kwiz.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.Api.Controllers;
public partial class QuizesController : ControllerBase
{
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuiz(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid id,
        [FromBody] UpdateQuizDto quizDto,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        if ((false == await dbContext.Quizzes.AnyAsync(q => q.Status != EQuizStatus.Deleted && q.OwnerId == userId
            && q.Id == id, cancellationToken)))
            return BadRequest("Quiz not found with this id.");

        var quiz = await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == id && q.OwnerId == userId, cancellationToken);
        quiz.Title = quizDto.Title;
        quiz.Description = quizDto.Description;
        quiz.UpdatedAt = DateTime.UtcNow;
        quiz.OpeningDateTime = quizDto.OpeningDateTime;
        quiz.ClosingDateTime = quizDto.ClosingDateTime;
        quiz.Status = ToEnum(quizDto.Status);
        quiz.IsPublic = quizDto.IsPublic;
        quiz.Tags = quizDto.Tags.ToArray();
        quiz.Code = quizDto.Code;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new GetQuizDto(quiz));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuiz(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);
        if ((false == await dbContext.Quizzes.AnyAsync(q => q.Status != EQuizStatus.Deleted && q.OwnerId == userId
            && q.Id == id, cancellationToken)))
            return BadRequest("Quiz not found with this id.");

        var quiz = await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == id && q.OwnerId == userId, cancellationToken);

        quiz.Status = EQuizStatus.Deleted;
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }

    [Authorize]
    [HttpPost("{quizId}/questions")]
    public async Task<IActionResult> CreateQuizQuestions(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid quizId,
        [FromBody] List<CreateQuizQuestionDto> quizQuestions,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == quizId && q.OwnerId == userId && q.Status != EQuizStatus.Deleted)
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(cancellationToken);

        if (quiz == null)
            return BadRequest("Quiz not found.");

        var questions = quizQuestions.Select(q => new QuizQuestion
        {
            TimeLimitSeconds = q.TimeLimitSeconds,
            Content = q.Content,
            Tags = q.Tags
        }).ToList();

        quiz.Questions.AddRange(questions);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(quiz.Questions.Select(q => new GetQuizQuestionDto(q)));
    }

    [Authorize]
    [HttpPost("{quizId}/question")]
    public async Task<ActionResult> CreateQuizQuestion(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid quizId,
        [FromBody] CreateQuizQuestionDto quizQuestion,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == quizId && q.OwnerId == userId && q.Status != EQuizStatus.Deleted)
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(cancellationToken);

        if (quiz == null)
            return BadRequest("Quiz not found.");

        var question = new QuizQuestion
        {
            TimeLimitSeconds = quizQuestion.TimeLimitSeconds,
            Content = quizQuestion.Content,
            Tags = quizQuestion.Tags
        };

        quiz.Questions.Add(question);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new GetQuizQuestionDto(question));
    }

    [Authorize]
    [HttpGet("{quizId}/questions")]
    public async Task<IActionResult> GetQuizQuestions(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid quizId,
        [FromQuery] string search,
        [FromQuery] int offset = 0,
        [FromQuery] int limit = 2,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == quizId && q.OwnerId == userId && q.Status != EQuizStatus.Deleted)
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(cancellationToken);

        if (quiz == null)
            return BadRequest("Quiz not found.");

        if (false == string.IsNullOrWhiteSpace(search))
            quiz.Questions = quiz.Questions.Where(q => q.Content.Contains(search)).ToList();

        var quizpaginated = quiz.Questions
            .Skip(offset * limit)
            .Take(limit)
            .Select(q => new GetQuizQuestionDto(q))
            .ToList();

        var result = new PaginatedList<GetQuizQuestionDto>(quizpaginated, quiz.Questions.Count(), offset + 1, limit);

        return Ok(result);
    }

    [Authorize]
    [HttpPut("{quizId}/questions/{questionId}")]
    public async Task<IActionResult> UpdateQuizQuestion(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid quizId,
        [FromRoute] Guid questionId,
        [FromBody] UpdateQuizQuestionDto quizQuestion,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == quizId && q.OwnerId == userId && q.Status != EQuizStatus.Deleted)
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(cancellationToken);

        if (quiz == null)
            return BadRequest("Quiz not found.");

        var question = quiz.Questions.FirstOrDefault(q => q.Id == questionId);

        if (question == null)
            return BadRequest("Question not found.");

        question.TimeLimitSeconds = quizQuestion.TimeLimitSeconds;
        question.Content = quizQuestion.Content;
        question.Tags = quizQuestion.Tags;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(question);
    }

    [Authorize]
    [HttpDelete("{quizId}/questions/{questionId}")]
    public async Task<IActionResult> DeleteQuizQuestion(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid quizId,
        [FromRoute] Guid questionId,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == quizId && q.OwnerId == userId && q.Status != EQuizStatus.Deleted)
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(cancellationToken);

        if (quiz == null)
            return BadRequest("Quiz not found.");

        var question = quiz.Questions.FirstOrDefault(q => q.Id == questionId);

        if (question == null)
            return BadRequest("Question not found.");

        quiz.Questions.Remove(question);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }

}