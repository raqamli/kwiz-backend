using Kwiz.Api.Entities;

namespace Kwiz.Api.Services;

public interface IQuizService
{
    Task<List<Quiz>> GetAllQuizzes();
    Task<Quiz> GetQuiz(Guid id);
    Task<Quiz> CreateQuiz(Quiz newQuiz);
    Task<Quiz> UpdateQuiz(Quiz quiz);
    Task DeleteQuiz(Guid id);
}