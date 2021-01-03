using Binus.SampleWebAPI.Data.Repositories.Training.BookDB.MSSQL.App;
using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Services.Training.BookDB.MSSQL.App
{
    public interface ILoginService
    {
        Task<UserModel> GetLoginData(UserModel Model);
    }

    public class LoginService : ILoginService
    {
        private readonly IUserRepository _UserRepository;

        public LoginService(IUserRepository _UserRepository)
        {
            this._UserRepository = _UserRepository;
        }

        public async Task<UserModel> GetLoginData(UserModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@UserName", Model.UserName),
                new SqlParameter("@Password", Model.Password)
            };

            UserModel User = (await _UserRepository.ExecSPToSingleAsync("bn_BookDB_GetLoginData @UserName, @Password", Param));
            return User;
        }
    }
}
