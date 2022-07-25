using SQICS_Api.Helper.CustomException;
using SQICS_Api.Model;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Transaction
{
    public class TransactionService : ITransactionService
    {
        IUnitOfWork _uow;

        public TransactionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<TransactionDetailsDTO>> GetTransactionDetailsByTransNoAsync(string transNo)
        {
            var result = await _uow.TDetails.GetTransactionDetailsByTransNoAsync(transNo);

            if (result is null) throw new CustomException("Invalid Transaction Details!");

            return result.ToList();
        }

        public async Task<bool> ValidateOperatorAsync(string empId)
        {
            var @operator = await _uow.Operator.GetOperatorByEmpId(empId);

            if (@operator is null) throw new CustomException("Operator Not Found!");

            var isValid = await _uow.Operator.ValidateOperator(@operator.fld_id);

            return isValid;
        }
    }
}
