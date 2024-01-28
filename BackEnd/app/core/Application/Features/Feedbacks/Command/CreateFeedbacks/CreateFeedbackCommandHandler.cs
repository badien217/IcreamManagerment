using Domain.Entities;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Command.CreateFeedbacks
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommandRequest>
    {
        public readonly IUnitOfWork _unitOfWork;
        public CreateFeedbackCommandHandler(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
        }
        public CreateFeedbackCommandHandler() { }
        public async System.Threading.Tasks.Task Handle(CreateFeedbackCommandRequest request, CancellationToken cancellationToken)
        {
            Feedback feedback = new(request.Name, request.Email, request.Phone, request.FeedbackContent, request.FeedbackDate);
            await _unitOfWork.GetWriteReponsitory<Feedback>().AddAsync(feedback);
            await _unitOfWork.SaveAsync();
        }
    }
}
