using System.ComponentModel.DataAnnotations;

namespace PetManageApi.Entities
{
    public class PersonalKind : BasicClass 
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string KindName { get; set; }
    }
}
