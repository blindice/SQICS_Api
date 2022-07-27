using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.Defect
{
    public class DefectProfile : Profile
    {
        public DefectProfile()
        {
            CreateMap<tbl_m_defect, DefectDTO>().ReverseMap();
        }
    }
}
