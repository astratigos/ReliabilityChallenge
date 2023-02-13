using Microsoft.Extensions.Logging;
using ReliabilityChallenge.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ReliabilityChallenge
{
    public class ConsoleApp : Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly ILogger<ConsoleApp> logger;

        public ConsoleApp(ILogger<ConsoleApp> logger, MockRequestService mockRequestService, ConsoleAppContext consoleAppContext)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

        }
    }
}
