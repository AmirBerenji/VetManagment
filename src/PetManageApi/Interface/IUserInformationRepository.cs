using PetManageApi.Entities;

namespace PetManageApi.Interface
{
    public interface IUserInformationRepository : IGenericRepository<UserInformation>
    {
        UserInformation GetByUserId(string userId);
    }
}
