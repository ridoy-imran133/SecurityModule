using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Entities
{
    [Table("UserRegistration")]
    public class UserRegistration
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }        
        public string UserName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string IsActive { get; set; }
        public string IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
