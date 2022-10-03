using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Models
{
    public class RoleWiseScreenPermissionModel
    {
        public string RoleCode { get; set; }
        public string ProjectCode { get; set; }
        public string ModuleCode { get; set; }
        public string ScreenCode { get; set; }
        public string IsAdd { get; set; }
        public string IsView { get; set; }
        public string IsEdit { get; set; }
        public string IsDeleted { get; set; }
    }
}
