using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Models;
using SecurityModule.Repository.Interface;
using SecurityModule.Services.Interface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SecurityModule.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _IAuthRepository;
        private readonly IMapper _IMapper;
        public CommonService commonService;
        private readonly IConfiguration _IConfiguration;
        public AuthService(IAuthRepository authRepository, IMapper iMapper, IConfiguration configuration)
        {
            _IAuthRepository = authRepository;
            _IMapper = iMapper;
            _IConfiguration = configuration;
            this.commonService = new CommonService();
        }
        public async Task<ApiResponseModel> Registration(UserRegistrationModel pUserRegistrationModel)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            if (pUserRegistrationModel.UserName == null || pUserRegistrationModel.UserName.Trim() == "")
            {
                apiResponse.ResponseCode = StaticValue.NoContent;
                apiResponse.ResponseMessage = "Must be Given a User Name";
                return apiResponse;
            }
            byte[] pHash, pSalt;
            UserRegistration userResitration = new UserRegistration();
            UserLogin userLogin = new UserLogin();

            this. commonService.CreatePasswordHash(pUserRegistrationModel.Password, out pHash, out pSalt);
            userLogin.Username = pUserRegistrationModel.UserName;
            userLogin.PasswordHash = pHash;
            userLogin.PasswordSalt = pSalt;

            userResitration = _IMapper.Map<UserRegistration>(pUserRegistrationModel);
            using (var _context = new SecurityDBContext())
            {
                bool _isUserNameExist = _IAuthRepository.CheckUserName(pUserRegistrationModel.UserName,_context) ;
                if (_isUserNameExist)
                {
                    apiResponse.ResponseCode = StaticValue.NotModified;
                    apiResponse.ResponseMessage = "User Name ALready Exist";
                    return apiResponse;
                }
                apiResponse = await _IAuthRepository.Registration(userResitration, userLogin, _context);
                return apiResponse;
            }
        }

        public ApiResponseModel ExistUserName(string pUserName)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            using (var _context = new SecurityDBContext())
            {
                try
                {
                    apiResponse.ResponseCode = StaticValue.NotModified;
                    apiResponse.ResponseMessage = "User name exist";
                    apiResponse.ResponseData = _IAuthRepository.CheckUserName(pUserName, _context);
                    return apiResponse;

                }
                catch(Exception ex)
                {
                    apiResponse.ResponseCode = StaticValue.BadRequest;
                    apiResponse.ResponseMessage = ex.Message;
                    return apiResponse;
                }
            }
        }



        public ApiResponseModel UserLoginCredentialCheck(string pUserName, string pPass, bool isEmployee)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            dynamic loginInfo = new ExpandoObject();
            using (var _context = new SecurityDBContext())
            {
                try
                {
                    LoginModel login = new LoginModel();
                    if (isEmployee)
                    {
                        EmployeeLogin employeeLogin = _IAuthRepository.GetEmployeeLoginInformation(pUserName, _context);
                        login = _IMapper.Map<LoginModel>(employeeLogin);
                    }
                    else
                    {
                        UserLogin userLogin = _IAuthRepository.GetUseLoginInformation(pUserName, _context);
                        login = _IMapper.Map<LoginModel>(userLogin);
                    }
                    
                    if(login != null)
                    {
                        string token = this.commonService.VerifyPasswordHash(pPass, login.PasswordHash, login.PasswordSalt) ? tokenGenerate(pUserName) : null;
                        if(token == null)
                        {
                            apiResponse.ResponseCode = StaticValue.NonAuthoritativeInformation;
                            apiResponse.ResponseMessage = "Password Mismatch";
                        }
                        else
                        {
                            loginInfo.token = token;
                            loginInfo.expireIn = DateTime.Now.AddDays(1);
                            loginInfo.userName = pUserName;

                            apiResponse.ResponseCode = StaticValue.SuccessCode;
                            apiResponse.ResponseMessage = "Logged In Successfully";
                            apiResponse.ResponseData = loginInfo;
                        }
                        return apiResponse;
                    }

                    apiResponse.ResponseCode = StaticValue.NotFound;
                    apiResponse.ResponseMessage = "User Name Does not Exist";
                    return apiResponse;

                }
                catch(Exception ex)
                {
                    apiResponse.ResponseCode = StaticValue.Unauthorized;
                    apiResponse.ResponseMessage = ex.Message;
                    return apiResponse;
                }
               
            }
        }

        public string tokenGenerate(string pUserName)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, pUserName)
                //new Claim(ClaimTypes.Name, pUserName)
            };
            string checkVal = _IConfiguration.GetSection("AppSettings:Token").Value;
            byte[] val = Encoding.UTF8.GetBytes(checkVal);
            var key = new SymmetricSecurityKey(val);
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return token;
        }
    }
}
