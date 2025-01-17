﻿using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RecipesRating.Queries.GetAllRecipesRating
{
    public class GetAllRecipesRatingRequest : IRequest<IList<GetAllRecipesRatingReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllRecipesRating";

        public double CacheTime => 60;
    }
}
