using SQICS_Api.DTOs;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service
{
    public class PlanService : IPlanService
    {
        IUnitOfWork _uow;

        public PlanService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Task AddNewPlanAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PlanDTO>> GetAllPlanAsync()
        {
            var transactions = await _uow.Transaction.GetAllTransactionAsync();
            var subAssies = await _uow.SubAssy.GetAllSubAssyAsync();

            var result = (from t in transactions
                         join s in subAssies on t.fld_assyId equals s.fld_id
                         select new PlanDTO
                         {
                             Id = t.fld_id,
                             TransactionNo = t.fld_transactionNo,
                             SubAssyCode = s.fld_partCode,
                             SubAssyName = s.fld_partName,
                             Qty = t.fld_qty,
                             ETimeCompletion = t.ETimeCompletion
                         }).ToList();

            return result;
        }

        public async Task<PlanDTO> GetPlanByTransactionNoAsync(int? transNo)
        {
            var transaction = await _uow.Transaction.GetTransactionByTransNoAsync(transNo);

            if (transaction is null) throw new NullReferenceException("Transaction Not Found");

            var subAssy = (await _uow.SubAssy.GetAllSubAssyAsync())
                .Where(s => s.fld_id == transaction?.fld_assyId).SingleOrDefault();

            var plan = new PlanDTO
            {
                Id = transaction.fld_id,
                TransactionNo = transaction.fld_transactionNo,
                SubAssyCode = subAssy.fld_partCode,
                SubAssyName = subAssy.fld_partName,
                Qty = transaction.fld_qty,
                ETimeCompletion = transaction.ETimeCompletion
            };

            return plan;
        }
    }
}
