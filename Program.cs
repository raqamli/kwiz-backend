using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Kwiz.Api;
using Kwiz.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IKwizDbContext, KwizDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
builder.Services.AddSwaggerDocumentation(builder.Configuration);
builder.Services.AddKeycloakAuthenticationServices(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(config => config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder
                .WithOrigins("http://localhost:3000", "https://localhost:3001") // Specify the allowed origins (http and https)
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowLocalhost");
app.UseSwaggerDocumentation();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticFiles();
app.MapControllers();
app.Run();