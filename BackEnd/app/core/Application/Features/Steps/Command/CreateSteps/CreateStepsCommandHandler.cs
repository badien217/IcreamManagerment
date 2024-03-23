using Application.Bases;
using Application.Features.Books.BookRule;
using Application.Features.Feedbacks.Command.CreateFeedbacks;
using Application.Interfaces.AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Steps.Command.CreateSteps
{
    public class CreateStepsCommandHandler : BaseHandler, IRequestHandler<CreateStepsCommandRequest,Unit>
    {

        public readonly IUnitOfWork _unitOfWork;
        public CreateStepsCommandHandler(IUnitOfWork unitOfWork, IAutoMapper mapper, IHttpContextAccessor httpContextAccessor, BookRules bookRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            

        }
        
        public async System.Threading.Tasks.Task<Unit> Handle(CreateStepsCommandRequest request, CancellationToken cancellationToken)
        {
            var steps = new Step {Content = request.Content,RecipeId = request.RecipeId };
            if (request.ImageUrl.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", request.ImageUrl.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await request.ImageUrl.CopyToAsync(stream);


                }
                steps.ImageUrl = "/image/" + request.ImageUrl.FileName;
            }
            await _unitOfWork.GetWriteReponsitory<Step>().AddAsync(steps);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}

   

