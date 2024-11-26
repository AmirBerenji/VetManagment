using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetManageApi.Data;
using PetManageApi.Entities;
using System.Security.Claims;

namespace PetManageApi.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly PetManageDbContext _context;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly string _petImage;
        protected readonly string _petShopImage;

        public BaseApiController(UserManager<AppUser> userManager, PetManageDbContext context)
        {
            _context = context;
            _petImage = Path.GetFullPath(@"..\API\wwwroot\Images\PetImage");
            _petShopImage = Path.GetFullPath(@"..\API\wwwroot\Images\PetShopImage");
        }
        public BaseApiController(PetManageDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _petImage = Path.GetFullPath(@"..\API\wwwroot\Images\PetImage");
            _petShopImage = Path.GetFullPath(@"..\API\wwwroot\Images\PetShopImage");
        }

        protected string GetUserId()
        {
            var userId = "";
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                userId = claims.Where(p => p.Type == "aspid").FirstOrDefault()?.Value;
            }
            return userId;
        }


    }

    public class ApiResponse<T>
    {
        public string? Status { get; set; }
        public T? Data { get; set; }
        public ApiError? Error { get; set; }
        public ApiMeta? Meta { get; set; }
    }

    public class ApiError
    {
        public int? Code { get; set; }
        public string? Message { get; set; }
        public List<string>? Details { get; set; }
    }

    public class ApiMeta
    {
        public int? CurrentPage { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalItems { get; set; }
    }

}
