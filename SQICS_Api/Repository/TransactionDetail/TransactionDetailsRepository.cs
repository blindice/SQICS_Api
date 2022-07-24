﻿using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.TransactionDetail
{
    public class TransactionDetailsRepository : RepositoryBase<tbl_t_transaction_detail>, ITransactionDetailsRepository
    {

        public TransactionDetailsRepository(SQICSContext efContext, DapperContext dapperContext)
           : base(efContext, dapperContext) { }

        public Task<dynamic> GetAllTransactionDetailsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
