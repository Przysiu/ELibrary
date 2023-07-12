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
    public class LibraryDatabaseContext : IdentityDbContext<UserEntity, UserRole, int>, IBookRepository, IAuthorRepository,IBorrowingRepository,ILibrarianRepository
    {
        public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Author>().HasMany(author => author.Books).WithMany(book => book.Authors);
            builder.Entity<Borrowing>().HasOne(book => book.Book).WithMany(x => x.borrowings);
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Borrowing> Borrowings { get; set; }
        public virtual DbSet<Librarian> Librarians { get; set; }

        public void AddBook(Book book)
        {
           // Console.WriteLine(book.Authors[0].AuthorId);
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

        public void BorrowBook(int bookid)
        {
            Borrowing borrow= new Borrowing();
            borrow.BorrowingDate=DateTime.Now;
            borrow.ReturnDate = borrow.BorrowingDate.AddMonths(4);
            borrow.Book= this.Books.Find( bookid);
            this.Borrowings.Add(borrow);
            this.SaveChanges();
        }

        public void ReturnBook(Borrowing bookreturn)
        {
            var toreturn =this.Borrowings.Find(bookreturn.BorrowingId);
            toreturn.IsReturned= true;
            this.Borrowings.Update(toreturn);
            this.SaveChanges();

        }

        public List<Borrowing> ListOverDate()
        {
           return this.Borrowings.Where(x => x.ReturnDate < DateTime.Now).ToList();
            
        }

        public void AddBookToAuthor(int bookid, int authorid)
        {
            var book = this.Books.Find(bookid);
            var author = this.Authors.Find(authorid);
            if (!author.Books.Contains(book))
            {
                author.Books.Add(book);
                this.Update(author);
                this.SaveChanges();
            }
            
        }

        public void AddLibrarian(Librarian librarian)
        {
            this.Librarians.Add(librarian);
            this.SaveChanges();
        }

        public void RemoveLibrarian(int librarianId)
        {
            this.Librarians.Remove(this.Librarians.Find(librarianId));
            this.SaveChanges();
        }

        public Librarian GetLibrarianDetails(int librarianid)
        {
            return this.Librarians.Find(this.Librarians.Find(librarianid));
        }

        public void UpdateLibrarian(int id, Librarian librarian)
        {
            Console.WriteLine(id);
            Console.WriteLine(librarian.Name);
            var librariantoupdate = this.Librarians.Find(id);
            librariantoupdate = librarian;
            this.Librarians.Update(librariantoupdate);
            this.SaveChanges();

        }
    }
}
