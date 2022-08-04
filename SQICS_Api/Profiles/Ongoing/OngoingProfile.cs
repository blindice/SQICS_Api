using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.Ongoing
{
    public class OngoingProfile : Profile
    {
        public OngoingProfile()
        {
            CreateMap<AddOngoingDTO, tbl_t_lot_ongoing>().ReverseMap();
        }
    }
}
