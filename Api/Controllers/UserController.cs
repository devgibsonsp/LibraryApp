using Microsoft.AspNetCore.Mvc;


namespace LibraryApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public UserController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        public bool Get()
        {
            return true;
        }
    }
}
