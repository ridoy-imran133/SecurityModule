using AutoMapper;
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
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _IConfigRepository;
        private readonly IMapper _IMapper;

        public ConfigService(IConfigRepository configRepository, IMapper iMapper)
        {
            _IConfigRepository = configRepository;
            _IMapper = iMapper;
        }

        public async Task<ApiResponseModel> UserWiseProjectMenuPermission(string username, bool isEmployee = false)
        {
            ApiResponseModel apiResponse = new ApiResponseModel();
            //Project project = _IMapper.Map<Project>(pProject);
            try
            {
                using (var _context = new SecurityDBContext())
                {
                    apiResponse = await _IConfigRepository.UserWiseProjectMenuPermission(username, isEmployee, _context);
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
