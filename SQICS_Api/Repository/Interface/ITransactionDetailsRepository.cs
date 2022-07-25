using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface ITransactionDetailsRepository
    {
        Task<IEnumerable<TransactionDetailsDTO>> GetTransactionDetailsByTransNoAsync(string transNo);

        Task AddTransactionDetailsAsync(tbl_t_transaction_detail transactionDetails);
    }
}
