using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Entities
{
    [Table("Role")]
    public class Role
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string IsActive { get; set; }
        public string IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
