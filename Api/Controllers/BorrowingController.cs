using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreLayer.ServicesInterfaces;
using Application.Services;
using CoreLayer.Models;

namespace Api.Controllers
{

    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingService _boorrowingService;
        public BorrowingController(IBorrowingService borrowingService)
        {
            _boorrowingService = borrowingService;
        }
        [HttpPost("/borrowing/borrow")]
        public void BorrowBook(Borrowing borrow)
        {
            _boorrowingService.BorrowBook(borrow);
        }

        [HttpPost("/borrowing/return")]
        public void ReturnBook(Borrowing borrow)
        {
            _boorrowingService.ReturnBook(borrow);
        }
        [HttpGet("/borrowing/listoverdate")]
        public string ListOverDate()
        {
            return _boorrowingService.ListOverDate();
        }
    }
}
