using SQICS_Api.DTOs;
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

        public async Task<bool> ValidateOperatorAsync(ValidateOperatorDTO info)
        {
            var @operator = await _uow.Operator.GetOperatorByEmpId(info.EmployeeId);

            if (@operator is null) throw new CustomException("Operator Not Found!");

            info.OperatorId = @operator.fld_id;

            var isValid = await _uow.Operator.ValidateOperator(info);

            return isValid;
        }

        public async Task<bool> ValidatePiecePartAsync(ValidatePiecePartDTO info)
        {
            var piecePart = await _uow.PiecePart.GetPiecePartByCode(info.PiecePartCOde);

            if (piecePart is null) throw new CustomException("Piecepart Not Found!");

            info.PiecePartId = piecePart.fld_id;

            var isValid = await _uow.PiecePart.ValidatePiecePart(info);

            return isValid;
        }

        public async Task AddTransactionDetailsAsync(AddTransactionDetailsDTO details)
        {
            try
            {
                
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
