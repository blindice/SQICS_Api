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
    }
}
