using SQICS_Api.DTOs;
using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository
{
    public class StationRepository : RepositoryBase<tbl_m_station>, IStationRepository
    {
        public StationRepository(SQICSContext efContext, DapperContext dapperContext)
    : base(efContext, dapperContext) { }
        public async Task<IEnumerable<StationDDLDTO>> GetStationDDLByLineIdAsync(int lineId)
        {
            var stations = await QueryAsync<StationDDLDTO>("usp_GetStationDDL", new { lineId = lineId });

            return stations;
        }
    }
}
