using Microsoft.AspNetCore.Mvc;
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

        public RequestController(ILogger<RequestController> logger, RequestProcessingService requestProcessingService)
        {
            _logger = logger;
            _requestProcessingService = requestProcessingService;
        }

        [HttpPost(Name = "Request")]
        public async Task<Response> CreateRequest(int id = 1)
        {
            return await _requestProcessingService.DoWork(new Models.Request() { Id = id } );
        }
    }
}