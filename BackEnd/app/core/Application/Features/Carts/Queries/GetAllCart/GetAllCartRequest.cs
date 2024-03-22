using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Carts.Queries.GetAllCart
{
    public class GetAllCartRequest : IRequest<IList<GetAllCartReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllCart";

        public double CacheTime => 60;
    }
}
