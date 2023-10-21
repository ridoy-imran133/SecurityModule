using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Helpers.Sequence;
using SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Repository
{
    public interface IEmployeeRepository
    {
        Task<(string statuscode, string statusvalue)> SaveEmployee(EmployeeRegistration employee, EmployeeLogin login, string rolecode, string projectcode, SecurityDBContext pContext);
        Task<List<EmployeeRegistration>> GetEmployees(SecurityDBContext pContext);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<(string, string)> SaveEmployee(EmployeeRegistration employee, EmployeeLogin login, string rolecode, string projectcode, SecurityDBContext pContext)
        {
            string statuscode = "";
            string statusvalue = "";
            using (var trans = pContext.Database.BeginTransaction())
            {
                try
                {
                    if (employee.Id < 1)
                    {
                        employee.Id = new SequenceValueGenerator(SequenceName.EmployeeRegistration_seq).Next();
                        employee.CreatedDate = DateTime.Now;

                        UserWiseProjectRolePermission userWiseRole = new UserWiseProjectRolePermission();
                        userWiseRole.Id = Guid.NewGuid().ToString();
                        userWiseRole.RoleCode = rolecode;
                        userWiseRole.ProjectCode = projectcode;
                        userWiseRole.EmpRegId = employee.Id;
                        userWiseRole.IsActive = "Y";
                        userWiseRole.IsDelete = "N";
                        userWiseRole.CreatedBy = employee.CreatedBy;
                        userWiseRole.CreatedDate = DateTime.Now;
                        await pContext.AddAsync(userWiseRole);
                        await pContext.SaveChangesAsync();

                        if (employee.HasSystemAccess)
                        {
                            login.Id = new SequenceValueGenerator(SequenceName.EmployeeLogin_seq).Next();
                            login.EmpRegId = employee.Id;
                            login.IsActive = "Y";
                            login.IsDelete = "N";
                            login.CreatedBy = "system";
                            login.CreatedDate = DateTime.Now;

                            await pContext.AddAsync(login);
                            await pContext.SaveChangesAsync();
                        }

                        await pContext.AddAsync(employee);
                        await pContext.SaveChangesAsync();
                        trans.Commit();
                        statuscode = "2000";
                        statusvalue = "Successful";
                    }
                    else
                    {
                        employee.ModifiedDate = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    statuscode = "2000";
                    statusvalue = ex.Message;
                }
            }

            return (statuscode, statusvalue);
        }

        public async Task<List<EmployeeRegistration>> GetEmployees(SecurityDBContext pContext)
        {
            var val = pContext.EmployeeRegistration.Where(x => x.IsActive == "Y").ToList();
            return val;
        }
    }
}
