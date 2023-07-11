using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreLayer.ServicesInterfaces;
using Application.Services;
using CoreLayer.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Api.Controllers
{

    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingService _boorrowingService;
        public BorrowingController(IBorrowingService borrowingService)
        {
            _boorrowingService = borrowingService;
        }

        [Authorize(Roles = "User")]
        [HttpPost("/borrowing/borrow")]
        public void BorrowBook(int  bookid)
        {
            _boorrowingService.BorrowBook(bookid);
        }
        [Authorize(Roles = "User")]
        [HttpPost("/borrowing/return")]
        public void ReturnBook(Borrowing borrow)
        {
            _boorrowingService.ReturnBook(borrow);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("/borrowing/listoverdate")]
        public string ListOverDate()
        {
            return _boorrowingService.ListOverDate();
        }
    }
}
