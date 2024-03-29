﻿using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface IOperatorRepository
    {
        Task<SubAssyByOperatorIdDTO> GetOperatorByEmpId(string empId);

        Task<bool> ValidateOperator(ValidateOperatorDTO info);
    }
}
