using AutoMapper;
using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Models;
using SecurityModule.Repository.Interface;
using SecurityModule.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _IUserRepository;
        private readonly IMapper _IMapper;

        public UserService(IUserRepository userRepository, IMapper iMapper)
        {
            _IUserRepository = userRepository;
            _IMapper = iMapper;
        }
        public UserProfileModel GetUserProfile(string username)
        { 
            ApiResponseModel apiResponse = new ApiResponseModel();
            UserProfileModel profile = new UserProfileModel();
            using (var _context = new SecurityDBContext())
            {
                UserRegistration userprofile =  _IUserRepository.GetUserProfile(username, _context);
                profile = _IMapper.Map<UserProfileModel>(userprofile);
            }
            return profile;
                
        }
    }
}