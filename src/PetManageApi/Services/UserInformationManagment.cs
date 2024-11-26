using PetManageApi.Data;
using PetManageApi.DTOs;
using PetManageApi.Repository;

namespace PetManageApi.Services
{
    public class UserInformationManagment
    {
        private readonly UserInformationRepository _reposotory;
        public UserInformationManagment(PetManageDbContext context)
        {
            _reposotory = new UserInformationRepository(context);
        }

        public async Task<UserInformationDTO> GetUserInfo(string userId)
        {
            var userInfo = _reposotory.GetByUserId(userId);

            var userInfoDTO = new UserInformationDTO()
            {
                address = userInfo.Address,
                firstName = userInfo.FirstName,
                lastName = userInfo.LastName,
                email = userInfo.Email,
                phoneNumber = userInfo.PhoneNumber,
                userId = userId
            };

            return userInfoDTO;
        }
    }
}
