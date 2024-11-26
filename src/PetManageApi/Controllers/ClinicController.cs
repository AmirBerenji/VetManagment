using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetManageApi.Data;
using PetManageApi.DTOs;
using PetManageApi.Entities;
using PetManageApi.Services;

namespace PetManageApi.Controllers
{
    public class ClinicController : BaseApiController
    {
        public ClinicController(PetManageDbContext context) : base(context)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddClinic(ClinicDTO model)
        { 
            var response = new ApiResponse<ClinicDTO>();

            var userId = GetUserId();

            var result  = await new ClinicManagment(_context).AddClinic(model, userId);

            if (result.id != null || result.id > 0)
            {
                response.Status = "success";
                response.Data = result;
                return Ok(response);
            }
            else
            {
                response.Status = "error";
                response.Error.Message = "Your clinic is not saved";
                response.Error.Code = BadRequest().StatusCode;
                return BadRequest(response);
            }
            
        }
    }
}
