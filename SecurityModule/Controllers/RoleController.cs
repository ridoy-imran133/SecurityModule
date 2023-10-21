using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _IRoleService;
        public RoleController(IRoleService roleService)
        {
            _IRoleService = roleService;
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> GetEmployees()
        {
            var roles = await _IRoleService.GetRoles();
            return Ok(new
            {
                roles = roles
            });
        }
    }
}
