using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Transaction
{
    public class TransactionRepository : RepositoryBase<tbl_t_transaction>, ITransactionRepository
    {
        public TransactionRepository(SQICSContext context) : base(context){}

        public async Task<IEnumerable<tbl_t_transaction>> GetAllTransaction()
        {
            return await QueryAsync("select * from tbl_t_transactions");
        }
    }
}
