using CoreLayer.EFInterfaces;
using CoreLayer.Models;
using CoreLayer.ServicesInterfaces;
using Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreLayer.Infrastructure
{
    public class LibraryDatabaseContext : IdentityDbContext<UserEntity, UserRole, int>, IBookRepository, IAuthorRepository
    {
        public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Author>().HasMany(author => author.Books).WithMany(book => book.Authors);

        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Borrowing> Borrowings { get; set; }

        public void AddBook(Book book)
        {
            
            this.Books.Add(book);
            this.SaveChanges();
        }

        public void EditBook(Book book)
        {
            this.Books.Update(book);
            this.SaveChanges();
        }

        public List<Book> ListBooks()
        {
            return this.Books.ToList();
        }

        public void RemoveBook(int bookid)
        {
            this.Books.Remove(this.Books.Find(bookid));
            this.SaveChanges();
        }

        public void AddAuthor(Author author)
        {
            this.Authors.Add(author);
            this.SaveChanges();
        }

        public void EditAuthor(Author author)
        {
            this.Authors.Update(author);
            this.SaveChanges();
        }

        public List<Author> GetAuthorList()
        {
            return this.Authors.ToList();
        }

        public List<Book> ListAuthorBooks(string name, string surname)
        {
            var authors = this.Authors.Where(x => x.Name == name && x.Surname == surname).ToList();
            List<Book> res = new List<Book>();
            foreach (var author in authors)
            {
                res.Concat(author.Books.ToList());
            }
            return res;
        }
    }
}
