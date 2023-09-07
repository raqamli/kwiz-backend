using System.Security.Claims;
using Kwiz.Api.Data;
using Kwiz.Api.Dtos;
using Kwiz.Api.Dtos.QuizDtos;
using Kwiz.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.Api.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class QuizesController : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateQuiz(
        [FromServices] IKwizDbContext dbContext,
        [FromBody] CreateQuizDto quiz,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        if (await dbContext.Quizzes.AnyAsync(q => q.Title == quiz.Title && q.OwnerId == userId, cancellationToken))
            return BadRequest("Quiz already exists with this Title.");

        var persistedQuiz = dbContext.Quizzes.Add(new Quiz
        {
            Id = Guid.NewGuid(),
            OwnerId = userId,
            Title = quiz.Title,
            Description = quiz.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            OpeningDateTime = quiz.OpeningDateTime,
            ClosingDateTime = quiz.ClosingDateTime,
            Status = ToEnum(quiz.Status),
            IsPublic = quiz.IsPublic,
            Tags = quiz.Tags.ToArray(),
            Code = quiz.Code
        });
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new GetQuizDto(persistedQuiz.Entity));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetQuizesUser(
        [FromServices] IKwizDbContext dbContext,
        [FromQuery] string search,
        [FromQuery] int offset = 0,
        [FromQuery] int limit = 2,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        if ((false == await dbContext.Quizzes.AnyAsync(q => q.Status != EQuizStatus.Deleted && q.OwnerId == userId, cancellationToken)))
            return BadRequest("Quiz not found.");

        var quizzes = dbContext.Quizzes.Where(q => q.Status != EQuizStatus.Deleted && q.OwnerId == userId).AsQueryable();

        if (false == string.IsNullOrWhiteSpace(search))
            quizzes = quizzes.Where(u =>
                u.Title.Contains(search) || u.Description.ToLower().Contains(search.ToLower())
                && u.Status != EQuizStatus.Deleted && u.OwnerId == userId)
                .OrderByDescending(q => q.CreatedAt);

        var quizpaginated = await quizzes
            .Skip(offset * limit)
            .Take(limit)
            .Where(q => q.Status != EQuizStatus.Deleted && q.OwnerId == userId)
            .OrderByDescending(q => q.CreatedAt)
            .Select(q => new GetQuizDto(q))
            .ToListAsync(cancellationToken);

        var result = new PaginatedList<GetQuizDto>(quizpaginated, quizzes.Count(), offset + 1, limit);

        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuiz(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        if ((false == await dbContext.Quizzes.AnyAsync(q => q.Status != EQuizStatus.Deleted && q.OwnerId == userId
            && q.Id == id, cancellationToken)))
            return BadRequest("Quiz not with this id.");

        var quiz = await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == id && q.OwnerId == userId, cancellationToken);
        return Ok(new GetQuizDto(quiz));
    }

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

    private EQuizStatus ToEnum(EQuizStatusDto dto)
    {
        return (EQuizStatus)dto;
    }
}