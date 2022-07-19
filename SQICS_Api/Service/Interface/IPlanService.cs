using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Interface
{
    public interface IPlanService
    {
        Task<PlanDTO> GetPlanByTransactionNoAsync(string transNo);

        Task<List<PlanDTO>> GetAllPlanAsync();

        Task AddNewPlanAsync(AddPlanDTO plan);

        Task<List<SubAssyDDLDTO>> GetAllSubAssyDDLAsync();
    }
}
