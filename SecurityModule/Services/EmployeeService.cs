using AutoMapper;
using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Models;
using SecurityModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Services
{
    public interface IEmployeeService
    {
        Task<(string ResponseCode, string ResponseMessage)> SaveEmployee(EmployeeRegistrationModel employee);
        Task<List<EmployeeRegistrationModel>> GetEmployees();
    }
    public class EmployeeService : IEmployeeService
    {

        private readonly IMapper _IMapper;
        private readonly IEmployeeRepository _IEmployeeRepository;
        public CommonService commonService;

        public EmployeeService(IMapper iMapper)
        {
            _IEmployeeRepository = new EmployeeRepository();
            _IMapper = iMapper;
            this.commonService = new CommonService();
        }
        public async Task<(string ResponseCode, string ResponseMessage)> SaveEmployee(EmployeeRegistrationModel employee)
        {
            using (var _context = new SecurityDBContext())
            {
                EmployeeRegistration emp = _IMapper.Map<EmployeeRegistration>(employee);
                byte[] pHash, pSalt;
                EmployeeLogin employeeLogin = new EmployeeLogin();
                this.commonService.CreatePasswordHash("12345", out pHash, out pSalt);
                employeeLogin.Username = employee.UserName;
                employeeLogin.PasswordHash = pHash;
                employeeLogin.PasswordSalt = pSalt;
                return await _IEmployeeRepository.SaveEmployee(emp, employeeLogin, employee.RoleCode, employee.ProjectCode,  _context);
            }
        }

        public async Task<List<EmployeeRegistrationModel>> GetEmployees()
        {
            using (var _context = new SecurityDBContext())
            {
                try
                {
                    List<EmployeeRegistration> em = await _IEmployeeRepository.GetEmployees(_context);
                    var val = _IMapper.Map<List<EmployeeRegistrationModel>>(em);  
                    return val;
                } catch(Exception ex)
                {
                    var msg = ex.Message;
                }
                return new List<EmployeeRegistrationModel>();
            }
        }
    }
}
