using AutoMapper;
using PetManageApi.DTOs;
using PetManageApi.Entities;

namespace PetManageApi.Helper
{
    public class MappingAppUser : Profile
    {
        public static async  Task<AppUserDTO> ConvertModelToDto(AppUser model)
        {
            var dto = new AppUserDTO() 
            {
                email = model.Email,
                googleToken = model.GoogleToken,
                token = model.Token,
                userName = model.UserName,
                id = model.Id,
            };
            return dto;
        }

        public static AppUser ConvertDtoToModel(AppUserDTO dto)
        {
            var model = new AppUser()
            {
                Email = dto.email,
                GoogleToken = dto.googleToken,
                Token = dto.token,
                UserName = dto.userName,
                Id = dto.id,
            };
            return model;
        }
    }
}
