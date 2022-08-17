using SQICS_Api.DTOs;
using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.PiecePart
{
    public class PiecePartRepository : RepositoryBase<tbl_m_part>, IPiecePartRepository
    {
        public PiecePartRepository(SQICSContext efContext, DapperContext dapperContext)
         : base(efContext, dapperContext) { }

        public async Task<tbl_m_part> GetPiecePartByCode(string pieceCode)
        {
            var result = await QuerySingleOrDefaultAsync("usp_GetPiecePartByCode", new { pieceCode = pieceCode });

            return result;
        }

        public async Task<bool> ValidatePiecePart(ValidatePiecePartDTO info)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["pieceId"] = info.PiecePartId,
                ["assyId"] = info.SubAssyId
            };

            var isValid = await ExecuteScalarAsync<bool>("usp_ValidatePiecePart", parameters);

            return isValid;
        }

        public async Task<bool> ValidatePiecepartBySupplierIdAsync(ValidatePieceBySupplierDTO info)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["supplierId"] = info.SupplierId,
                ["pieceCode"] = info.PiecePartCode
            };

            var isValid = await ExecuteScalarAsync<bool>("usp_ValidatePiecePartBySupplier", parameters);

            return isValid;
        }
    }
}
