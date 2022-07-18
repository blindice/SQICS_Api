using SQICS_Api.Model;
using SQICS_Api.Repository.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface ITransactionRepository : IRepositoryBase<tbl_t_transaction>
    {
        Task<IEnumerable<tbl_t_transaction>> GetAllTransaction();
    }
}
