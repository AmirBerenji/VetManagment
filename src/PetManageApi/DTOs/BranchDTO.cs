using System.ComponentModel.DataAnnotations;

namespace PetManageApi.DTOs
{
    public class BranchDTO
    {
        public int id { get; set; }
        public string? branchName { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
        public int clinicId { get; set; }
    }
}
