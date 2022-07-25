using SQICS_Api.DTOs;
using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Operator
{
    public class OperatorRepository : RepositoryBase<tbl_m_operator>, IOperatorRepository
    {
        public OperatorRepository(SQICSContext efContext, DapperContext dapperContext)
           : base(efContext, dapperContext) { }

        public async Task<tbl_m_operator> GetOperatorByEmpId(string empId)
        {
            var result = await QuerySingleOrDefaultAsync("usp_GetOperatorByEmpId", new { empId = empId});

            return result;
        }

        public async Task<bool> ValidateOperator(ValidateOperatorDTO info)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["operatorId"] = info.OperatorId,
                ["subAssyId"] = info.SubAssyId,
                ["stationId"] = info.StationId               
            };
            var isValid = await ExecuteScalarAsync<bool>("usp_ValidateOperator", parameters);

            return isValid;
        }
    }
}
