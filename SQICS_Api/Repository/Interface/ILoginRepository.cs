using SQICS_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<UserInfoDTO> VerifyUser(LoginDTO account);
    }
}
