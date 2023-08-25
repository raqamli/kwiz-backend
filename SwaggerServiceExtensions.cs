using Microsoft.OpenApi.Models;

namespace X.Kwiz.Api;

public static class SwaggerServiceExtensions
{
    public static WebApplication UseSwaggerDocumentation(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(s => s.OAuthClientId(app.Configuration["Keycloak:OAuth2:ClientId"]));
        return app;
    }

    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            var oauth2Schema = new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(configuration["Keycloak:OAuth2:AuthUrl"]),
                        TokenUrl = new Uri(configuration["Keycloak:OAuth2:TokenUrl"]),
                    }
                },
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            };
            c.AddSecurityDefinition(oauth2Schema.Reference.Id, oauth2Schema);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { oauth2Schema, Array.Empty<string>() }
            });
        });

        return services;
    }
}