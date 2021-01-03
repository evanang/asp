using Binus.SampleWebAPI.Data.Infrastructures.Base.MSSQL;
using Binus.SampleWebAPI.Data.Infrastructures.Training.MSSQL;
using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Data.Repositories.Training.BookDB.MSSQL.App
{
    public interface IBorrowRepository : IMSSQLRepository<BorrowModel> { }

    public class BorrowRepository : BookDBMSSQLRepositoryBase<BorrowModel>, IBorrowRepository
    {
        public BorrowRepository(BookDBMSSQLIDBFactory DBFactory) : base(DBFactory)
        {
        }
    }

}
