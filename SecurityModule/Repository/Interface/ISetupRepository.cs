using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Repository.Interface
{
    public interface ISetupRepository
    {
        Task<ApiResponseModel> SaveProject(Project pProject, SecurityDBContext pContext);
        Task<ApiResponseModel> SaveModule(Module pModule, SecurityDBContext pContext);
        Task<ApiResponseModel> SaveScreen(Screen pScreen, SecurityDBContext pContext);
        Task<ApiResponseModel> SaveRole(Role pRole, SecurityDBContext pContext);
    }
}
