using CQRS.Api.Features.Users.CreateUser;
using CQRS.Api.Features.Users.GetAllUser;
using CQRS.Api.Features.Users.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await mediator.Send(new GetAllUserCommand());

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await mediator.Send(new GetUserByIdCommand(id));

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand userCommand)
        {
            var user = await mediator.Send(userCommand);

            return Ok(user);
        }
    }
}
