using Microsoft.Extensions.FileProviders;

namespace Kwiz.Api;

public static class StaticFilesEndpointExtensions
{
    public static void MapStaticFiles(this WebApplication app)
    {
        var cacheMaxAgeOneWeek = (60 * 60 * 24 * 7).ToString();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "StaticFiles")),
            RequestPath = "/v1/files",
            OnPrepareResponse = ctx =>
            {
                ctx.Context.Response.Headers.Append(
                     "Cache-Control", $"public, max-age={cacheMaxAgeOneWeek}");
            }
        });
    }
}