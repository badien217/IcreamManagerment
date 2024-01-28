using Application.Interfaces.AutoMapper;
using Domain.Entities;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Queries.GetAll
{
    public class GetAllFeedBacksHandler : IRequestHandler<GetAllFeedbackRequest,IList<GetAllFeedBackReponse>>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IAutoMapper _autoMapper;
        public GetAllFeedBacksHandler(IAutoMapper autoMapper, IUnitOfWork unitOfWork) {
        
            this._autoMapper = autoMapper;
            this._unitOfWork = unitOfWork;
         }

        public async Task<IList<GetAllFeedBackReponse>> Handle(GetAllFeedbackRequest request, CancellationToken cancellationToken)
        {
            var feedbacks = await _unitOfWork.GetReadReponsitory<Feedback>().GetAllAsync();
            var map = _autoMapper.Map<GetAllFeedBackReponse,Feedback>(feedbacks);
            return map;
        }
    }
}
