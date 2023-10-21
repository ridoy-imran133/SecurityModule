using SecurityModule.Entities;
using SecurityModule.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Repository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRoles(SecurityDBContext pContext);
    }
    public class RoleRepository : IRoleRepository
    {
        public async Task<List<Role>> GetRoles(SecurityDBContext pContext)
        {
            var val = pContext.Role.Where(x => x.IsActive == "Y").ToList();
            return val;
        }
    }
}
