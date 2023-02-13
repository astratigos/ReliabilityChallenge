using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReliabilityChallenge.Models;
using ReliabilityChallenge.Services;

namespace ReliabilityChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> _logger;
        private readonly RequestProcessingService _requestProcessingService;
        private readonly ConsoleAppContext _consoleAppContext;

        public RequestController(ILogger<RequestController> logger, RequestProcessingService requestProcessingService, ConsoleAppContext consoleAppContext )
        {
            _logger = logger;
            _requestProcessingService = requestProcessingService;
            _consoleAppContext = consoleAppContext;
        }

        [HttpPost]
        public async Task<Response> CreateRequest()
        {
            var request = new Request();
            _consoleAppContext.Requests.Add(request);
            var response = await _requestProcessingService.DoWork(request);
            _consoleAppContext.Responses.Add(response);
            await _consoleAppContext.SaveChangesAsync();
            return response;
        }
    }
}
