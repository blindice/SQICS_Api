using Microsoft.EntityFrameworkCore;
using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.PartCodeColor
{
    public class PartCodeColorRepository : RepositoryBase<tbl_m_partcode_color>, IPartCodeColorRepository
    {
        public PartCodeColorRepository(SQICSContext efContext, DapperContext dapperContext)
        : base(efContext, dapperContext) { }

        public async Task AddColor(tbl_m_partcode_color entity)
        {
            await AddAsync(entity);
        }

        public IQueryable<tbl_m_partcode_color> GetColorBySupplierId(int supplierId)
        {
            var colors =  GetByCondition(c => c.fld_supplierId == supplierId);

            return colors;
        }

        public void UpdateColor(tbl_m_partcode_color entity)
        {
            Update(entity);
        }
    }
}
