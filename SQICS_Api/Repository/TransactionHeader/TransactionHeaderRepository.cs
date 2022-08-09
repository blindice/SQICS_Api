using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.TransactionHeader
{
    public class TransactionHeaderRepository : RepositoryBase<tbl_t_transaction_header>, ITransactionHeaderRepository
    {
        public TransactionHeaderRepository(SQICSContext efContext, DapperContext dapperContext)
             : base(efContext, dapperContext) { }

        public async Task AddHeaderAsync(tbl_t_transaction_header header)
        {
            await AddAsync(header);
        }

        public async Task<IEnumerable<tbl_t_transaction_header>> GetHeadersByTransNoAsync(string transNo)
        {
            var headers = await QueryAsync("usp_GetHeadersByTransNo", new { transNo = transNo });

            return headers;
        }

        public void UpdateHeaders(IEnumerable<tbl_t_transaction_header> headers)
        {
            UpdateRange(headers);
        }
    }
}
