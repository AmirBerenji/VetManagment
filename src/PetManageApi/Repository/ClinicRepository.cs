using PetManageApi.Data;
using PetManageApi.Entities;
using PetManageApi.Interface;

namespace PetManageApi.Repository
{
    public class ClinicRepository : GenericRepository<Clinic>, IClinicRepository
    {
        public ClinicRepository(PetManageDbContext context) : base(context)
        {
            
        }

        public Clinic Add(Clinic entity)
        {
            _context.Clinics.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Edit(Clinic entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Clinic entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Clinic> IGenericRepository<Clinic>.GetAll()
        {
            throw new NotImplementedException();
        }

        Clinic IGenericRepository<Clinic>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
