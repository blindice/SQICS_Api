﻿using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface IPiecePartRepository
    {
        Task<tbl_m_part> GetPiecePartByCode(string pieceCode);

        //Roy Oct 19, 2022
        Task<tbl_m_part> GetPiecePartByCodeIsAssy1(string pieceCode);
        Task<bool> ValidatePiecePart(ValidatePiecePartDTO info);
        Task<bool> ValidatePiecepartBySupplierIdAsync(ValidatePieceBySupplierDTO info);

    }
}
