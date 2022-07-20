using SQICS_Api.Model;
using SQICS_Api.Repository.Interface;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Login
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _uow;
        public LoginService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Task<UserInfoDTO> VerifyUserAsync(LoginDTO account)
        {
            throw new Exception();
        }
    }
}
