using SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Services.Interface
{
    public interface IUserService
    {
        UserProfileModel GetUserProfile(string username);
    }
}
