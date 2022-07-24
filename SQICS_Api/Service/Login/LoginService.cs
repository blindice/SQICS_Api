using AutoMapper;
using SQICS_Api.Helper.CustomException;
using SQICS_Api.Model;
using SQICS_Api.Repository.Interface;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SQICS_Api.Helper.Password.PasswordManager;

namespace SQICS_Api.Service.Login
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IJWTService _jwt;
        public LoginService(IUnitOfWork uow, IMapper mapper, IJWTService jwt)
        {
            _uow = uow;
            _mapper = mapper;
            _jwt = jwt;
        }
        public async Task<UserInfoDTO> VerifyUserAsync(LoginDTO account)
        {
            var userInfo = await _uow.Login.VerifyUserAsync(account.Username);

            if (userInfo is null) throw new CustomException("Invalid Account");

            var hash = GetHash(account.Password, userInfo.Salt);

            if (hash != userInfo.Password) throw new CustomException("Invalid Account");

            var info = _mapper.Map<UserInfoDTO>(userInfo);

            return info;
        }

        public async Task<UserInfoDTO> GetUserByUserIdAsync(int userId)
        {
            var userInfo = await _uow.Login.GetUserByIdAsync(userId);

            if (userInfo is null) throw new CustomException("Invalid User ID!");

            var info = _mapper.Map<UserInfoDTO>(userInfo);

            return info;
        }

        public async Task<string> GenerateJWTTokenAsync(UserInfoDTO userInfo)
        {
            if (userInfo is null) throw new CustomException("Can't Generate JWT Token, Invalid User Info!");

            return await _jwt.GenerateJwtTokenAsync(userInfo);
        }
    }
}
