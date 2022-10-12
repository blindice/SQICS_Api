using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.QCInspection
{
    public class QCInspectionService : IQCInspectionService
    {
        IUnitOfWork _uow;
        IMapper _mapper;

        public QCInspectionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        public async Task AddInspectionAsync(AddQCInspectionDTO inspection)
        {
            var result = await _uow.Transaction.GetTransactionByAssyLot(inspection.SubassyLot);
        }
    }
}
