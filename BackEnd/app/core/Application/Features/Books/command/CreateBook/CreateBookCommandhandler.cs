using Application.Features.Books.BookRule;
using Application.Features.Books.Exception;
using Domain.Entities;
using MediatR;
using persistence.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.command.CreateBook
{
    public class CreateBookCommandhandler : IRequestHandler<CreateBookCommandRequest,Unit>
    {
        public IUnitOfWork _unitOfWork;
        public BookRules BookRules;

        public CreateBookCommandhandler() { }
        public CreateBookCommandhandler(IUnitOfWork unitOfWork,BookRules book)
        {
            _unitOfWork = unitOfWork;
            BookRules = book;
        }
        public async System.Threading.Tasks.Task<Unit> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Book> books = await _unitOfWork.GetReadReponsitory<Book>().GetAllAsync();
            await BookRules.BookTitleMostNotBeSame(books, request.Title);
            
            var bookCustomer = new Book {Title = request.Title,Author = request.Author,PublishedDate= request.PublishedDate,Price = request.Price,Quantity = request.quatity };
            if (request.ImageUrl.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", request.ImageUrl.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await request.ImageUrl.CopyToAsync(stream);


                }
                bookCustomer.ImageUrl = "/image/" + request.ImageUrl.FileName;
            }
            await _unitOfWork.GetWriteReponsitory<Book>().AddAsync(bookCustomer);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
            
        }
    }
}


