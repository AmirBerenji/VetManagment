using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetManageApi.Data;
using PetManageApi.DTOs;
using PetManageApi.Entities;
using PetManageApi.Services;

namespace PetManageApi.Controllers
{
    public class AuthController : BaseApiController
    {
        public AuthController(PetManageDbContext context, UserManager<AppUser> userManager) : base(context, userManager)
        {
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDTO model)
        {
            var result = await new UserManagment(_context, _userManager).LoginUser(model);
            var response = new ApiResponse<AppUserDTO>();
            if (result.userName == null)
            {
                response.Status = "error";
                response.Error = new ApiError
                {
                    Code = NotFound().StatusCode,
                    Message = "the username and password is not match",
                };
                return NotFound(response);
            }

            response.Status = "success";
            response.Data = result;

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("GetInformation")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = GetUserId();
            var userInfo = await new UserInformationManagment(_context).GetUserInfo(userId);
            var response = new ApiResponse<UserInformationDTO>();

            if (userInfo != null)
            {
                response.Status = "success";
                response.Data = userInfo;

                return Ok(response);
            }
            if (userInfo == null) 
            {
                response.Status = "error";
                response.Error = new ApiError
                {
                    Code = NotFound().StatusCode,
                    Message = "We can find information about your user"
                };
                return NotFound(response);
            }
            return BadRequest();
        }
    }
}
