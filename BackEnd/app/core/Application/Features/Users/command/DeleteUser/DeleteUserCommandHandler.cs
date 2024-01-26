using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.command.DeleteUser
{
    public class DeleteUserCommandHandler :  IRequestHandler<DeleteUserCommandRequest,Unit>
    {
        public readonly IUnitOfWork unitOfWork;
        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.GetReadReponsitory<User>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            users.IsDeleted = true;

            await unitOfWork.GetWriteReponsitory<User>().UpdateAsync(users);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
