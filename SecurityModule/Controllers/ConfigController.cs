﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
