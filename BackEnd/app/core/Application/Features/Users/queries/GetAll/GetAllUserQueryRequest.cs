using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.queries.GetAll
{
    public class GetAllUserQueryRequest : IRequest<IList<GetAllUserQueryReponse>>
    {

    }
}

