using SQICS_Api.DTOs;
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
        public TransactionRepository(SQICSContext efContext, DapperContext dapperContext) 
            : base(efContext, dapperContext) {}

        public async Task AddTransactionAsync(tbl_t_transaction trans)
        {
            await AddAsync(trans);
        }

        public async Task<IEnumerable<tbl_t_transaction>> GetAllTransactionAsync()
        {
            return await QueryAsync("usp_GetAllTransactions");
        }

        public async Task<tbl_t_transaction> GetTransactionByIdAsync(int id)
        {
            return await QuerySingleOrDefaultAsync("usp_GetTransactionById", new { id = id });
        }

        public async Task<tbl_t_transaction> GetTransactionByTransNoAsync(string transNo)
        {
            return await QuerySingleOrDefaultAsync("usp_GetTransactionByTransNo", new { transNo = transNo });
        }

        public async Task<string> GenerateTransactionNoAsync()
        {
            return await QuerySingleOrDefaultAsync<string>("usp_GenerateTransactionNo");
        }

        public async Task<string> GenerateLotNoAsync(int supplierId, int lineId)
        {
            return await QuerySingleOrDefaultAsync<string>("usp_GenerateLotNo", new { supplierId = supplierId, lineId = lineId });
        }

        public async Task AddPlansAsync(List<tbl_t_transaction> transactions)
        {
            await AddRangeAsync(transactions);
        }

        public async Task<IEnumerable<CurrentPlanDTO>> GetCurrentPlansAsyncByLineId(int lineId)
        {
            return await QueryAsync<CurrentPlanDTO>("usp_GetCurrentPlan", new { lineId = lineId });
        }

        public void UpdateTransaction(tbl_t_transaction transaction)
        {
            Update(transaction);
        }
    }
}
