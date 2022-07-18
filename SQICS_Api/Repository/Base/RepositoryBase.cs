using Dapper;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SQICSContext _context { get; set; }

        public RepositoryBase(SQICSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> QueryAsync(string query, object param = null, 
            CommandType cType = CommandType.StoredProcedure)
        {
            using (var conn = _context.Connection)
            {
                var result =  await conn.QueryAsync<T>(query, param, commandType: cType);
                return result;
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync(string query, object param = null, 
            CommandType cType = CommandType.StoredProcedure)
        {
            using (var conn = _context.Connection)
            {
                var result = await conn.QuerySingleOrDefaultAsync<T>(query, param, commandType: cType);
                return result;
            }
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }
    }
}
