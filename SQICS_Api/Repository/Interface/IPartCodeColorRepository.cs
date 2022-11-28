using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface IPartCodeColorRepository
    {
        Task AddColor(tbl_m_partcode_color entity);

        void UpdateColor(tbl_m_partcode_color entity);

        IQueryable<tbl_m_partcode_color> GetColorBySupplierId(int supplierId);
    }
}
