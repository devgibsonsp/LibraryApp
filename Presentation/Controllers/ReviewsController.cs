using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(ILogger<ReviewsController> logger)
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
