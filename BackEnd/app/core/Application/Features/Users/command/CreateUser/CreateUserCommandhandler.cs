using Domain.Entities;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.command.CreateUser
{
    public class CreateuserCommandHandler : IRequestHandler<CreateUsedCommandRequest>
    {
        public IUnitOfWork _unitOfWork;
        public CreateuserCommandHandler() { }
        public CreateuserCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

        }

        public async System.Threading.Tasks.Task Handle(CreateUsedCommandRequest request, CancellationToken cancellationToken)
        {
            Book userCustomer = new(request.Username, request.Password, request.phone, request.Email, request.SubcriptionType,
                request.PaymentStatus, request.RoleId);
            await _unitOfWork.GetWriteReponsitory<Book>().AddAsync(userCustomer);
            await _unitOfWork.SaveAsync();
            /*if (await _unitOfWork.SaveAsync() > 0)
            {
                await _unitOfWork.GetWriteReponsitory<Role>().AddAsync(new()
                {
                    User = userCustomer,


                });
                await _unitOfWork.SaveAsync();

            }*/
        }
    }
}
