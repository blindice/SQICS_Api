using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.InspectionMode
{
    public class InspectionModeRepository : RepositoryBase<tbl_m_inspection_mode>, IInspectionModeRepository
    {
        public InspectionModeRepository(SQICSContext efContext, DapperContext dapperContext)
            : base(efContext, dapperContext) { }

        public async Task<IEnumerable<tbl_m_inspection_mode>> GetInspectionModes()
        {
            var results = await QueryAsync("usp_GetInspectionModes");

            return results;
        }
    }
}
