using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.LotLabel
{
    public class LotLabelRepository : RepositoryBase<tbl_t_lot_label>, ILotLabelRepository
    {
        public LotLabelRepository(SQICSContext efContext, DapperContext dapperContext)
        : base(efContext, dapperContext) { }

        public async Task AddLotLabelAsync(tbl_t_lot_label lotLabel)
        {
            await AddAsync(lotLabel);
        }

        public void UpdateLotLabelAsync(tbl_t_lot_label lotLabel)
        {
            Update(lotLabel);
        }
    }
}
