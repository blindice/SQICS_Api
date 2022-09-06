using SQICS_Api.DTOs;
using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.AssyDefect
{
    public class AssyDefectRepository : RepositoryBase<tbl_t_assy_defect>, IAssyDefectRepository
    {
        public AssyDefectRepository(SQICSContext efContext, DapperContext dapperContext)
        : base(efContext, dapperContext) { }

        public async Task AddAssyDefectAsync(tbl_t_assy_defect assyDefect)
        {
            await AddAsync(assyDefect);
        }

        public async Task<IEnumerable<DefectInquiryDTO>> GetAssyDefectInquiryAsync(DefectInquiryParams @params)
        {
            var parameters = new {
                supplierId = @params.SupplierId,
                dateFrom = @params.DateFrom,
                dateTo = @params.DateTo,
                defectId = @params.DefectId,
                shiftId = @params.ShiftId
            };
            return await QueryAsync<DefectInquiryDTO>("sp_GetDefectInquiry", parameters);
        }
    }
}
