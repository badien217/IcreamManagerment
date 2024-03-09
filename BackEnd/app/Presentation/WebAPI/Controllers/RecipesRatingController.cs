using Application.Features.Books.command.CreateBook;
using Application.Features.Books.queries.GetAll;
using Application.Features.Books.queries.GetById;
using Application.Features.RecipesRating.Command.CreateRecipesRating;
using Application.Features.RecipesRating.Queries.GetAllRecipesRating;
using Application.Features.RecipesRating.Queries.GetAVGRecipteRating;
using Application.Features.RecipesRating.Queries.GetByIdRecipesRating;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipesRatingController :ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public RecipesRatingController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRatingRecipes()
        {
            var response = await mediator.Send(new GetAllRecipesRatingRequest());
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipesRating(CreateRecipesRatingRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> GetAVGRecipesById(GetAVGRecipesRatingRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpPost]

        public async Task<IActionResult> GetRecipesRatingById(GetByIdRecipesRatingRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
    }
}
