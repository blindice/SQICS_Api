using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Helper.CustomException;
using SQICS_Api.Helper.POCO;
using SQICS_Api.Model;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Plan
{
    public class PlanService : IPlanService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PlanService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddNewPlanAsync(AddPlanDTO plan)
        {
            var subAssyDdl = _mapper.Map<tbl_t_transaction>(plan);
            subAssyDdl.fld_createdDate = DateTime.Now;
            subAssyDdl.fld_transactionNo = await GenerateTransactionNo();

            await _uow.Transaction.AddTransactionAsync(subAssyDdl);
            await _uow.SaveAsync();
        }

        public async Task<List<SubAssyDDLDTO>> GetAllSubAssyDDLAsync()
        {
            var subAssies =  await _uow.SubAssy.GetAllSubAssyAsync();
            var subAssyDdl = _mapper.Map<List<SubAssyDDLDTO>>(subAssies);

            return subAssyDdl;
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

        public async Task<List<PlanDTO>> GetPlanByFilters(SearchParameters parameters)
        {
            var transactions = (await _uow.Transaction.GetAllTransactionAsync()).AsQueryable();

            if (transactions is null) throw new CustomException("Plan Not Found!");

            var filteredTrans = transactions
                .Where(t => t.fld_transactionNo.Contains(parameters.TransactionNo));

            var subAssy = (await _uow.SubAssy.GetAllSubAssyAsync()).AsQueryable();

            var plan = (from t in filteredTrans
                       join s in subAssy
                       on t.fld_assyId equals s.fld_id
                       select new PlanDTO
                       {
                           Id = t.fld_id,
                           TransactionNo = t.fld_transactionNo,
                           SubAssyCode = s.fld_partCode,
                           SubAssyName = s.fld_partName,
                           Qty = t.fld_qty,
                           ETimeCompletion = t.ETimeCompletion
                       }).ToList();

            return plan;
        }

        private async Task<string> GenerateTransactionNo()
        {
            return await _uow.Transaction.GenerateTransactionNoAsync();
        }
    }
}
