using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Models;
using SecurityModule.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        public UserRegistration GetUserProfile(string username, SecurityDBContext pContext)
        {
            return pContext.UserRegistration.Where(x => x.UserName == username).FirstOrDefault();
        }
    }
}
