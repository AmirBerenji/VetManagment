using System.ComponentModel.DataAnnotations;

namespace PetManageApi.DTOs
{
    public class ClinicDTO
    {
        public int? id { get; set; }
        
        public string? clinicName { get; set; }
        
        public string? desc { get; set; }
    }
}
