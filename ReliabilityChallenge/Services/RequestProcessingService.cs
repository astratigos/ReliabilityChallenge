using ReliabilityChallenge.Models;
using System;
using System.Threading.Tasks;

namespace ReliabilityChallenge.Services
{
    public class RequestProcessingService
    {
        public async Task<Response> DoWork(Request request)
        {
            int randomNumber = new Random().Next(1, 10);

            switch (randomNumber)
            {                    
                case 2:
                    // Local Error
                    throw new Exception("Divide by Zero");
                case 3:
                    // Never get a response
                    await Task.Delay(Int32.MaxValue);
                    break;
                default:
                    break;
            }

            return new Response();
        }
    }
}
