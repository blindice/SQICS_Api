using AutoMapper;
using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Profiles.Login
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginInfo, UserInfoDTO>().ReverseMap();
        }
    }
}
