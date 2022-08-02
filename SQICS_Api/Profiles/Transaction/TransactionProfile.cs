using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.Transaction
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<AddPlanDTO, tbl_t_transaction>();
        }
    }
}
