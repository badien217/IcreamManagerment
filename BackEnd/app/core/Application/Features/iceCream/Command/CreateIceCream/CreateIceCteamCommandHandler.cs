using Application.Features.Feedbacks.Command.CreateFeedbacks;
using Domain.Entities;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.iceCream.Command.CreateIceCream
{
    public class CreateIceCteamCommandHandler : IRequestHandler<CreateIceCreamCommandRequest,Unit>
    {
        public readonly IUnitOfWork _unitOfWork;
        public CreateIceCteamCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CreateIceCteamCommandHandler() { }
        public async System.Threading.Tasks.Task<Unit> Handle(CreateIceCreamCommandRequest request, CancellationToken cancellationToken)
        {
            var icecrem = new IceCream {Name = request.Name,Flavorld = request.Flavorld};
            if (request.ImageUrl.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", request.ImageUrl.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await request.ImageUrl.CopyToAsync(stream);


                }
                icecrem.ImageUrl = "/image/" + request.ImageUrl.FileName;
            }

            await _unitOfWork.GetWriteReponsitory<IceCream>().AddAsync(icecrem);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}

