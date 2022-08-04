using SQICS_Api.DTOs;
using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Line
{
    public class LineRepository : RepositoryBase<tbl_m_line>, ILineRepository
    {
        public LineRepository(SQICSContext efContext, DapperContext dapperContext)
            : base(efContext, dapperContext) { }

        public async Task<IEnumerable<LineDDLDTO>> GetLineDDLBySupplierIdAsync(int supplierId)
        {
            var lines = await QueryAsync<LineDDLDTO>("usp_GetLineDDL", new { supplierId = supplierId });

            return lines;
        }
    }
}
