using Application.Features.Feedbacks.Command.UpdateFeedbacks;
using Application.Interfaces.AutoMapper;
using Domain.Entities;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Recipes.Command.UpdateRecipes
{
    public class UpdateRecipesCommandHandler : IRequestHandler<UpdateRecipesCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAutoMapper _autoMapper;
        public UpdateRecipesCommandHandler(IUnitOfWork unitOfWork, IAutoMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(UpdateRecipesCommandRequest request, CancellationToken cancellationToken)
        {
            var recipes = await _unitOfWork.GetReadReponsitory<Recipe>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = _autoMapper.Map<Recipe, UpdateRecipesCommandRequest>(request);
            if (request.ImageURL.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", request.ImageURL.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await request.ImageURL.CopyToAsync(stream);


                }
                map.ImageURL = "/image/" + request.ImageURL.FileName;
            }
            await _unitOfWork.GetWriteReponsitory<Recipe>().UpdateAsync(recipes);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
