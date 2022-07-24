using SQICS_Api.Model;
using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Base;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Login
{
    public class LoginRepository : RepositoryBase<LoginInfo>, ILoginRepository
    {
        public LoginRepository(SQICSContext efContext, DapperContext dapperContext)
            : base(efContext, dapperContext) { }

        public async Task<LoginInfo> VerifyUserAsync(string username)
        {
            var info = await QuerySingleOrDefaultAsync("usp_GetLoginInfo", new { username = username });

            return info;
        }

        public async Task<LoginInfo> GetUserByIdAsync(int userId)
        {
            var info = await QuerySingleOrDefaultAsync("usp_GetUserByUserId", new { userId = userId });

            return info;
        }
    }
}
