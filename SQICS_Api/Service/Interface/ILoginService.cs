﻿using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Interface
{
    public interface ILoginService
    {
        Task<UserInfoDTO> VerifyUserAsync(LoginDTO account);

        Task<UserInfoDTO> GetUserByUserIdAsync(int userId);

        Task<string> GenerateJWTTokenAsync(UserInfoDTO userInfo);
    }
}
