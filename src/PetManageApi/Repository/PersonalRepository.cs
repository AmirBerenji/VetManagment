using PetManageApi.Data;
using PetManageApi.Entities;
using PetManageApi.Interface;

namespace PetManageApi.Repository
{
    public class PersonalRepository : GenericRepository<Personal>, IPersonalRepository
    {
        public PersonalRepository(PetManageDbContext context) : base(context)
        {
        }

        public Personal Add(Personal entity)
        {
            _context.Personals.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Edit(Personal entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Personal entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Personal> IGenericRepository<Personal>.GetAll()
        {
            throw new NotImplementedException();
        }

        Personal IGenericRepository<Personal>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
