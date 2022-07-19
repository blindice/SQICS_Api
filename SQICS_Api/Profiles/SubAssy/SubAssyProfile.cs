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
            CreateMap<tbl_m_part, SubAssyDDLDTO>()
                .ForMember(dest => dest.SubAssyCode,
                opt => opt.MapFrom(src => src.fld_partCode))
                 .ForMember(dest => dest.SubAssyName,
                opt => opt.MapFrom(src => src.fld_partName))
                  .ForMember(dest => dest.MOST,
                opt => opt.MapFrom(src => src.fld_most))
                   .ForMember(dest => dest.SPQ,
                opt => opt.MapFrom(src => src.fld_spq)).ReverseMap();

            CreateMap<AddPlanDTO, tbl_t_transaction>();
        }
    }
}
