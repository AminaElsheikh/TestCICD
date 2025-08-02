using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Serilog;
using Serilog.Sinks.Elasticsearch;

using System;

namespace TestCICD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = "aspnetcore-logs-{0:yyyy.MM.dd}"
                })
                .Enrich.FromLogContext()
                .CreateLogger();

            try
            {
                Log.Information("Starting host...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseSerilog() // <--- Plug Serilog into the host
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
