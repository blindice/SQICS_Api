using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface IOngoingRepository
    {
        Task AddOngoingLotAsync(tbl_t_lot_ongoing lot);

        Task<bool> CheckIfOnGoing(int lineId);
    }
}
