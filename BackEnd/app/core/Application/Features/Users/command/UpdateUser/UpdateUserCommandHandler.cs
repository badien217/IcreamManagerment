using Application.Interfaces.AutoMapper;
using Domain.Entities;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandReuquest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAutoMapper _autoMapper;
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IAutoMapper autoMapper)
        {
            this._unitOfWork = unitOfWork;
            this._autoMapper = autoMapper;
        } 

        public async Task Handle(UpdateUserCommandReuquest request, CancellationToken cancellationToken)
        {

            var users = await _unitOfWork.GetReadReponsitory<User>().GetAsync(x => x.Id == request.Id  && !x.IsDeleted);
            
            
            var map = _autoMapper.Map<User, UpdateUserCommandReuquest>(request);
            var UserRole = await _unitOfWork.GetReadReponsitory<Role>().GetAsync(x => x.Id == users.Id );
            
            /*await _unitOfWork.GetWriteReponsitory<Role>().HardDeleteRangerAsync(UserRole);
            foreach (var RoleIds in request.RoleId) 
                await _unitOfWork.GetWriteReponsitory<Role>().AddAsync(new() { Id = RoleIds ,UserID = users.Id});*/
            await _unitOfWork.GetWriteReponsitory<Book>().UpdateAsync(users);
            await _unitOfWork.SaveAsync();

        }
    }
}
