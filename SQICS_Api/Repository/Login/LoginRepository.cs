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
    public class LoginRepository : RepositoryBase<UserInfoDTO>, ILoginRepository
    {
        public LoginRepository(SQICSContext efContext, DapperContext dapperContext)
            : base(efContext, dapperContext) { }

        public Task<UserInfoDTO> VerifyUser(LoginDTO account)
        {
            throw new NotImplementedException();
        }
    }
}
