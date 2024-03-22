using Application.Features.Feedbacks.Queries.GetAll;
using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.iceCream.Queries.GetAll
{
    public class GetAllIceCreamRequest : IRequest<IList<GetAllIceCreamReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllIceCream";

        public double CacheTime => 60;
    }
}
