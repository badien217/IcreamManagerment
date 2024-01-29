using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Queries.GetAll
{
    public class GetAllFeedbackRequest : IRequest<IList<GetAllFeedBackReponse>>
    {
    }
}
