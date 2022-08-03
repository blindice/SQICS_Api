using SQICS_Api.Model;
using SQICS_Api.Repository.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<tbl_t_transaction>> GetAllTransactionAsync();

        Task<tbl_t_transaction> GetTransactionByTransNoAsync(string transNo);

        Task AddTransactionAsync(tbl_t_transaction trans);

        Task<string> GenerateTransactionNoAsync();

        Task<string> GenerateLotNoAsync(int supplierId, int lineId);

        Task AddPlansAsync(List<tbl_t_transaction> transactions);
    }
}
