
using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.queries.GetAll
{
    public class GetAllBookQueryRequest : IRequest<IList<GetAllBookQueryReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllBook";

        public double CacheTime => 60;
    }
}
