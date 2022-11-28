using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.PartCodeColor
{
    public class PartCodeColorProfile : Profile
    {
        public PartCodeColorProfile()
        {
            CreateMap<UpdateOrCreatePartColorDTO, tbl_m_partcode_color>().ReverseMap();

            CreateMap<tbl_m_partcode_color, PartCodeColorDTO>().ReverseMap();
        }
    }
}
