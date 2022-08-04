using SQICS_Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface IStationRepository
    {
        Task<StationDDLDTO> GetStationDDLBySupplierIdAsync(int supplierId);
    }
}
