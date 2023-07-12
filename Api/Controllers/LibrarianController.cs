using Application.Services;
using CoreLayer.Models;
using CoreLayer.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Controllers
{
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianService _librarianService;
        public LibrarianController(ILibrarianService librarianService)
        {
                _librarianService = librarianService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("/librarians/add")]
        public void AddLibrarian(Librarian librarian)
        {
            _librarianService.AddLibrarian(librarian);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("/librarians/Update")]
        public void UpdateLibrarian(int librariantoupdateId,Librarian librarian)
        {
            _librarianService.UpdateLibrarian(librariantoupdateId, librarian);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/librarians/remove")]
        public void RemoveLibrarian(int idtodelete)
        {
            _librarianService.RemoveLibrarian(idtodelete);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("/librarians/getinfo")]
        public void GetLibrariandetails(int id)
        {
            _librarianService.GetLibrarianDetails(id);
        }
    }
}
