using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.SubAssy
{
    public class SubAssyProfile : Profile
    {
        public SubAssyProfile()
        {
            CreateMap<tbl_m_part, SubAssyDDLDTO>().ReverseMap();

            CreateMap<AddPlanDTO, tbl_t_transaction>();

            CreateMap<tbl_m_part, SubAssyDetailsDTO>().ReverseMap();
        }
    }
}
