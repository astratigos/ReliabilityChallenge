using MediatR;
using ReliabilityChallenge.Models;
using ReliabilityChallenge.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReliabilityChallenge.Controllers
{
    class RequestController : IRequestHandler<Request, Response>
    {
        private readonly RequestProcessingService requestProcessignService;

        public RequestController(RequestProcessingService requestProcessignService)
        {
            this.requestProcessignService = requestProcessignService;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var response = await requestProcessignService.DoWork(request);
            Console.WriteLine($"Succesfully processed request: {request.Id}");
            return response;
        }
    }
}
