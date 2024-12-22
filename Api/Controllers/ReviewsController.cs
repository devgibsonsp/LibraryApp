using Microsoft.AspNetCore.Mvc;


namespace LibraryApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public ReviewsController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetReviews")]
        public bool Get()
        {
            return true;
        }
    }
}
