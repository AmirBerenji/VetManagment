namespace PetManageApi.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        void Remove(T entity);
        void Edit(T entity);
    }
}
