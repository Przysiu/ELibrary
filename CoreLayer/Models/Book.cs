using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        public int PublicationYear { get; set; }
        public string Publisher { get; set; }
        //authors
        public List<Author> Authors { get; set; } = new();
        public List<Borrowing> borrowings { get; set; } = new();
    }
    public enum BookGenres
    {
        Genre1, Genre2, Genre3, Genre4, Genre5, Genre6, Genre7
    }

}
