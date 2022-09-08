using Dapper;
using Microsoft.EntityFrameworkCore;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SQICSContext _efContext { get; set; }
        protected DapperContext _dapperContext { get; set; }

        public RepositoryBase(SQICSContext efContext, DapperContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<T>> QueryAsync(string query, object param = null, 
            CommandType cType = CommandType.StoredProcedure)
        {
            using (var conn = _dapperContext.Connection)
            {
                var result =  await conn.QueryAsync<T>(query, param, commandType: cType);
                return result;
            }
        }

        public async Task<IEnumerable<TItem>> QueryAsync<TItem>(string query, object param = null,
           CommandType cType = CommandType.StoredProcedure)
        {
            using (var conn = _dapperContext.Connection)
            {
                var result = await conn.QueryAsync<TItem>(query, param, commandType: cType);
                return result;
            }
        }

        public async Task<TItem> QuerySingleOrDefaultAsync<TItem>(string query, object param = null, 
            CommandType cType = CommandType.StoredProcedure)
        {
            using (var conn = _dapperContext.Connection)
            {
                var result = await conn.QuerySingleOrDefaultAsync<TItem>(query, param, commandType: cType);
                return result;
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync(string query, object param = null,
            CommandType cType = CommandType.StoredProcedure)
        {
            using (var conn = _dapperContext.Connection)
            {
                var result = await conn.QuerySingleOrDefaultAsync<T>(query, param, commandType: cType);
                return result;
            }
        }

        public async Task<TItem> ExecuteScalarAsync<TItem>(string query, object param = null, 
            CommandType cType = CommandType.StoredProcedure)
        {
            using (var conn = _dapperContext.Connection)
            {
                var result = await conn.ExecuteScalarAsync<TItem>(query, param, commandType: cType);
                return result;
            }
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _efContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task AddAsync(T entity)
        {
            await _efContext.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> items)
        {
            await _efContext.Set<T>().AddRangeAsync(items);
        }

        public void Update(T entity)
        {         
            _efContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            _efContext.Set<T>().UpdateRange(items);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            _efContext.Set<T>().RemoveRange(items);
        }

        public void Remove(T item)
        {
            _efContext.Set<T>().Remove(item);
        }
    }
}
