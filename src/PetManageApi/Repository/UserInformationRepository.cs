using PetManageApi.Data;
using PetManageApi.Entities;
using PetManageApi.Interface;

namespace PetManageApi.Repository
{
    public class UserInformationRepository : GenericRepository<UserInformation>, IUserInformationRepository
    {
        public UserInformationRepository(PetManageDbContext context) : base(context)
        {
        }

        public UserInformation Add(UserInformation entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserInformation entity)
        {
            throw new NotImplementedException();
        }

        public UserInformation GetByUserId(string userId)
        {
            var result = _context.UsersInfo.FirstOrDefault(x => x.UserId == userId);
            return result;
        }

        public void Remove(UserInformation entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserInformation> IGenericRepository<UserInformation>.GetAll()
        {
            throw new NotImplementedException();
        }

        UserInformation IGenericRepository<UserInformation>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
