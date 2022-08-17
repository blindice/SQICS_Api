using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.AssyDefect
{
    public class AssyDefectRepository : RepositoryBase<tbl_t_assy_defect>, IAssyDefectRepository
    {
        public AssyDefectRepository(SQICSContext efContext, DapperContext dapperContext)
       : base(efContext, dapperContext) { }
    }
}
