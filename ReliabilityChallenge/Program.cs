using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using System.Threading.Tasks;
using ReliabilityChallenge.Services;

namespace ReliabilityChallenge
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            await hostBuilder.RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.AddConsole();
            })
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddMediatR(Assembly.GetExecutingAssembly());
                services.AddTransient<RequestProcessingService>();
                services.AddDbContext<ConsoleAppContext>();
                services.AddHostedService<ConsoleApp>();
                
                using (var client = new ConsoleAppContext())
                {
                    client.Database.EnsureCreated();
                }

                services.AddSingleton<MockRequestService>();
            });
    }
}
