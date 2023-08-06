using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class UserController : ControllerBase
    {
        private readonly IAuthService _IAuthService;
        private readonly IUserService _IUserService;
        public UserController(IAuthService authService, IUserService userService)
        {
            _IAuthService = authService;
            _IUserService = userService;
        }

        [HttpGet]
        [Route("ExistUserName")]
        public ApiResponseModel ExistUserName(string pUserName)
        {
            return _IAuthService.ExistUserName(pUserName);
        }

        [HttpGet]
        [Route("UserProfile")]
        public IActionResult GetUserProfile(string pUserName)
        {
            var profile = _IUserService.GetUserProfile(pUserName);
            return Ok(new
            {
                profile = profile
            });
        }

        //Refresh Token Controller
        // Get User INfo
        //Get Other User Info
    }
}
