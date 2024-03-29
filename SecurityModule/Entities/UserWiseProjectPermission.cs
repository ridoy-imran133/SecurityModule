﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Entities
{
    [Table("UserWiseProjectPermission")]
    public class UserWiseProjectPermission
    {
        public string ProjectCode { get; set; }
        public string RegistrationId { get; set; }
        public string FullUrl { get; set; }
        public string IsActive { get; set; }
        public string IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
