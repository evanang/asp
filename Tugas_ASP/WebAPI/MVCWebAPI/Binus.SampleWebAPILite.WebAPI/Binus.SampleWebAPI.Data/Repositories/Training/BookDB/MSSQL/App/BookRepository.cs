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
    public interface IBookRepository : IMSSQLRepository<BookModel> { }

    public class BookRepository : BookDBMSSQLRepositoryBase<BookModel>, IBookRepository
    {
        public BookRepository(BookDBMSSQLIDBFactory DBFactory) : base(DBFactory)
        {
        }
    }
}
