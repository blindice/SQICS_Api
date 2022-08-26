using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface ILotLabelRepository
    {
        Task AddLotLabelAsync(tbl_t_lot_label lotLabel);
    }
}
