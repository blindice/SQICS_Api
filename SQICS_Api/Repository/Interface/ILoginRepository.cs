﻿using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<LoginInfo> VerifyUserAsync(string username);

        Task<LoginInfo> GetUserByIdAsync(int userId);
    }
}
