using Application.Bases;
using Application.Features.Users.Excaptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.BookRule
{
    public class BookRules : BaseRule
    {
        public Task BookTitleMostNotBeSame(IList<Book> book, string requestTitle)
        {

            if (book.Any(x => x.Username == requestTitle)) throw new UserTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
