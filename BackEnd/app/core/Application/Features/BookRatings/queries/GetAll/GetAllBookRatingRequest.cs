﻿using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookRatings.queries.GetAll
{
    public class GetAllBookRatingRequest : IRequest<IList<GetAllBookRatingReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllBookRating";

        public double CacheTime => 60;
    }
}
