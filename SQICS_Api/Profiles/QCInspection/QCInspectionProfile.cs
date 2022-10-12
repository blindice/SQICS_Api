using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.QCInspection
{
    public class QCInspectionProfile : Profile
    {
        public QCInspectionProfile()
        {
            CreateMap<AddQCInspectionDTO, tbl_t_lot_inspection>().ReverseMap();
        }
    }
}
