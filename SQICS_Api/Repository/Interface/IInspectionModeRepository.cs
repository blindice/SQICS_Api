using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface IInspectionModeRepository
    {
        Task<IEnumerable<tbl_m_inspection_mode>> GetInspectionModes();
    }
}
