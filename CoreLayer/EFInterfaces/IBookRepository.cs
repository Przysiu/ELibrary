using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.EFInterfaces
{
    public interface IBookRepository
    {
        public void AddBook(Book book);
        public void RemoveBook(int bookid);
        public void EditBook(Book book);
        public List<Book> ListBooks( );
    }
}
