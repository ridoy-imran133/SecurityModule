using SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Services.Interface
{
    public interface ISetupService
    {
        Task<ApiResponseModel> SaveProject(ProjectModel pProject);
        Task<ApiResponseModel> SaveModule(ModuleModel pModule);
        Task<ApiResponseModel> SaveScreen(ScreenModel pScreen);
        Task<ApiResponseModel> SaveRole(RoleModel pRole);
    }
}
