using CoreLayer.ServicesInterfaces;
using CoreLayer.EFInterfaces;
using CoreLayer.Models;
using System.Text.Json;
namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
                this.bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            bookRepository.AddBook(book);
        }

        public void EditBook(Book book)
        {
            bookRepository.EditBook(book);
        }

        public string ListBooks()
        {
            return JsonSerializer.Serialize(bookRepository.ListBooks());
        }

        public void RemoveBook(int bookid)
        {
            bookRepository.RemoveBook(bookid);
        }
    }
}
