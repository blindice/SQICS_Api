using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface ILotLabelRepository
    {
        Task<IEnumerable<tbl_t_lot_label>> GetAllLotLabelAsync();

        Task<tbl_t_lot_label> GetLotLabelByIdAsync(int id);

        Task AddLotLabelsAsync(List<tbl_t_lot_label> lotLabels);

        void UpdateLotLabelAsync(tbl_t_lot_label lotLabel);
    }
}
