using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.EFInterfaces
{
    public interface ILibrarianRepository
    {
        public void AddLibrarian(Librarian librarian);
        public void RemoveLibrarian(int librarianId);
        public Librarian GetLibrarianDetails(int librarianid);
        public void UpdateLibrarian(int id, Librarian librarian);
    }
}
