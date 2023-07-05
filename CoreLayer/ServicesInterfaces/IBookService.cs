using CoreLayer.EFInterfaces;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ServicesInterfaces
{
    public interface IBookService
    {
        public void AddBook(Book book);
        public void RemoveBook(int bookid);
        public void EditBook(Book book);
        public string ListBooks();

    }
}
