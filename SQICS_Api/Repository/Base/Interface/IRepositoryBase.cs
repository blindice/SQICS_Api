using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Base.Interface
{
    public interface IRepositoryBase<T> 
    {
        Task<IEnumerable<T>> QueryAsync(string query, object param = null, CommandType cType = CommandType.StoredProcedure);

        Task<IEnumerable<TItem>> QueryAsync<TItem>(string query, object param = null, CommandType cType = CommandType.StoredProcedure);

        Task<TItem> QuerySingleOrDefaultAsync<TItem>(string query, object param = null, CommandType cType = CommandType.StoredProcedure);

        Task<T> QuerySingleOrDefaultAsync(string query, object param = null, CommandType cType = CommandType.StoredProcedure);

        Task<TItem> ExecuteScalarAsync<TItem>(string query, object param = null, CommandType cType = CommandType.StoredProcedure);

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(List<T> items);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> items);

        void RemoveRange(IEnumerable<T> items);

        void Remove(T item);

    }
}
