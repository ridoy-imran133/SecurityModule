using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Repository.Interface
{
    public interface IUserRepository
    {
        UserRegistration GetUserProfile(string username, SecurityDBContext pContext);
    }
}
