using SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Services.Interface
{
    public interface IConfigService
    {
        Task<ApiResponseModel> UserWiseProjectMenuPermission(string username);
    }
}
