using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _accessor;

        public PlanService(IUnitOfWork uow, IMapper mapper, IHttpContextAccessor accessor)
        {
            _uow = uow;
            _mapper = mapper;
            _accessor = accessor;
        }
        public async Task AddNewPlanAsync(AddPlanDTO plan)
        {
            var currUser = Convert.ToInt32(_accessor.HttpContext.User.Claims.First(c => c.Type == "id").Value);

            var subAssyDdl = _mapper.Map<tbl_t_transaction>(plan);
            subAssyDdl.fld_createdBy = currUser;
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
            var transactions = (await _uow.Transaction.GetAllTransactionAsync()).AsQueryable();

            var subAssies = (await _uow.SubAssy.GetAllSubAssyAsync()).AsQueryable();

            var result = (from t in transactions
                         join s in subAssies on t.fld_assyId equals s.fld_id
                         select new PlanDTO
                         {
                             Id = t.fld_transactionId,
                             TransactionNo = t.fld_transactionNo,
                             ProdDate = t.fld_prodDate,
                             Shift = t.fld_shiftId.ToString(),
                             SubAssyCode = s.fld_partCode,
                             SubAssyName = s.fld_partName,
                             Qty = t.fld_qty,
                             ETimeCompletion = t.ETimeCompletion
                         }).ToList();

            return result;
        }

        public async Task<List<PlanDTO>> GetPlanByFilters(string param)
        {
            var transactions = (await _uow.Transaction.GetAllTransactionAsync()).AsQueryable();

            if (transactions is null) throw new CustomException("Plan Not Found!");

            var subAssy = (await _uow.SubAssy.GetAllSubAssyAsync()).AsQueryable();

            var plan = (from t in transactions
                        join s in subAssy
                       on t.fld_assyId equals s.fld_id
                       where t.fld_transactionNo.Contains(param) || t.fld_prodDate.ToString().Contains(param)
                       || t.fld_shiftId.ToString().Contains(param) || s.fld_partCode.Contains(param)
                        select new PlanDTO
                       {
                           Id = t.fld_transactionId,
                           TransactionNo = t.fld_transactionNo,
                           ProdDate = t.fld_prodDate,
                           Shift = t.fld_shiftId.ToString(),
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
