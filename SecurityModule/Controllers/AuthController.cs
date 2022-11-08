using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityModule.Models;
using SecurityModule.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _IAuthService;
        public AuthController(IAuthService authService)
        {
            _IAuthService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ApiResponseModel> Register(UserRegistrationModel pUserRegistrationModel)
        {
            ApiResponseModel apiResponse = await _IAuthService.Registration(pUserRegistrationModel);
            return apiResponse;
        }

        [HttpGet]
        [Route("ExistUserName")]
        public ApiResponseModel ExistUserName(string pUserName)
        {
            return _IAuthService.ExistUserName(pUserName);
        }

        [HttpPost]
        [Route("UserLogin")]
        public ApiResponseModel UserLogin(LoginModel loginModel)
        {
            return _IAuthService.UserLoginCredentialCheck(loginModel.username, loginModel.password);
        }
    }
}
