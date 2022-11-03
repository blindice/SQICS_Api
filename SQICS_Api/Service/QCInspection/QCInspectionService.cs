using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Helper.CustomException;
using SQICS_Api.Model;
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
            var result = await _uow.Transaction.GetTransactionByAssyLot(inspection.fld_assyLot);

            if(result is null) throw new CustomException("Invalid Inspection!");

            var part = await _uow.PiecePart.GetPiecePartByCodeIsAssy1(inspection.fld_partCode);

            if (part is null) throw new CustomException("Invalid Part Code!");

            var lotInspection = _mapper.Map<tbl_t_lot_inspection>(inspection);
            lotInspection.fld_shiftId = result.fld_shiftId;
            lotInspection.fld_prodDate = result.fld_prodDate;
            lotInspection.fld_createdDate = DateTime.Now;

            await _uow.QCInspection.AddQCInspectionAsync(lotInspection);
            await _uow.SaveAsync();
        }

        public async Task<List<InspectionModeDDLDTO>> GetInspectionModeDDLAsync()
        {
            var result = await _uow.InspectionMode.GetInspectionModes();

            if(result is null) throw new CustomException("Error while getting Inspection Modes");

            var ddlDatas = _mapper.Map<List<InspectionModeDDLDTO>>(result);

            return ddlDatas;
        }
    }
}
