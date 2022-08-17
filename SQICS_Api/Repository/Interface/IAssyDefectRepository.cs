using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface IAssyDefectRepository
    {

        Task AddAssyDefectAsync(tbl_t_assy_defect assyDefect);
    }
}
