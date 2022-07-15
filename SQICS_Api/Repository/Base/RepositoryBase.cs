using Dapper;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        SQICSContext _context;

        public RepositoryBase(SQICSContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<T>> QueryAsync(string query, object param = null)
        {
            using (var conn = _context.Connection)
            {
                return conn.QueryAsync<T>(query, param);
            }
        }
    }
}
