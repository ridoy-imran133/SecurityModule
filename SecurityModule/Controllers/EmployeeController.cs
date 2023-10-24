using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityModule.Models;
using SecurityModule.Services;
using SecurityModule.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _IEmployeeService;
        private readonly IConfigService _IConfigService;
        public EmployeeController(IEmployeeService employeeService, IConfigService configService)
        {
            _IEmployeeService = employeeService;
            _IConfigService = configService;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ApiResponseModel> Save(EmployeeRegistrationModel employee)
           {
            ApiResponseModel apiResponse = new ApiResponseModel();
            var response = await _IEmployeeService.SaveEmployee(employee);
            apiResponse.ResponseCode = response.ResponseCode;
            apiResponse.ResponseMessage = response.ResponseMessage;
            return apiResponse;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _IEmployeeService.GetEmployees();
            return Ok(new
            {
                employees = employees
            });
        }

        [HttpGet]
        [Route("getMenuForEmployee")]
        public async Task<IActionResult> GetMenuForEmployee(string username)
        {
            var menus = await _IConfigService.UserWiseProjectMenuPermission(username, true);
            return Ok(new
            {
                menus = menus
            });
        }
    }
}
