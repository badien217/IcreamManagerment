using Application.Features.Books.command.CreateBook;
using Application.Features.Books.queries.GetAll;
using Application.Features.Orders.Command.CreateOrder;
using Application.Features.Orders.Command.DeleteOrder;
using Application.Features.Orders.Command.UpdateOrder;
using Application.Features.Orders.Queries.GetAll;
using Application.Features.Orders.Queries.GetOrderByDate;
using Application.Features.Orders.Queries.GetOrderById;
using Application.Features.Orders.Queries.GetTotal;
using Application.Features.RecipesRating.Queries.GetByIdRecipesRating;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public OrderController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllOrder()
        {
            var response = await mediator.Send(new GetAllOrderRequest());
            return Ok(response);

        }
        [HttpPost]

        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPost]
      
        public async Task<IActionResult> DeleteOrder(DeleteOrderCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> GetOrderByDate(GetOrderByDateRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpPost]

        public async Task<IActionResult> GetOrderById(GetOrderByIdRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpGet]

        public async Task<IActionResult> GetTotal()
        {
            var response = await mediator.Send(new GetTotalOrderRequest());
            return Ok(response);

        }
    }
}
