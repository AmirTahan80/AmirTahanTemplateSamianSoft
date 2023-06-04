using System.Reflection;

using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace SamianSoft.Infrastructure.Elasticsearch
{
    public class SerilogLogging : ISerilogLogginSettup
    {
        public Task SaveToElastic(string obj)
        {
            //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile(
            //        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
            //        optional: true)
            //    .Build();
            var logBuilder = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(
                    new Uri("http://10.0.2.168:9200/"))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = $"{Assembly.GetExecutingAssembly()
                    .GetName().Name.ToLower()}-{DateTime.UtcNow:yyyy-MM}"
                })
                //.Enrich.WithProperty("Environment", environment)
                //.ReadFrom.Configuration(configuration)
                .CreateLogger();
            logBuilder.Write(Serilog.Events.LogEventLevel.Information,
                obj);
            return Task.CompletedTask;
        }
    }
}
