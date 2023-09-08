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

        if (await dbContext.Quizzes.AnyAsync(q => q.Title == quiz.Title && q.OwnerId == userId, cancellationToken)
        && await dbContext.Quizzes.AnyAsync(q => q.Description == quiz.Description && q.OwnerId == userId, cancellationToken))
            return BadRequest("Quiz already exists.");

        var persistedQuiz = dbContext.Quizzes.Add(new Quiz
        {
            Id = Guid.NewGuid(),
            OwnerId = userId,
            Title = quiz.Title,
            Description = quiz.Description,
            CreatedAt = quiz.CreatedAt,
            UpdatedAt = quiz.UpdatedAt,
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

        if((false == await dbContext.Quizzes.AnyAsync(q => q.Status == EQuizStatus.Active && q.OwnerId == userId, cancellationToken)))
            return BadRequest("User not quizzes.");

        var quizzes = dbContext.Quizzes.Where(q=>q.Status==EQuizStatus.Active && q.OwnerId == userId)
            .OrderByDescending(q=>q.CreatedAt)
            .AsQueryable();

        if(false == string.IsNullOrWhiteSpace(search))
            quizzes = quizzes.Where(u =>
                u.Title.Contains(search) || u.Description.ToLower().Contains(search.ToLower())
                && u.Status == EQuizStatus.Active && u.OwnerId == userId)
                .OrderByDescending(q=>q.CreatedAt);

        var quizpaginated = await quizzes
            .Skip(offset*limit)
            .Take(limit)
            .Where(q=>q.Status == EQuizStatus.Active && q.OwnerId == userId)
            .OrderBy(q=>q.CreatedAt)
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

        if((false == await dbContext.Quizzes.AnyAsync(q => q.Status == EQuizStatus.Active && q.OwnerId == userId, cancellationToken)))
            return BadRequest("User not quizzes.");
        
        var quiz = await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == id && q.OwnerId == userId, cancellationToken);
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
        if((false == await dbContext.Quizzes.AnyAsync(q => q.Status == EQuizStatus.Active && q.OwnerId == userId, cancellationToken)))
            return BadRequest("User not quizzes.");

        var quiz = await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == id && q.OwnerId == userId, cancellationToken);
        dbContext.Quizzes.Remove(quiz);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Ok();
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

        if((false == await dbContext.Quizzes.AnyAsync(q => q.Status == EQuizStatus.Active && q.OwnerId == userId, cancellationToken)))
            return BadRequest("User not quizzes.");

        var quiz = await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == id && q.OwnerId == userId, cancellationToken);
        quiz.Title = quizDto.Title;
        quiz.Description = quizDto.Description;
        quiz.CreatedAt = quizDto.CreatedAt;
        quiz.UpdatedAt = quizDto.UpdatedAt;
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
    [HttpPost("{id}/questions")]
    public async Task<IActionResult> CreateQuizQuestions(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid id,
        [FromBody] List<CreateQuizQuestionDto> quizQuestions,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == id && q.OwnerId == userId && q.Status != EQuizStatus.Deleted)
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(cancellationToken);
        
        if(quiz == null)
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
    [HttpPost("{id}/question")]
    public async Task<ActionResult> CreateQuizQuestion(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid id,
        [FromBody] CreateQuizQuestionDto quizQuestion,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == id && q.OwnerId == userId && q.Status != EQuizStatus.Deleted)
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(cancellationToken);
        
        if(quiz == null)
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
    [HttpGet("{id}/questions")]
    public async Task<IActionResult> GetQuizQuestions(
        [FromServices] IKwizDbContext dbContext,
        [FromRoute] Guid id,
        [FromQuery] string search,
        [FromQuery] int offset = 0,
        [FromQuery] int limit = 2,
        CancellationToken cancellationToken = default)
    {
        var idCliam = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(idCliam);

        var quiz = await dbContext.Quizzes
            .Where(q => q.Id == id && q.OwnerId == userId && q.Status != EQuizStatus.Deleted)
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(cancellationToken);
        
        if(quiz == null)
            return BadRequest("Quiz not found.");

        var questions = quiz.Questions.ToList();

        return Ok(questions.Select(q => new GetQuizQuestionDto(q)));
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
        
        if(quiz == null)
            return BadRequest("Quiz not found.");

        var question = quiz.Questions.FirstOrDefault(q => q.Id == questionId);

        if(question == null)
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
        
        if(quiz == null)
            return BadRequest("Quiz not found.");
        
        var question = quiz.Questions.FirstOrDefault(q => q.Id == questionId);

        if(question == null)
            return BadRequest("Question not found.");
        
        quiz.Questions.Remove(question);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }

    private EQuizStatus ToEnum(EQuizStatusDto dto)
    {
        return (EQuizStatus)dto;
    }
}