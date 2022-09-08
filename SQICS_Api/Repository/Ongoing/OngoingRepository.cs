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

        public async Task AddOngoingLotAsync(tbl_t_lot_ongoing lot)
        {
            await AddAsync(lot);
        }

        public async Task<bool> CheckIfOnGoing(int lineId)
        {
            var isOngoing = await ExecuteScalarAsync<bool>("usp_CheckIfOngoing", new { lineId = lineId });

            return isOngoing;
        }

        public async Task<IEnumerable<tbl_t_lot_ongoing>> GetLotsByTransNoAsync(string transNo)
        {
            var lots = await QueryAsync("usp_GetOnGoingByTransNo", new { transNo = transNo });

            return lots;
        }

        public void RemoveLots(IEnumerable<tbl_t_lot_ongoing> lots)
        {
            RemoveRange(lots);
        }

        public async Task<tbl_t_lot_ongoing> GetOngoingByAssyLot(string assyLot)
        {
            var onGoing = await QuerySingleOrDefaultAsync("sp_GetOnGoingByAssyLot", new { assyLot = assyLot});

            return onGoing;
        }

        public void UpdateOnGoing(tbl_t_lot_ongoing ongoing)
        {
            Update(ongoing);
        }

        public void RemoveOnGoing(tbl_t_lot_ongoing ongoing)
        {
            Remove(ongoing);
        }
        
    }
}
