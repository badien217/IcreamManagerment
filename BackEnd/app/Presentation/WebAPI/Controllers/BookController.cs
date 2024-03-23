using Application.Features.Books.command.CreateBook;
using Application.Features.Books.command.DeleteBook;
using Application.Features.Books.command.UpdateBook;
using Application.Features.Books.queries.GetAll;
using Application.Features.Books.queries.GetById;
using Application.Features.Books.queries.GetByTitle;
using Application.Features.Books.queries.GetTotal;
using Application.Features.Feedbacks.Command.CreateFeedbacks;
using Application.Features.Feedbacks.Command.DeleteFeedbacks;
using Application.Features.Feedbacks.Command.UpdateFeedbacks;
using Application.Features.Feedbacks.Queries.GetById;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Serilog;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public BookController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllBook()
        {
            var response = await mediator.Send(new GetAllBookQueryRequest());
            
            return Ok(response);

        }

        [HttpPost]
       // [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookCommandRequest requeste)
        {
             await mediator.Send(requeste);
            
            return Ok();
        }
        [HttpPut("id")]
       // [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateBook([FromForm]  UpdateBookCommandReuquest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
       // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBook(DeleteBookCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> GetBookById(GetByIdCommandRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpPost]

        public async Task<IActionResult> GetBookByTitle(GetByTitleBookQueriesRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpGet]

        public async Task<IActionResult> GetTotalBook()
        {
            var response = await mediator.Send(new GetTotalBookRequest());
            return Ok(response);
        }

    } 
}
