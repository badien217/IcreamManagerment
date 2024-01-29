using Domain.Entities;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Command.DeleteFeedbacks
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommandRequest,Unit>
    {
        public readonly IUnitOfWork UnitOfWork;
        public DeleteFeedbackCommandHandler(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteFeedbackCommandRequest request, CancellationToken cancellationToken)
        {
            var feedback = await UnitOfWork.GetReadReponsitory<Feedback>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            if (!feedback.IsDeleted)
            {
                Console.WriteLine("khong co id");

            }
            else
            {
                feedback.IsDeleted = true;
            }
            await UnitOfWork.GetWriteReponsitory<Feedback>().UpdateAsync(feedback);
            await UnitOfWork.SaveAsync();
            return Unit.Value;

        }
    }
}
