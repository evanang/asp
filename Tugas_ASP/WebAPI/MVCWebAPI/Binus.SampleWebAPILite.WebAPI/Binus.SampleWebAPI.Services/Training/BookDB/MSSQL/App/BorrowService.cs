using Binus.SampleWebAPI.Data.Repositories.Training.BookDB.MSSQL.App;
using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Services.Training.BookDB.MSSQL.App
{
    public interface IBorrowService
    {
        Task<List<BorrowModel>> BorrowIndex();
        Task<ExecuteResult> Borrow(BookModel Model);
    }

    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _BorrowRepository;
        public BorrowService(IBorrowRepository _BorrowRepository)
        {
            this._BorrowRepository = _BorrowRepository;
        }

        public async Task<List<BorrowModel>> BorrowIndex()
        {
            List<BorrowModel> listBorrow = (await _BorrowRepository.ExecSPToListAsync("bn_BookDB_BorrowIndex")).ToList();

            return listBorrow;
        }

        public async Task<ExecuteResult> Borrow(BookModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@BookID", Model.BookID),
                new SqlParameter("@BookName", Model.BookName),
                new SqlParameter("@BookDesc", Model.BookDesc)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_BookDB_Borrow @BookID, @BookName, @BookDesc",
                SQLParam = Param
            });

            ExecuteResult Result = (await _BorrowRepository.ExecMultipleSPWithTransactionAsync(Data));

            return Result;
        }

    }

}
