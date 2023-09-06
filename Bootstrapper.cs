using Kwiz.Api.Services;

namespace Kwiz;

public static class Bootstrapper
{
    public static void UseServices(this IServiceCollection services)
    {
        services.AddHttpClient<IQuizService, QuizService>();
    }
}