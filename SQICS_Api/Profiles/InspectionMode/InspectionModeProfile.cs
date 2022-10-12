using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.InspectionMode
{
    public class InspectionModeProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<tbl_m_inspection_mode, InspectionModeDDLDTO>().ReverseMap();
        }
    }
}
