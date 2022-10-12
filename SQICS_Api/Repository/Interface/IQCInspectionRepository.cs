using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface IQCInspectionRepository
    {
        Task AddQCInspectionAsync(tbl_t_lot_inspection inspection);
    }
}
