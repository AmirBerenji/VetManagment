using System.ComponentModel.DataAnnotations;

namespace PetManageApi.Entities
{
    public class Clinic : BasicClass
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string? ClinicName { get; set; }
        [MaxLength(1500)]
        public string? Desc { get; set; }
    }
}
