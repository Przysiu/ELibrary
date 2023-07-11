using CoreLayer.EFInterfaces;
using CoreLayer.Models;
using CoreLayer.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public void AddAuthor(Author author)
        {
            authorRepository.AddAuthor(author);
            
        }

        public void EditAuthor(Author author)
        {
            authorRepository.EditAuthor(author);
        }

        public string ListAuthorBooks(string authorNameSurname)
        {
            var splitname =authorNameSurname.Split(' ');
            string authorSurname = splitname[0];
            string authorName = splitname[1];
            return JsonSerializer.Serialize(authorRepository.ListAuthorBooks(authorSurname, authorName));
        }

        public string ListAuthors()
        {
            return JsonSerializer.Serialize(authorRepository.GetAuthorList());
        }
        public void AddBookToAuthor(int bookid, int authorid)
        {
            this.AddBookToAuthor(bookid, authorid);
        }
    }
}
