using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityModule.Helpers;
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
        //[HttpGet]
        //[Route("users")]
        //public async Task<IActionResult> GetUsers()
        //{
        //    using (var _context = new SecurityDBContext())
        //    {
        //        var val = _context.Registration.ToList();
        //    }
        //    return Ok();
        //}
    }
}
