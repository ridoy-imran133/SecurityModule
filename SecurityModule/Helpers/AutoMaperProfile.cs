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
            CreateMap<Project, ProjectModel>();
            CreateMap<ProjectModel, Project>();
            CreateMap<Module, ModuleModel>();
            CreateMap<ModuleModel, Module>();
            CreateMap<Screen, ScreenModel>();
            CreateMap<ScreenModel, Screen>();
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();
            CreateMap<RoleWiseScreenPermission, RoleWiseScreenPermissionModel>();            
            CreateMap<UserLogin, UserLoginModel>();
            CreateMap<UserRegistration, UserRegistrationModel>();
            CreateMap<UserRegistration, UserLoggedInDetailsModel>();
            CreateMap<UserRegistrationModel, UserRegistration>();            
            CreateMap<UserWiseProjectPermission, UserWiseProjectPermissionModel>();
            CreateMap<UserWiseProjectRolePermission, UserWiseProjectRolePermissionModel>();
        }
    }
}
