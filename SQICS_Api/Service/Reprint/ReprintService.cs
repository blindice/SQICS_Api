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

namespace SQICS_Api.Service.Reprint
{
    public class ReprintService : IReprintService
    {
        IUnitOfWork _uow;
        IMapper _mapper;

        public ReprintService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<LotLabelDTO>> GetAllLotLabelAsync()
        {
            var lotLabels = await _uow.LotLabel.GetAllLotLabelAsync();
            var dto = _mapper.Map<List<LotLabelDTO>>(lotLabels);

            return dto;
        }

        public async Task PrintLotLabelAsync(UpdateLotLabelDTO details)
        {
            var lotLabel = await _uow.LotLabel.GetLotLabelByIdAsync(details.Id);

            if (lotLabel is null) throw new CustomException("Invalid Lot Label!");

            if (!lotLabel.fld_printed) 
                lotLabel.fld_printed = true;
            else 
                lotLabel.fld_reprinted = true;

            lotLabel.fld_updatedBy = details.CreatedBy;
            lotLabel.fld_updatedDate = DateTime.Now;

            _uow.LotLabel.UpdateLotLabelAsync(lotLabel);

            await _uow.SaveAsync();
        }
    }
}
