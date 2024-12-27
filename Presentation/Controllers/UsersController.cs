using Application.Commands;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            // Send the query to the MediatR pipeline
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllUsers), new { id = userId }, userId);
        }
    }
}