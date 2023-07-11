using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.EFInterfaces
{
    public interface IAuthorRepository
    {
        public void AddAuthor(Author author);
        public void EditAuthor(Author author);

        public List<Author> GetAuthorList();
        public List<Book> ListAuthorBooks(string name, string surname);
        public void AddBookToAuthor(int bookid,int authorid);

    }
}
