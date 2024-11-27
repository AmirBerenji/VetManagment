namespace PetManageApi.Entities
{
    public class PersonalBranch : BasicClass
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public int BranchId { get; set; }

        public virtual Personal Personal { get; set; }
        public virtual Branch Branch { get; set; }

    }
}
