using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Models
{
    public class UserWiseProjectRolePermissionModel
    {
        public string RoleCode { get; set; }
        public string ProjectCode { get; set; }
        public string RegistrationId { get; set; }
    }
}
