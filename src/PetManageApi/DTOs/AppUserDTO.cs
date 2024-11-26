using System.ComponentModel.DataAnnotations;

namespace PetManageApi.DTOs
{
    public class AppUserDTO
    {
        public string? id {  get; set; }
        public string userName {  get; set; }
        public string? email { get; set; }
        public string? token { get; set; }
        public string? forgotPasswordCode { get; set; }
        public DateTime? forgotPasswordTimeStamp { get; set; }
        public string? googleToken { get; set; }
        public string? profileIcon { get; set; }


    }
}
