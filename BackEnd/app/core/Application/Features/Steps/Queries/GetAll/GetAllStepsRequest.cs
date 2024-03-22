using Application.Features.Feedbacks.Queries.GetAll;
using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Steps.Queries.GetAll
{
    public class GetAllStepsRequest : IRequest<IList<GetAllStepsReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllSteps";

        public double CacheTime => 60;
    }
}
