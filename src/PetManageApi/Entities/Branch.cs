using System.ComponentModel.DataAnnotations;

namespace PetManageApi.Entities
{
    public class Branch : BasicClass
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public required string BranchName { get; set; }
        [MaxLength(1500)]
        public string? Address { get; set; }
        [MaxLength(150)]
        public required string Phone { get; set; }
        
        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
