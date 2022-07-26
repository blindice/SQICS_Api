using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.TransactionDetail
{
    public class TransactionDetailProfile : Profile
    {
        public TransactionDetailProfile()
        {
            CreateMap<AddTransactionDetailsDTO, tbl_t_transaction_detail>();
        }
    }
}
