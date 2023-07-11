using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ServicesInterfaces
{
    public interface IAuthorService
    {
        public void AddAuthor(Author book);       
        public void EditAuthor(Author book);
        public string ListAuthors();
        public string ListAuthorBooks(string authorNameSurname );
        public void AddBookToAuthor(int bookid, int authorid);
    }
}
