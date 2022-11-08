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
        public UserController(IAuthService authService)
        {
            _IAuthService = authService;
        }

        [HttpGet]
        [Route("ExistUserName")]
        public ApiResponseModel ExistUserName(string pUserName)
        {
            return _IAuthService.ExistUserName(pUserName);
        }

        //Refresh Token Controller
        // Get User INfo
        //Get Other User Info
    }
}
