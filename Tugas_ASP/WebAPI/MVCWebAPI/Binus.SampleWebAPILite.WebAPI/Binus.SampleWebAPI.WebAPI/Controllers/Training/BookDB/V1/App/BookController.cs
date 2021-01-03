using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.App;
using Binus.SampleWebAPI.Services.Training.BookDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using Binus.WebAPI.REST;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.BookDB.V1.App
{
    [ApiVersion("1.0")]
    [Authorize]
    public class BookController : ApiController
    {
        private readonly IBookService _BookService;
        private readonly IBorrowService _BorrowService;

        public BookController(IBookService _BookService, IBorrowService _BorrowService)
        {
            this._BookService = _BookService;
            this._BorrowService = _BorrowService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllBook()
        {
            List<BookModel> ListBook = (await _BookService.GetAllBook());

            return Json(ListBook);
        }

        [HttpGet]
        public IHttpActionResult GetOneBook(int BookID)
        {
            BookModel Model = _BookService.GetOneBook(BookID);

            return Json(Model);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertBook(string BookName, string BookDesc, int BookQty)
        {
            ExecuteResult Result = (await _BookService.InsertBook(BookName, BookDesc, BookQty));

            return Json(Result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertBookWithModel(BookModel Model)
        {
            ExecuteResult Result = (await _BookService.InsertBookWithModel(Model));

            return Json(Result);
        }

        [HttpPost]
        public IHttpActionResult DeleteBook(BookModel Model)
        {
            ExecuteResult Result = _BookService.DeleteBook(Model);

            return Json(Result);
        }

        [HttpPost]
        public IHttpActionResult UpdateBook(BookModel Model)
        {
            ExecuteResult Result = _BookService.UpdateBook(Model);

            return Json(Result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> BorrowIndex()
        {
            List<BorrowModel> ListBorrow = (await _BorrowService.BorrowIndex());

            return Json(ListBorrow);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Borrow(BookModel Model)
        {
            ExecuteResult Result = (await _BorrowService.Borrow(Model));

            return Json(Result);
        }
    }
}