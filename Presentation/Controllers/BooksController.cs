using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;

        public BooksController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBooks")]
        public bool Get()
        {
            return true;
        }
    }
}
