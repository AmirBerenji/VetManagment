using System.ComponentModel.DataAnnotations;

namespace PetManageApi.Entities
{
    public class Personal : BasicClass
    {
        public int Id { get; set; }
        [MaxLength(1500)]
        public string? Desc { get; set; }


        public int PersonalKindId { get; set; }
        public virtual PersonalKind PersonalKind { get; set; }
    }
}
