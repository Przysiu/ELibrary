using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ServicesInterfaces
{
    public interface IBorrowingService
    {
        public void BorrowBook(Borrowing borrow);
        public void ReturnBook(Borrowing bookreturn);
        public string ListOverDate();
    }
}
