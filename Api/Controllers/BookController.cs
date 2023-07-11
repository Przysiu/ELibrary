using CoreLayer.Models;
using CoreLayer.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("/books/add")]
        public void AddBook(Book book)
        {
            _bookService.AddBook(book);
        }
        [Authorize(Roles = "User")]
        [HttpGet("/books/getall")]
        public string ListBooks() 
        { 
        return _bookService.ListBooks();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("/book/editbook")]
        public void UpdateBook(Book book)
        {
            _bookService.EditBook(book);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("/book/deletebook")]
        public void DeleteBook(int bookid)
        {
            _bookService.RemoveBook(bookid);
        }
        
    }
}
