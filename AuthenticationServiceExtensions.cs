using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;

namespace X.Kwiz.Api;

public static class AuthenticationServiceExtensions
{
    public static IServiceCollection AddKeycloakAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationOptions = configuration
            .GetSection(KeycloakAuthenticationOptions.Section)
            .Get<KeycloakAuthenticationOptions>();

        services.AddKeycloakAuthentication(authenticationOptions);

        var authorizationOptions = configuration
            .GetSection(KeycloakProtectionClientOptions.Section)
            .Get<KeycloakProtectionClientOptions>();

        services
            .AddAuthorization(o => o.AddPolicy("KwizAdminsOnly", b =>
            {
                b.RequireResourceRoles("kwiz.admin");
            }))
            .AddKeycloakAuthorization(authorizationOptions);

        return services;
    }
}