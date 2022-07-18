using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Base.Interface
{
    public interface IRepositoryBase<T> 
    {
        Task<IEnumerable<T>> QueryAsync(string query, object param = null, CommandType cType = CommandType.StoredProcedure);

        Task<T> QuerySingleOrDefaultAsync(string query, object param = null, CommandType cType = CommandType.StoredProcedure);

        Task AddAsync(T entity);

    }
}
