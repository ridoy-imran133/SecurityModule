using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _IConfigService;
        public ConfigController(IConfigService configService)
        {
            _IConfigService = configService;
        }

        [HttpGet]
        [Route("getMenu")]
        public async Task<IActionResult> GetAllMenus(string username)
        {
            var menus = await _IConfigService.UserWiseProjectMenuPermission(username);
            return Ok(new
            {
                menus = menus
            });
        }
    }
}
