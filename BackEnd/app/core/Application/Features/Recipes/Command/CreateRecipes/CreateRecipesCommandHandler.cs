using Application.Features.Feedbacks.Command.CreateFeedbacks;
using Domain.Entities;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Recipes.Command.CreateRecipes
{
    public class CreateRecipesCommandHandler : IRequestHandler<CreateRecipesCommandRequest>
    {
        public readonly IUnitOfWork _unitOfWork;
        public CreateRecipesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CreateRecipesCommandHandler() { }
        public async System.Threading.Tasks.Task Handle(CreateRecipesCommandRequest request, CancellationToken cancellationToken)
        {
            var recip = new Recipe {Name= request.Name,Description = request.Description,SubMittedBy = request.SubMittedBy,Ingredients= request.Ingredients };
            if (request.ImageURL.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", request.ImageURL.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await request.ImageURL.CopyToAsync(stream);


                }
                recip.ImageURL = "/image/" + request.ImageURL.FileName;
            }
            await _unitOfWork.GetWriteReponsitory<Recipe>().AddAsync(recip);
            await _unitOfWork.SaveAsync();
        }
    }
}