using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Defect
{
    public class DefectRepository : RepositoryBase<tbl_m_defect>, IDefectRepository
    {
        public DefectRepository(SQICSContext efContext, DapperContext dapperContext)
        : base(efContext, dapperContext) { }

        public async Task<IEnumerable<tbl_m_defect>> GetAllDefectAsync()
        {
            var defects = await QueryAsync("usp_GetAllDefects");

            return defects;
        }
    }
}
