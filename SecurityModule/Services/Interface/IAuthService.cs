using SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Services.Interface
{
    public interface IAuthService
    {
        ApiResponseModel ExistUserName(string pUserName);
        Task<ApiResponseModel> Registration(UserRegistrationModel pUserRegistrationModel);
        ApiResponseModel UserLoginCredentialCheck(string pUserName, string pPass);
    }
}
