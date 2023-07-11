using CoreLayer.EFInterfaces;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CoreLayer.ServicesInterfaces;

namespace Application.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepository borrowingRepository;
        public BorrowingService(IBorrowingRepository borrowingRepository)
        {
            this.borrowingRepository = borrowingRepository;
        }


        public void BorrowBook(int bookid)
        {
            borrowingRepository.BorrowBook(bookid);
        }

        public string ListOverDate()
        {
            return JsonSerializer.Serialize(borrowingRepository.ListOverDate());
        }

        public void ReturnBook(Borrowing bookreturn)
        {
            borrowingRepository.ReturnBook(bookreturn);
        }
    }
}
