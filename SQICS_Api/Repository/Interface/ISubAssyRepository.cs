using SQICS_Api.Model;
using SQICS_Api.Repository.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface ISubAssyRepository
    {
        Task<IEnumerable<tbl_m_part>> GetAllSubAssyAsync();

        Task<tbl_m_part> GetSubAssyByCode(string code);

        Task<IEnumerable<tbl_m_part>> GetSubAssyBySupplierId(int supplierId);
    }
}
