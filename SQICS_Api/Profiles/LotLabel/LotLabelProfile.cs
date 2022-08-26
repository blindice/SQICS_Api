using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.LotLabel
{
    public class LotLabelProfile : Profile
    {
        public LotLabelProfile()
        {
            CreateMap<tbl_t_lot_label, LotLabelDTO>().ReverseMap();
        }
    }
}
