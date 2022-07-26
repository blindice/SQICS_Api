using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Helper.CustomException;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Assembly
{
    public class AssemblyService : IAssemblyService
    {
        IUnitOfWork _uow;
        IMapper _mapper;

        public AssemblyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> ValidateOperatorAsync(ValidateOperatorDTO info)
        {
            var @operator = await _uow.Operator.GetOperatorByEmpId(info.EmployeeId);

            if (@operator is null) throw new CustomException("Operator Not Found!");

            info.OperatorId = @operator.fld_id;

            var isValid = await _uow.Operator.ValidateOperator(info);

            return isValid;
        }
    }
}
