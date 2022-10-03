using AutoMapper;
using SecurityModule.Entities;
using SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Helpers
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<Module, ModuleModel>();
            CreateMap<Project, ProjectModel>();
            CreateMap<Role, RoleModel>();
            CreateMap<RoleWiseScreenPermission, RoleWiseScreenPermissionModel>();
            CreateMap<Screen, ScreenModel>();
            CreateMap<UserLogin, UserLoginModel>();
            CreateMap<UserRegistration, UserRegistrationModel>();
            CreateMap<UserWiseProjectPermission, UserWiseProjectPermissionModel>();
            CreateMap<UserWiseRolePermission, UserWiseRolePermissionModel>();
        }
    }
}
