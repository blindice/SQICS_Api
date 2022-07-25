﻿using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Interface
{
    public interface ITransactionService
    {
        Task<List<TransactionDetailsDTO>> GetTransactionDetailsByTransNoAsync(string transNo);
    }
}
