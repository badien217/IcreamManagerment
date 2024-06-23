using Application.Bases;
using Application.Features.Auths.Rules;
using Application.Features.Books.BookRule;
using Application.Features.Books.Exception;
using Application.Features.Books.queries.GetById;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.RedisCache;
using Application.Interfaces.Token;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.queries.GetByTitle
{
    public class GetByTitleBookQueriesHandler : BaseHandler,IRequestHandler<GetByTitleBookQueriesRequest, GetByTitleBookQueriesReponse>
    {
        private readonly IConfiguration configuration;
        private readonly ITokenServices tokenService;
        private readonly BookRules rules;
        private readonly IRedisCache _Cache;

        public GetByTitleBookQueriesHandler(IConfiguration configuration, IRedisCache Cache,
            ITokenServices tokenService, BookRules rules, IAutoMapper mapper, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {

            this.configuration = configuration;
            this.tokenService = tokenService;
            this.rules = rules;
            this._Cache = Cache;

        }
        public async Task<GetByTitleBookQueriesReponse> Handle(GetByTitleBookQueriesRequest request, CancellationToken cancellationToken)
        {
            /*var reponse = new GetByTitleBookQueriesReponse();
            IList<Book> boolAll = await unitOfWork.GetReadReponsitory<Book>().GetAllAsync();
            GetByTitleBookQueriesReponse bookTitleFromRedis = await _Cache.GetAsync<GetByTitleBookQueriesReponse>(request.Title);

            bool check = await rules.BookTitleNotFound(boolAll,request.Title);
            if (!bookTitleFromRedis.Title.IsNullOrEmpty())
            {
               
                
                return bookTitleFromRedis;
            }
            if (check)
            {
                var BookByTitle = await unitOfWork.GetReadReponsitory<Book>().GetAsync(up => up.Title == request.Title);
                var bookmee = _Cache.GetAsync<Book>(request.Title);
                if(BookByTitle is null)
                {
                    new GetByTitleBookQueriesReponse();
                }             
                reponse.Title = BookByTitle.Title; 
                reponse.Author = BookByTitle.Author;
                reponse.ImageUrl = BookByTitle.ImageUrl;
                reponse.PublishedDate = BookByTitle.PublishedDate;
                reponse.Price = BookByTitle.Price;   
                
            }
            else
            {
                new BookTitleNotFound();
            }
            
            return reponse;*/
            var book = await _Cache.GetAsync<GetByTitleBookQueriesReponse>(request.Title);
            string key = "GetAllBook";
            var map = mapper.Map<GetByTitleBookQueriesReponse>(this._Cache.SetAsync(key, book));
            return map;
        }
       
    }
}
