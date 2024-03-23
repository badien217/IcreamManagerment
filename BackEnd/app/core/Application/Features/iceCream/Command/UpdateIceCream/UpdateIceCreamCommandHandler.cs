using Application.Features.Feedbacks.Command.UpdateFeedbacks;
using Application.Interfaces.AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.iceCream.Command.UpdateIceCream
{
    public class UpdateIceCreamCommandHandler : IRequestHandler<UpdateIceCreamCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAutoMapper _autoMapper;
        public UpdateIceCreamCommandHandler(IUnitOfWork unitOfWork, IAutoMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(UpdateIceCreamCommandRequest request, CancellationToken cancellationToken)
        {
            var icecream = await _unitOfWork.GetReadReponsitory<IceCream>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = _autoMapper.Map<IceCream, UpdateIceCreamCommandRequest>(request);
            if (request.ImageUrl.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", request.ImageUrl.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await request.ImageUrl.CopyToAsync(stream);


                }
                map.ImageUrl = "/image/" + request.ImageUrl.FileName;
            }
            await _unitOfWork.GetWriteReponsitory<IceCream>().UpdateAsync(icecream);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}


    

