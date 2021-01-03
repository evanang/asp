using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.User;
using Binus.SampleWebAPI.Services.Training.BookDB.MSSQL.App;
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
    public class LoginController : ApiController
    {
        private readonly ILoginService _LoginService;

        public LoginController(ILoginService _LoginService)
        {
            this._LoginService = _LoginService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetLoginData(UserModel Model)
        {
            UserModel User = (await _LoginService.GetLoginData(Model));
            return Json(User);
        }
    }
}