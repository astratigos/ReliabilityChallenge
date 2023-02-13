using ReliabilityChallenge.Models;
using ReliabilityChallenge.Services;
using Xunit;

namespace ReliabilityChallenge.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var requestProcessingService = new RequestProcessingService();
            for (int i = 1; i <= 10; i++)
            {
                
                Thread.Sleep(1000);

                await requestProcessingService.DoWork(new Request() { Id = i });
            }
        }
    }
}
