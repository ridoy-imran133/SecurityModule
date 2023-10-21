using SecurityModule.Entities;
using System;
using SecurityModule.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecurityModule.Models;

namespace SecurityModule.Repository.Interface
{
    public interface IAuthRepository
    {
        bool CheckUserName(string pUserName, SecurityDBContext pContext);
        Task<ApiResponseModel> Registration(UserRegistration pUserRegistration, UserLogin pUserLogin, SecurityDBContext pContext);
        UserLogin GetUseLoginInformation(string pUserName, SecurityDBContext pContext);
        EmployeeLogin GetEmployeeLoginInformation(string pUserName, SecurityDBContext pContext);
    }
}
