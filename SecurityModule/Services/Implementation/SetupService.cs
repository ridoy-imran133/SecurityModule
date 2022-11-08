using AutoMapper;
using Microsoft.Extensions.Configuration;
using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Models;
using SecurityModule.Repository.Interface;
using SecurityModule.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Services.Implementation
{
    public class SetupService : ISetupService
    {
        private readonly ISetupRepository _ISetupRepository;
        private readonly IMapper _IMapper;
        private readonly IConfiguration _IConfiguration;

        public SetupService(ISetupRepository setupRepository, IMapper iMapper, IConfiguration configuration)
        {
            _ISetupRepository = setupRepository;
            _IMapper = iMapper;
            _IConfiguration = configuration;
        }

        public async Task<ApiResponseModel> SaveProject(ProjectModel pProject)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            Project project = _IMapper.Map<Project>(pProject);
            try
            {
                using (var _context = new SecurityDBContext())
                {
                    apiResponse = await _ISetupRepository.SaveProject(project, _context);
                }
            } 
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
            return apiResponse;
        }
        public async Task<ApiResponseModel> SaveModule(ModuleModel pModule)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            Module module = _IMapper.Map<Module>(pModule);
            using (var _context = new SecurityDBContext())
            {
                apiResponse = await _ISetupRepository.SaveModule(module, _context);
            }

            return apiResponse;
        }

        public async Task<ApiResponseModel> SaveScreen(ScreenModel pScreen)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            Screen screen = _IMapper.Map<Screen>(pScreen);
            using (var _context = new SecurityDBContext())
            {
                apiResponse = await _ISetupRepository.SaveScreen(screen, _context);
            }

            return apiResponse;
        }

        public async Task<ApiResponseModel> SaveRole(RoleModel pRole)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            Role role = _IMapper.Map<Role>(pRole);
            try
            {
                using (var _context = new SecurityDBContext())
                {
                    apiResponse = await _ISetupRepository.SaveRole(role, _context);
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return apiResponse;
        }
    }
}
