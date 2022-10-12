using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.QCInspection
{
    public class QCInspectionRepository : RepositoryBase<tbl_t_lot_inspection>, IQCInspectionRepository
    {
        public QCInspectionRepository(SQICSContext efContext, DapperContext dapperContext)
         : base(efContext, dapperContext) { }

        public async Task AddQCInspectionAsync(tbl_t_lot_inspection inspection)
        {
            await AddAsync(inspection);
        }
    }
}
