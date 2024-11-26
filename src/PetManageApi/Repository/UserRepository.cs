using Microsoft.AspNetCore.Identity;
using PetManageApi.Data;
using PetManageApi.DTOs;
using PetManageApi.Entities;
using PetManageApi.Helper;

namespace PetManageApi.Repository
{
    public class UserRepository
    {
        protected readonly PetManageDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(PetManageDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(AppUser user)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            return result;
        }

        public async Task<AppUser> LoginUser(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.userName);
            if (user == null) return new AppUser();
            var result = await _userManager.CheckPasswordAsync(user, model.password);

            if (result)
            {
                UserLoginInfo info = new UserLoginInfo(user.UserName, user.PasswordHash, user.UserName);
                await _userManager.AddLoginAsync(user, info);

                user.Token = CustomTokenProvider.CreateToken(user.UserName, user.Id); // await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "TestPurpose");
                await UpdateUserAsync(user);
                return user;
            }
            return new AppUser();
        }

        public async Task<AppUser> ForgotPassword(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            return result;
        }
        public async Task CreateForgotPasswordCodeAsync(AppUser model)
        {
            await UpdateUserAsync(model);
        }
        public async Task SetLockoutEnabled(AppUser user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            await UpdateUserAsync(user);

        }

        public async Task<AppUser> GetUserDetailById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public async Task<IdentityResult> SetTokenForUser(AppUser model)
        {
            return await UpdateUserAsync(model);
        }

        public async Task<AppUser> GetUserByToken(string token)
        {
            var result = _context.Users.Where(x => x.Token == token).FirstOrDefault();
            return result;
        }

        private async Task<IdentityResult> UpdateUserAsync(AppUser model)
        {
            var result = await _userManager.UpdateAsync(model);
            return result;
        }

        public async Task<List<string>> GetRoleUser(AppUser model)
        {
            var result = await _userManager.GetRolesAsync(model);
            return result.ToList();
        }
        public async Task<IdentityResultDTO> EditUserApp(AppUser model)
        {
            var result = await _userManager.UpdateAsync(model);
            return new IdentityResultDTO { success = result.Succeeded, };
        }


    }
}
