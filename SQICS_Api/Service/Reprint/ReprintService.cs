using AutoMapper;
using SQICS_Api.DTOs;
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
    }
}
