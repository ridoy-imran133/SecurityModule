using AutoMapper;
using SecurityModule.Entities;
using SecurityModule.Helpers;
using SecurityModule.Models;
using SecurityModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Services
{
    public interface IRoleService
    {
        Task<List<RoleModel>> GetRoles();
    }
    public class RoleService : IRoleService
    {
        private readonly IMapper _IMapper;
        private readonly IRoleRepository _IRoleRepository;

        public RoleService(IMapper iMapper)
        {
            _IRoleRepository = new RoleRepository();
            _IMapper = iMapper;
        }

        public async Task<List<RoleModel>> GetRoles()
        {
            using (var _context = new SecurityDBContext())
            {
                try
                {
                    List<Role> em = await _IRoleRepository.GetRoles(_context);
                    var val = _IMapper.Map<List<RoleModel>>(em);
                    return val;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
                return new List<RoleModel>();
            }
        }
    }
}
