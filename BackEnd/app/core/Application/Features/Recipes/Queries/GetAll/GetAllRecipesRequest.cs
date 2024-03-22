using Application.Features.Feedbacks.Queries.GetAll;
using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Recipes.Queries.GetAll
{
    public class GetAllRecipesRequest : IRequest<IList<GetAllRecipesReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllRecipes";

        public double CacheTime => 60;
    }
}
