using CoreLayer.Models;
using CoreLayer.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("/books/add")]
        public void AddBook(Book book)
        {
            _bookService.AddBook(book);
        }

        [HttpGet("/books/getall")]
        public string ListBooks() 
        { 
        return _bookService.ListBooks();
        }

        [HttpPost("/book/editbook")]
        public void UpdateBook(Book book)
        {
            _bookService.EditBook(book);
        }
        [HttpDelete("/book/deletebook")]
        public void DeleteBook(int bookid)
        {
            _bookService.RemoveBook(bookid);
        }
        
    }
}
