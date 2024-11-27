using PetManageApi.Data;
using PetManageApi.Entities;
using PetManageApi.Interface;

namespace PetManageApi.Repository
{
    public class PersonalBranchRepository : GenericRepository<PersonalBranch>, IPersonalBranchRepository
    {
        public PersonalBranchRepository(PetManageDbContext context) : base(context)
        {
        }

        public PersonalBranch Add(PersonalBranch entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(PersonalBranch entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(PersonalBranch entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PersonalBranch> IGenericRepository<PersonalBranch>.GetAll()
        {
            throw new NotImplementedException();
        }

        PersonalBranch IGenericRepository<PersonalBranch>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
