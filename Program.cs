using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Kwiz.Api;
using Kwiz.Api.Data;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IKwizDbContext, KwizDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
builder.Services.AddSwaggerDocumentation(builder.Configuration);
builder.Services.AddKeycloakAuthenticationServices(builder.Configuration);
builder.Services.AddJaegerTracing();
builder.Services.AddControllers()
    .AddJsonOptions(config => config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});


var app = builder.Build();

app.UseHttpLogging();
app.UseSwaggerDocumentation();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticFiles();
app.MapControllers();
app.Run();