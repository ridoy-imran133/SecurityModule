using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SecurityModule.Entities
{
    [Table("RoleWiseScreenPermission")]
    public class RoleWiseScreenPermission
    {
        public string RoleCode { get; set; }
        public string ProjectCode { get; set; }
        public string ModuleCode { get; set; }
        public string ScreenCode { get; set; }
        public string IsAdd { get; set; }
        public string IsView { get; set; }
        public string IsEdit { get; set; }
        public string IsDeleted { get; set; }
        public string IsActive { get; set; }
        public string IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
