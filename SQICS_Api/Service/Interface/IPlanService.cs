using SQICS_Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Interface
{
    public interface IPlanService
    {
        Task<PlanDTO> GetPlanByTransactionNoAsync(int transNo);

        Task<List<PlanDTO>> GetAllPlanAsync();

        Task AddNewPlanAsync();
    }
}
