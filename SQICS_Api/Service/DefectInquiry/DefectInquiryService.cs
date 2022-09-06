using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Helper.CustomException;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.DefectInquiry
{
    public class DefectInquiryService : IDefectInquiryService
    {
        IUnitOfWork _uow;
        IMapper _mapper;

        public DefectInquiryService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<DefectInquiryDTO>> GetDefectInquiryAsync(DefectInquiryParams @params)
        {
            var defectInquiry = await _uow.AssyDefect.GetAssyDefectInquiryAsync(@params);

            if (defectInquiry is null) throw new CustomException("Invalid Defect Inquiry!");

            return defectInquiry.ToList();
        }
    }
}
