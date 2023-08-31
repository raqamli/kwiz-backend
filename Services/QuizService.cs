using System.Text;
using System.Text.Json.Serialization;
using Kwiz.Api.Entities;
using Newtonsoft.Json;

namespace Kwiz.Api.Services;

public class QuizService : IQuizService
{
    private const string BaseUrl = "https://";
    private readonly HttpClient client;

    public QuizService(HttpClient client)
    {
        this.client = client;
    }
    public async Task<Quiz> CreateQuiz(Quiz newQuiz)
    {
        var content = JsonConvert.SerializeObject(newQuiz);
        var httpResponce = await client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

        if(!httpResponce.IsSuccessStatusCode)
            throw new Exception("Cannot add a new quiz");
        
        var createQuiz = JsonConvert.DeserializeObject<Quiz>(await httpResponce.Content.ReadAsStringAsync());
        return createQuiz;
    }

    public async Task DeleteQuiz(Guid id)
    {
        var httpResponce = await client.DeleteAsync($"{BaseUrl}/{id}");

        if(!httpResponce.IsSuccessStatusCode)
            throw new Exception("Cannot delete the quiz");
    }

    public async Task<List<Quiz>> GetAllQuizzes()
    {
        var httpResponce = await client.GetAsync(BaseUrl);

        if(!httpResponce.IsSuccessStatusCode)
            throw new Exception("Cannot retrieve all quiz");

        var content = await httpResponce.Content.ReadAsStringAsync();
        var quizzes = JsonConvert.DeserializeObject<List<Quiz>>(content);
        return quizzes;
    }

    public async Task<Quiz> GetQuiz(Guid id)
    {
        var httpResponce = await client.GetAsync($"{BaseUrl}/{id}");

        if(!httpResponce.IsSuccessStatusCode)
            throw new Exception("cannot retrieve quiz");
        
        var content = await httpResponce.Content.ReadAsStringAsync();
        var quizItem = JsonConvert.DeserializeObject<Quiz>(content);

        return quizItem;
    }

    public async Task<Quiz> UpdateQuiz(Quiz quiz)
    {
        var content = JsonConvert.SerializeObject(quiz);
        var httpResponce = await client.PutAsync($"{BaseUrl}/{quiz.Id}", new StringContent(content, Encoding.Default, "application/json"));

        if(!httpResponce.IsSuccessStatusCode)
            throw new Exception("Cannot update quiz");
        
        var updateQuiz = JsonConvert.DeserializeObject<Quiz>(await httpResponce.Content.ReadAsStringAsync());
        return updateQuiz;
    }
}
