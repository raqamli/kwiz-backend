using Microsoft.EntityFrameworkCore;
using Kwiz.Api.Entities;

namespace Kwiz.Api.Data;
public interface IKwizDbContext
{
    DbSet<TechInterest> TechInterests { get; set; }
    DbSet<Submission> Submissions { get; set; }
    DbSet<SubmissionSelection> SubmissionSelections { get; set; }
    DbSet<Quiz> Quizzes { get; set; }
    DbSet<QuizQuestion> QuizQuestions { get; set; }
    DbSet<QuestionOption> QuestionOptions { get; set; }
    DbSet<Technology> Technologies { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}