using PetManageApi.Data;
using PetManageApi.Entities;
using PetManageApi.Interface;

namespace PetManageApi.Repository
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(PetManageDbContext context) : base(context)
        {
        }

        public Branch Add(Branch entity)
        {
            _context.Branches.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Edit(Branch entity)
        {
            throw new NotImplementedException();
        }

        public List<Branch> GetAllByClinic(int clinicId)
        {
            var list = _context.Branches.Where(x => x.Id == clinicId).ToList();
            return list;    
        }

        public void Remove(Branch entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Branch> IGenericRepository<Branch>.GetAll()
        {
            throw new NotImplementedException();
        }

        Branch IGenericRepository<Branch>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
