using Application.Features.iceCream.Command.CreateIceCream;
using Application.Features.iceCream.Command.DeleteIceCream;
using Application.Features.iceCream.Command.UpdateIceCream;
using Application.Features.iceCream.Queries.GetAll;
using Application.Features.Recipes.Command.CreateRecipes;
using Application.Features.Recipes.Command.DeleteRecipes;
using Application.Features.Recipes.Command.UpdateRecipes;
using Application.Features.Recipes.Queries.GetAll;
using Application.Features.Recipes.Queries.GetTotal;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class IceCreamController : ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public IceCreamController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]

        public async Task<IActionResult> GetIceCreame()
        {
            var response = await mediator.Send(new GetAllIceCreamRequest());
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> CreateIceCreame([FromForm] CreateIceCreamCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> updateRecipes([FromForm] UpdateIceCreamCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRecipes(DeleteIceCreamCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }

        
    }

}
