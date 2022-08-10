using SQICS_Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Interface
{
    public interface IAssemblyService
    {
        Task<SubAssyByOperatorIdDTO> GetOperatorDetailsAsync(string operatorId);

        Task<List<SubAssyDDLDTO>> GetSubAssyDdlDataAsync(int supplierId);

        Task<SubAssyDetailsDTO> GetSubAssyByCodeAsync(int supplierId, string subassyCode);

        Task<SubAssyDetailsDTO> GetSubAssyByNameAsync(int supplierId, string subAssyName);

        Task AddPlansAsync(List<AddPlanDTO> plansDTO);

        Task<List<CurrentPlanDTO>> GetCurrentPlansByLineIdAsync(int lineId);

        Task StartProcessAsync(AddOngoingDTO transaction);

        Task<(List<StationDDLDTO>, List<LineDDLDTO>)> GetDDLDataAsync(int supplierId);

        Task DeletePlanAsync(DeletePlanDTO field);
    }
}
