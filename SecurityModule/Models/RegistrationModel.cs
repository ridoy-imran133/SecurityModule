using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Models
{
    [Table("Registration")]
    public class RegistrationModel
    {
        public string Id { get; set; }

        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? LastLogoutTime { get; set; }
        public DateTime? DateCreated { get; set; }
        
    }
}

