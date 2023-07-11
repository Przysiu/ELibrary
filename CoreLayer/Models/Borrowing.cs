using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Borrowing
    {
        public int BorrowingId { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;
        public int Bookid { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        //user
        //book

    }
}
