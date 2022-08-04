using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Ongoing
{
    public class OngoingRepository: RepositoryBase<tbl_t_lot_ongoing>, IOngoingRepository
    {
        public OngoingRepository(SQICSContext efContext, DapperContext dapperContext)
          : base(efContext, dapperContext) { }

        public async Task AddOngoingLot(tbl_t_lot_ongoing lot)
        {
            await AddAsync(lot);
        }
    }
}
