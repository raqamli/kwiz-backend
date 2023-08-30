using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders.Thrift;
using OpenTracing;
using OpenTracing.Contrib.NetCore.Configuration;

namespace Kwiz.Api;
public static class JaegerTracingServiceExtensions
{
    public static IServiceCollection AddJaegerTracing(this IServiceCollection services)
    {
        services.AddOpenTracing();
        services.AddSingleton<ITracer>(sp =>
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

        services.Configure<HttpHandlerDiagnosticOptions>(options =>
            options.OperationNameResolver =
                request => $"{request.Method.Method}: {request?.RequestUri?.AbsoluteUri}");

        return services;
    }
}