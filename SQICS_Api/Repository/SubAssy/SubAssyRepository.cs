using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.SubAssy
{
    public class SubAssyRepository : RepositoryBase<tbl_m_part>, ISubAssyRepository
    {

        public SubAssyRepository(SQICSContext efContext, DapperContext dapperContext) 
            : base(efContext, dapperContext) {}

        public async Task<IEnumerable<tbl_m_part>> GetAllSubAssyAsync()
        {
            return await QueryAsync("usp_GetAllSubAssy");
        }

        public async Task<tbl_m_part> GetSubAssyByCode(string code)
        {
            return await QuerySingleOrDefaultAsync("usp_GetSubAssyByCode", new { code = code });
        }

        public async Task<IEnumerable<tbl_m_part>> GetSubAssyBySupplierId(int supplierId)
        {
            return await QueryAsync("usp_GetSubAssyBySupplierId", new { supplierId = supplierId });
        }
    }
}
