using System.Text.Json.Serialization;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders.Thrift;
using Microsoft.EntityFrameworkCore;
using Kwiz.Api;
using Kwiz.Api.Data;
using OpenTracing;
using OpenTracing.Contrib.NetCore.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IKwizDbContext, KwizDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
builder.Services.AddSwaggerDocumentation(builder.Configuration);
builder.Services.AddKeycloakAuthenticationServices(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(config => config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddOpenTracing();
builder.Services.AddSingleton<ITracer>(sp =>
{
    var serviceName = sp.GetRequiredService<IWebHostEnvironment>().ApplicationName;
    var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
    var reporter = new RemoteReporter.Builder().WithLoggerFactory(loggerFactory).WithSender(new UdpSender())
        .Build();
    var tracer = new Tracer.Builder(serviceName)
        .WithSampler(new ConstSampler(true))
        .WithReporter(reporter)
        .Build();
    return tracer;
});

builder.Services.Configure<HttpHandlerDiagnosticOptions>(options =>
    options.OperationNameResolver =
        request => $"{request.Method.Method}: {request?.RequestUri?.AbsoluteUri}");

var app = builder.Build();

app.UseSwaggerDocumentation();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticFiles();
app.MapControllers();
app.Run();