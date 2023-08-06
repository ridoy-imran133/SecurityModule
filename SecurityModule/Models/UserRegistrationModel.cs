using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Models
{
    public class UserRegistrationModel : UserProfileModel
    {
        public string Password { get; set; }
    }
}
