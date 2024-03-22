using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.queries.GetAll
{
    public class GetAllProductRequest : IRequest<IList<GetAllProductReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllProduct";

        public double CacheTime => 60;
    }
}
