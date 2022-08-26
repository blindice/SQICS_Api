using SQICS_Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Interface
{
    public interface IReprintService
    {
        Task<List<LotLabelDTO>> GetAllLotLabelAsync();

        Task PrintLotLabelAsync(UpdateLotLabelDTO details);
    }
}
