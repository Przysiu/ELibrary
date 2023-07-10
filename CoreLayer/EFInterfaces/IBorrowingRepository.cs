using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.EFInterfaces
{
    public interface IBorrowingRepository
    {
        public void BorrowBook(Borrowing borrow);
        public void ReturnBook(Borrowing bookreturn);

        public List<Borrowing> ListOverDate();

    }
}
