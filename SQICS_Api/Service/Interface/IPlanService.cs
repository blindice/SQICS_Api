using SQICS_Api.DTOs;
using SQICS_Api.Helper.POCO;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Interface
{
    public interface IPlanService
    {
        Task<SubAssyByOperatorIdDTO> GetOperatorDetailsAsync(string operatorId);

        Task<List<SubAssyDDLDTO>> GetSubAssyDdlDataAsync(int supplierId);

        Task<SubAssyDetailsDTO> GetSubAssyByCodeAsync(int supplierId, string subassyCode);

        Task<SubAssyDetailsDTO> GetSubAssyByNameAsync(int supplierId, string subAssyName);

        Task AddPlansAsync(List<AddPlanDTO> plansDTO);

        Task<List<CurrentPlanDTO>> GetCurrentPlansByLineIdAsync(int lineId);

        Task StartProcessAsync(AddOngoingDTO transaction);

        Task<List<LineDDLDTO>> GetLineDataAsync(int supplierId);


        Task<List<StationDDLDTO>> GetStationDataByLineAsync(int lineId);

        Task DeletePlanAsync(DeletePlanDTO field);

        Task<string> GetPiecePartnameAsync(ValidatePieceBySupplierDTO info);

        Task<string> GetSubAssyNameAsync(ValidateSubAssyBySupplierDTO info);

        Task AddAssyDefectAsync(AddAssyDefectDTO dto);

        Task<List<DefectDTO>> GetDefectDDLAsync();

        Task AddTransactionDetails(AddTransactionDetailsDTO details);

        Task<SubAssyLotDetailsDTO> GetSubAssyLotDetailsByLotAsync(string assyLot, int station);

        Task<int> GetCountByAssyLotAsync(string assyLot);

        Task TriggerIncrementCountAsync(string assyLot, int operatorId);

        Task UpdateOrCreatePartColorAsync(UpdateOrCreatePartColorDTO details);

        Task<List<PartCodeColorDTO>> GetColorsBySupplierIdAsync(int supplierId);
    }
}
