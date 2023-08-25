using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using X.Kwiz.Api;
using X.Kwiz.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IKwizDbContext, KwizDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
builder.Services.AddSwaggerDocumentation(builder.Configuration);
builder.Services.AddKeycloakAuthenticationServices(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(config => config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.UseSwaggerDocumentation();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticFiles();
app.MapControllers();
app.Run();