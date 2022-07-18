using AutoMapper;
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
            CreateMap<tbl_m_part, SubAssyDDLDTO>()
                .ForMember(dest => dest.SubAssyCode,
                opt => opt.MapFrom(src => src.fld_partCode))
                 .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.fld_id)).ReverseMap();
        }
    }
}
