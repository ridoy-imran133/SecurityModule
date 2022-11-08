using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityModule.Entities;
using SecurityModule.Models;
using SecurityModule.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly ISetupService _ISetupService;
        public SetupController(ISetupService setupService)
        {
            _ISetupService = setupService;
        }

        [HttpPost]
        [Route("SaveProject")]
        public async Task<ApiResponseModel> SaveProjectAsync(ProjectModel pProject)
        {
            ApiResponseModel apiResponse = await _ISetupService.SaveProject(pProject);
            return apiResponse;
        }

        [HttpPost]
        [Route("SaveModule")]
        public async Task<ApiResponseModel> SaveModuleAsync(ModuleModel pModule)
        {
            ApiResponseModel apiResponse = await _ISetupService.SaveModule(pModule);
            return apiResponse;
        }

        [HttpPost]
        [Route("SaveScreen")]
        public async Task<ApiResponseModel> SaveScreen(ScreenModel pScreen)
        {
            ApiResponseModel apiResponse = await _ISetupService.SaveScreen(pScreen);
            return apiResponse;
        }

        [HttpPost]
        [Route("SaveRole")]
        public async Task<ApiResponseModel> SaveRole(RoleModel pRole)
        {
            ApiResponseModel apiResponse = await _ISetupService.SaveRole(pRole);
            return apiResponse;
        }
    }
}
