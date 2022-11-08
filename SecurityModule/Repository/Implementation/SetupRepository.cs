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
    public class SetupRepository : ISetupRepository
    {
       public async Task<ApiResponseModel> SaveProject(Project pProject, SecurityDBContext pContext)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            try
            {
                Project project = pContext.Project.Where(x => x.ProjectCode == pProject.ProjectCode).FirstOrDefault();
                if(project == null)
                {
                    pProject.IsActive = "Y";
                    pProject.IsDelete = "N";
                    pProject.CreatedBy = "system";
                    pProject.CreatedDate = DateTime.Now;

                    await pContext.AddAsync(pProject);
                    await pContext.SaveChangesAsync();

                    apiResponse.ResponseCode = StaticValue.SuccessCode;
                    apiResponse.ResponseMessage = "Added Successfully";
                    return apiResponse;
                }
                apiResponse.ResponseCode = StaticValue.NotModified;
                apiResponse.ResponseMessage = "Project Code Already Exist";
                
            }
            catch (Exception ex)
            {
                apiResponse.ResponseCode = StaticValue.BadRequest;
                apiResponse.ResponseMessage = ex.Message;
            }
            return apiResponse;
        }

       public async Task<ApiResponseModel> SaveModule(Module pModule, SecurityDBContext pContext)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            try
            {
                Module module = pContext.Module.Where(x => x.ProjectCode == pModule.ProjectCode
                                                      && x.ModuleCode == pModule.ModuleCode).FirstOrDefault();
                if (module == null)
                {
                    pModule.IsActive = "Y";
                    pModule.IsDelete = "N";
                    pModule.CreatedBy = "system";
                    pModule.CreatedDate = DateTime.Now;

                    await pContext.AddAsync(pModule);
                    await pContext.SaveChangesAsync();

                    apiResponse.ResponseCode = StaticValue.SuccessCode;
                    apiResponse.ResponseMessage = "Added Successfully";
                    return apiResponse;
                }
                apiResponse.ResponseCode = StaticValue.NotModified;
                apiResponse.ResponseMessage = "Project Wise Module Code Already Exist";

            }
            catch (Exception ex)
            {
                apiResponse.ResponseCode = StaticValue.Unauthorized;
                apiResponse.ResponseMessage = ex.Message;
            }
            return apiResponse;
        }

        public async Task<ApiResponseModel> SaveScreen(Screen pScreen, SecurityDBContext pContext)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            try
            {
                Screen screen = pContext.Screens.Where(x => x.ProjectCode == pScreen.ProjectCode
                                                      && x.ModuleCode == pScreen.ModuleCode
                                                      && x.ScreenCode == pScreen.ScreenCode).FirstOrDefault();
                if (screen == null)
                {
                    pScreen.IsActive = "Y";
                    pScreen.IsDelete = "N";
                    pScreen.CreatedBy = "system";
                    pScreen.CreatedDate = DateTime.Now;

                    await pContext.AddAsync(pScreen);
                    await pContext.SaveChangesAsync();

                    apiResponse.ResponseCode = StaticValue.SuccessCode;
                    apiResponse.ResponseMessage = "Added Successfully";
                    return apiResponse;
                }
                apiResponse.ResponseCode = StaticValue.NotModified;
                apiResponse.ResponseMessage = "Project Wise Screen Code Already Exist";

            }
            catch (Exception ex)
            {
                apiResponse.ResponseCode = StaticValue.BadRequest;
                apiResponse.ResponseMessage = ex.Message;
            }
            return apiResponse;
        }

        public async Task<ApiResponseModel> SaveRole(Role pRole, SecurityDBContext pContext)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            try
            {
                Role role = pContext.Role.Where(x => x.RoleCode == pRole.RoleCode).FirstOrDefault();
                if (role == null)
                {
                    pRole.IsActive = "Y";
                    pRole.IsDelete = "N";
                    pRole.CreatedBy = "system";
                    pRole.CreatedDate = DateTime.Now;

                    await pContext.AddAsync(pRole);
                    await pContext.SaveChangesAsync();

                    apiResponse.ResponseCode = StaticValue.SuccessCode;
                    apiResponse.ResponseMessage = "Added Successfully";
                    return apiResponse;
                }
                apiResponse.ResponseCode = StaticValue.NotModified;
                apiResponse.ResponseMessage = "Role Code Already Exist";

            }
            catch (Exception ex)
            {
                apiResponse.ResponseCode = StaticValue.BadRequest;
                apiResponse.ResponseMessage = ex.Message;
            }
            return apiResponse;
        }
    }
}
