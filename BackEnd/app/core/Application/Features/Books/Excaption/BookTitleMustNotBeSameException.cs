using Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Excaption
{
    public class BookTitleMustNotBeSameException : BaseException
    {
        public BookTitleMustNotBeSameException() : base("exception!!!") { }
    }
}
