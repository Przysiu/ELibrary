using CoreLayer.Models;
using CoreLayer.ServicesInterfaces;
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

        [HttpPost("/authors/add")]
        public void Addauthor(Author author)
        {
            _authorService.AddAuthor(author);
        }
        [HttpGet("/authors/getauthors")]
        public string GetAuthors()
        {
            return _authorService.ListAuthors();

        }
        [HttpGet("/authors/getauthorbooks")]
        public string GetAuthorBooks(string namesurname)
        {
            return _authorService.ListAuthorBooks(namesurname);
        }
        [HttpPost("/authors/updateauthor")]
        public void UpdateAuthor(Author author)
        {
            _authorService.EditAuthor(author);
        }
        
    }
}
