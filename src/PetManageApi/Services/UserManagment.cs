using Microsoft.AspNetCore.Identity;
using PetManageApi.Data;
using PetManageApi.DTOs;
using PetManageApi.Entities;
using PetManageApi.Helper;
using PetManageApi.Repository;

namespace PetManageApi.Services
{
    public class UserManagment
    {
        private readonly UserRepository _reposotory;

        protected readonly UserManager<AppUser> _userManager;
        public UserManagment(PetManageDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _reposotory = new UserRepository(context, _userManager);
        }

        public async Task<AppUserDTO> LoginUser(LoginDTO model)
        {
            var user = await _reposotory.LoginUser(model);
            var result  = await MappingAppUser.ConvertModelToDto(user);
            return result;
        }

    }
}
