using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface ITransactionHeaderRepository
    {
        Task AddHeaderAsync(tbl_t_transaction_header header);

        Task GetHeadersByTransNoAsync(string transNo);
    }
}
