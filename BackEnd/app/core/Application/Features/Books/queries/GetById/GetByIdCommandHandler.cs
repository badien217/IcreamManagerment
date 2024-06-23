using Application.Bases;
using Application.Features.Auths.Rules;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.RedisCache;
using Application.Interfaces.Token;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using persistence.Interfaces.UnitOfWorks;

namespace Application.Features.Books.queries.GetById
{
    public class GetByIdCommandHandler : BaseHandler, IRequestHandler<GetByIdCommandRequest, GetByIdCommandReponse>
    {

        private readonly IConfiguration configuration;
        private readonly ITokenServices tokenService;
        private readonly AuthRule authRules;
        private readonly IRedisCache _Cache;
        private readonly IDistributedCache _client;

        public GetByIdCommandHandler(IConfiguration configuration, IRedisCache Cache,
            ITokenServices tokenService, AuthRule authRules, IAutoMapper mapper, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor, IDistributedCache client) : base(mapper, unitOfWork, httpContextAccessor)
        {

            this.configuration = configuration;
            this.tokenService = tokenService;
            this.authRules = authRules;
            this._Cache = Cache;
            this._client = client;
            
        }
        public async Task<GetByIdCommandReponse> Handle(GetByIdCommandRequest request, CancellationToken cancellationToken)
        {
            /*  var bookById = await unitOfWork.GetReadReponsitory<Book>().GetAsync(up => up.Id == request.id );


              if(bookById is null)
              {
                  return new GetByIdCommandReponse();
              }
              var reponse = new GetByIdCommandReponse();
              reponse.Title = bookById.Title;
              reponse.Author = bookById.Author;
              reponse.ImageUrl = bookById.ImageUrl;
              reponse.PublishedDate = bookById.PublishedDate;
              reponse.Price = bookById.Price;
              return reponse;
            */
            var book = await _Cache.GetAsync<GetByIdCommandReponse>(request.id);
            string key = "GetAllBook";
            var map = mapper.Map<GetByIdCommandReponse>(this._Cache.SetAsync(key, book));
            return map;

        }
       
    }
} 
