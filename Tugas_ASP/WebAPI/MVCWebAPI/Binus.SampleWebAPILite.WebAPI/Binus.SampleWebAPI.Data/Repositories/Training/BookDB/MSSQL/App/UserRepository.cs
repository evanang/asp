using Binus.SampleWebAPI.Data.Infrastructures.Base.MSSQL;
using Binus.SampleWebAPI.Data.Infrastructures.Training.MSSQL;
using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Data.Repositories.Training.BookDB.MSSQL.App
{
    public interface IUserRepository : IMSSQLRepository<UserModel> { }

    public class UserRepository : BookDBMSSQLRepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(BookDBMSSQLIDBFactory DBFactory) : base(DBFactory)
        {
        }
    }
}
