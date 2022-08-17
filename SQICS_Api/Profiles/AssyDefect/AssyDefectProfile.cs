using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.AssyDefect
{
    public class AssyDefectProfile : Profile
    {
        public AssyDefectProfile()
        {
            CreateMap<AddAssyDefectDTO, tbl_t_assy_defect>().ReverseMap();
        }
    }
}
