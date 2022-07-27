using AutoMapper;
using Microsoft.AspNetCore.Http;
using SQICS_Api.DTOs;
using SQICS_Api.Helper.CustomException;
using SQICS_Api.Model;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Transaction
{
    public class TransactionService : ITransactionService
    {
        IUnitOfWork _uow;
        IMapper _mapper;

        public TransactionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<TransactionDetailsDTO>> GetTransactionDetailsByTransNoAsync(string transNo)
        {
            var result = await _uow.TDetails.GetTransactionDetailsByTransNoAsync(transNo);

            if (result is null) throw new CustomException("Invalid Transaction Details!");

            return result.ToList();
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
                var transDetails = _mapper.Map<tbl_t_transaction_detail>(details);
                transDetails.fld_createdDate = DateTime.Now;

                await _uow.TDetails.AddTransactionDetailsAsync(transDetails);
                await _uow.SaveAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<DefectDTO>> GetAllDefectsAsync()
        {
            var result = await _uow.Defect.GetAllDefectAsync();

            if (result is null) throw new CustomException("No Defects Found!");

            var defects = _mapper.Map<List<DefectDTO>>(result);

            return defects.ToList();
        }
    }
}
