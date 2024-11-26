using PetManageApi.Data;
using PetManageApi.Interface;

namespace PetManageApi.Repository
{
    
        public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            protected readonly PetManageDbContext _context;

            public GenericRepository(PetManageDbContext context)
            {
                _context = context;
            }
            public T Add(T entity)
            {
                throw new NotImplementedException();
            }

            public void Edit(T entity)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<T> GetAll()
            {
                throw new NotImplementedException();
            }

            public IEnumerable<T> GetAll(int languageId)
            {
                throw new NotImplementedException();
            }

            public T GetById(int id)
            {
                throw new NotImplementedException();
            }

            public T GetById(int id, int languageId)
            {
                throw new NotImplementedException();
            }

            public void Remove(T entity)
            {
                throw new NotImplementedException();
            }
        }
    }
