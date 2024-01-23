using Application.Features.Users.command.CreateUser;
using Application.Features.Users.command.DeleteUser;
using Application.Features.Users.command.UpdateUser;
using Application.Features.Users.queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator mediator;
        public ValuesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var reponse = await mediator.Send(new GetAllUserQueryRequest());
            return Ok(reponse);
        }
        [HttpPost] 
        public async Task<IActionResult> CreateUser (CreateUsedCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandHandler requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUserCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
    }
}
