using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.SampleWebAPI.Web.ViewModels;
using Binus.WebAPI.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class BookController : Controller
    {
        
        public ActionResult Index()
        {
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/GetAllBook",REST.Method.GET)).Result;

                HomeViewModel hvm = new HomeViewModel();
                hvm.books = Result.Deserialize<List<BookModel>>();

                return View("index", hvm);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertBook(BookModel model)
        {
            JsonResult RetData = new JsonResult();
            try
            {
                if(model.BookID != 0)
                {
                    RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/UpdateBook", REST.Method.POST, model)).Result;

                    if (Result.Success)
                    {
                        RetData = Json(new
                        {
                            Status = "Success",
                            URL = Global.BaseURL + "/Book"
                        });
                    }
                    else
                    {
                        RetData = Json(new
                        {
                            Status = "Failed",
                            Message = "Failed when updating data.."
                        });
                    }
                }
                else
                {
                    RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/InsertBookWithModel",REST.Method.POST,model)).Result;

                    if (Result.Success)
                    {
                        RetData = Json(new {
                            Status = "Success",
                            URL = Global.BaseURL + "/Book"
                        });
                    }
                    else
                    {
                        RetData = Json(new {
                            Status = "Failed",
                            Message = "Failed When Inserting Data.."
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                RetData = Json(new {
                    Status = "Failed",
                    Message = ex.Message
                });
            }

            return RetData;
        }

        public ActionResult Edit(BookModel model)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/GetOneBook?BookID=" + model.BookID, REST.Method.GET)).Result;

                if (Result.Success)
                {
                    retData = Json(new
                    {
                        Status = "Success",
                        Data = Result.Deserialize<BookModel>()
                    });
                }
                else
                {
                    retData = Json(new
                    {
                        Status = "Failed",
                        Message = "Failed when getting data.."
                    });
                }
            }
            catch (Exception ex)
            {
                retData = Json(new
                {
                    Status = "Failed",
                    Message = ex.Message
                });
            }
            return retData;
        }

        public ActionResult Delete(BookModel Model)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/DeleteBook", REST.Method.POST, Model)).Result;

                if (Result.Success)
                {
                    retData = Json(new
                    {
                        Status = "Success",
                        URL = Global.BaseURL + "/Book"
                    });
                }
                else
                {
                    retData = Json(new
                    {
                        Status = "Failed",
                        Message = "Failed When Deleting Data.."
                    });
                }
            }
            catch (Exception ex)
            {
                retData = Json(new
                {
                    Status = "Failed",
                    Message = ex.Message
                });
            }
            return retData;
        }

        public ActionResult BorrowIndex()
        {
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/BorrowIndex", REST.Method.GET)).Result;

                HomeViewModel hvm = new HomeViewModel();
                hvm.borrow = Result.Deserialize<List<BorrowModel>>();

                return View("borrow", hvm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Borrow(BookModel model)
        {
            JsonResult RetData = new JsonResult();
            try
            {
                if (model.BookQty > 0)
                {
                    RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/Borrow", REST.Method.POST, model)).Result;

                    if (Result.Success)
                    {
                        RetData = Json(new
                        {
                            Status = "Success",
                            URL = Global.BaseURL + "/Book"
                        });
                    }
                    else
                    {
                        RetData = Json(new
                        {
                            Status = "Failed",
                            Message = "Failed When Inserting Data.."
                        });
                    }
                }
                else
                {
                    RetData = Json(new
                    {
                        Status = "Failed",
                        Message = "The Book is not available!"
                    });
                }

            }
            catch (Exception ex)
            {
                RetData = Json(new
                {
                    Status = "Failed",
                    Message = ex.Message
                });
            }

            return RetData;
        }

    }
}