using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SecurityModule.Helpers;
using SecurityModule.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAuthService _IAuthService;
        public ValuesController(IAuthService authService)
        {
            _IAuthService = authService;
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> GetUsers(Object val)
        {
            string data = val.ToString();
            var v = JsonConvert.DeserializeObject(data);
            //v.service
            //branchModel = JsonConvert.DeserializeObject<BranchModel>(data);
            //var s = val[0];
            //var va = val;
            return Ok();
        }

        [HttpPost]
        [Route("users/{{id}}")]
        public async Task<IActionResult> GetUserstest(Object val)
        {
            string data = val.ToString();
            var v = JsonConvert.DeserializeObject(data);
            //v.service
            //branchModel = JsonConvert.DeserializeObject<BranchModel>(data);
            //var s = val[0];
            //var va = val;
            return Ok();
        }
    }
}
