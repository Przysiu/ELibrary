using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ServicesInterfaces
{
    public  interface ILibrarianService
    {
        public void AddLibrarian(Librarian librarian);
        public void RemoveLibrarian(int librarianId);
        public string GetLibrarianDetails(int librarianid);
        public void UpdateLibrarian(int id, Librarian librarian);

    }
}
