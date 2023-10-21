using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Models;
using SecurityModule.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Repository.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        public async Task<ApiResponseModel> Registration(UserRegistration pUserRegistration, UserLogin pUserLogin, SecurityDBContext pContext)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            using (var transaction = pContext.Database.BeginTransaction())
            {
                try
                {
                    pUserRegistration.Id = Guid.NewGuid().ToString();
                    pUserRegistration.IsActive = "Y";
                    pUserRegistration.IsDelete = "N";
                    pUserRegistration.CreatedBy = "system";
                    pUserRegistration.CreatedDate = DateTime.Now;

                    pUserLogin.Id = Guid.NewGuid().ToString();
                    pUserLogin.RegistrationId = pUserRegistration.Id;
                    pUserLogin.IsActive = "Y";
                    pUserLogin.IsDelete = "N";
                    pUserLogin.CreatedBy = "system";
                    pUserLogin.CreatedDate = DateTime.Now;

                    await pContext.AddAsync(pUserRegistration);
                    await pContext.SaveChangesAsync();
                    await pContext.AddAsync(pUserLogin);
                    await pContext.SaveChangesAsync();

                    transaction.Commit();
                    apiResponse.ResponseCode = StaticValue.SuccessCode;
                    apiResponse.ResponseMessage = "Registration Successfull";
                    return apiResponse;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    apiResponse.ResponseCode = StaticValue.Unauthorized;
                    apiResponse.ResponseMessage = ex.Message;
                }
                return apiResponse;
            }
        }

        public bool CheckUserName(string pUserName, SecurityDBContext pContext)
        {
            return pContext.UserLogin.Where(x => x.Username == pUserName).Count() > 0;
        }

        public UserLogin GetUseLoginInformation(string pUserName, SecurityDBContext pContext)
        {
            return pContext.UserLogin.Where(x => x.Username == pUserName).FirstOrDefault();
        }

        public EmployeeLogin GetEmployeeLoginInformation(string pUserName, SecurityDBContext pContext)
        {
            return pContext.EmployeeLogin.Where(x => x.Username == pUserName).FirstOrDefault();
        }
    }
}
