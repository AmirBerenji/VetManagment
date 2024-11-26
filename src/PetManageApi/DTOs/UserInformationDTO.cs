using System.ComponentModel.DataAnnotations;

namespace PetManageApi.DTOs
{
    public class UserInformationDTO
    {
        public int? id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public string? address { get; set; }
        public string? userId { get; set; }
    }
}
