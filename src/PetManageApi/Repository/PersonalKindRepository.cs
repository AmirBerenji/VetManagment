using PetManageApi.Data;
using PetManageApi.Entities;
using PetManageApi.Interface;

namespace PetManageApi.Repository
{
    public class PersonalKindRepository : GenericRepository<PersonalKind>, IPersonalKindRepository
    {
        public PersonalKindRepository(PetManageDbContext context) : base(context)
        {
        }

        public PersonalKind Add(PersonalKind entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(PersonalKind entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(PersonalKind entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PersonalKind> IGenericRepository<PersonalKind>.GetAll()
        {
            var result = _context.PersonalKinds.AsEnumerable();
            return result;
        }

        PersonalKind IGenericRepository<PersonalKind>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
