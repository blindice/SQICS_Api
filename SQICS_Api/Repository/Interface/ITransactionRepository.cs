using SQICS_Api.DTOs;
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

        Task<IEnumerable<tbl_t_transaction>> GetTransactionsByTransNoAsync(string transNo);

        Task<tbl_t_transaction> GetTransactionByIdAsync(int Id);

        Task AddTransactionAsync(tbl_t_transaction trans);

        Task<string> GenerateTransactionNoAsync();

        Task<string> GenerateLotNoAsync(int supplierId, int lineId);

        Task AddPlansAsync(List<tbl_t_transaction> transactions);

        Task<IEnumerable<CurrentPlanDTO>> GetCurrentPlansAsyncByLineId(int lineId);

        void UpdateTransaction(tbl_t_transaction transaction);

        void UpdateTransactions(IEnumerable<tbl_t_transaction> transactions);

        Task<int?> GetTransactionIdByAssyLotAsync(string assyLot);
    }
}
