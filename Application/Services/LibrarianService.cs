using CoreLayer.EFInterfaces;
using CoreLayer.Models;
using CoreLayer.ServicesInterfaces;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository librarianRepository;
        public LibrarianService(ILibrarianRepository librarianRepository)
        {
                this.librarianRepository = librarianRepository;
        }
        public void AddLibrarian(Librarian librarian)
        {
            librarianRepository.AddLibrarian(librarian);
        }

        public string GetLibrarianDetails(int librarianid)
        {
            return JsonSerializer.Serialize(librarianRepository.GetLibrarianDetails(librarianid));
        }

        public void RemoveLibrarian(int librarianId)
        {
            librarianRepository.RemoveLibrarian(librarianId);
        }

        public void UpdateLibrarian(int id, Librarian librarian)
        {
            librarianRepository.UpdateLibrarian(id, librarian);
        }
    }
}
