using CoreLayer.Models;
using CoreLayer.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace Api.Controllers
{

    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }

        [Authorize(Roles = "User")]
        [HttpPost("/authors/add")]
        public void Addauthor(Author author)
        {
            _authorService.AddAuthor(author);
        }

        [Authorize(Roles = "User")]
        [HttpGet("/authors/getauthors")]
        public string GetAuthors()
        {
            return _authorService.ListAuthors();

        }

        [Authorize(Roles = "User")]
        [HttpGet("/authors/getauthorbooks")]
        public string GetAuthorBooks(string namesurname)
        {
            return _authorService.ListAuthorBooks(namesurname);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("/authors/updateauthor")]
        public void UpdateAuthor(Author author)
        {
            _authorService.EditAuthor(author);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("/authors/addbooktoauthor")]
        public void AddBookToAuthor(int bookid,int authorid)
        {
            _authorService.AddBookToAuthor(bookid,authorid);
        }
    }
}
