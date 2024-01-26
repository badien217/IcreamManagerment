using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using Domain.Entities;
using Application.Interfaces.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Dtos;

namespace Application.Features.Users.queries.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, IList<GetAllUserQueryReponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAutoMapper _mapper;
        public GetAllUserQueryHandler(IUnitOfWork unitOfWork, IAutoMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllUserQueryReponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.GetReadReponsitory<User>().GetAllAsync(include: x => x.Include(b => b.role));
            var rolers = _mapper.Map<RoleDto,Role>(new Role());
            
            var map = _mapper.Map<GetAllUserQueryReponse, User>(users);
            return map;
        }
    }
}
