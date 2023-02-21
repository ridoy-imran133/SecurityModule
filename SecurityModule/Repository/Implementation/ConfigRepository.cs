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
    public class ConfigRepository : IConfigRepository
    {
        public async Task<ApiResponseModel> UserWiseProjectMenuPermission(string username, SecurityDBContext pContext)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            using (var transaction = pContext.Database.BeginTransaction())
            {
                try
                {
                    UserRegistration registration = pContext.UserRegistration.Where(x => x.UserName == username).FirstOrDefault();
                    UserWiseProjectRolePermission userWiseProjectRole = pContext.UserWiseProjectRolePermission.Where(x => x.RegistrationId == registration.Id).FirstOrDefault();
                    //List<RoleWiseScreenPermission> roleWiseScreen = pContext.RoleWiseScreenPermission.Where(x => x.ProjectCode == userWiseProjectRole.ProjectCode && x.RoleCode == userWiseProjectRole.RoleCode).ToList();
                    List<MenuModel> menus = (from rp in pContext.RoleWiseScreenPermission
                               join r in pContext.Role on rp.RoleCode equals r.RoleCode
                               join sc in pContext.Screens on rp.ScreenCode equals sc.ScreenCode
                               where (rp.ProjectCode == userWiseProjectRole.ProjectCode && rp.RoleCode == userWiseProjectRole.RoleCode)
                               orderby sc.ScreenCode
                               select new MenuModel() 
                               {
                                   descp = sc.ScDescription,
                                   modId = sc.ModuleCode,
                                   role = r.RoleName,
                                   scrId = sc.ScreenCode,
                                   scrLink = sc.URL,
                                   scrName = sc.ScreenName,
                                   scrParentId = sc.ParentsCode,
                                   scrseqNo = sc.Sequence,
                                   icon = sc.Icon
                               }).ToList();
                    apiResponse.ResponseCode = StaticValue.SuccessCode;
                    apiResponse.ResponseMessage = "Menu Fetch Successfull";
                    apiResponse.ResponseData = menus;
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
    }
}
