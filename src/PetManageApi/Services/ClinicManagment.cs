using PetManageApi.Data;
using PetManageApi.DTOs;
using PetManageApi.Entities;
using PetManageApi.Repository;

namespace PetManageApi.Services
{
    public class ClinicManagment
    {
        private readonly ClinicRepository _repository;
        private PetManageDbContext _context;
        public ClinicManagment(PetManageDbContext context)
        {
            _repository = new ClinicRepository(context);
            _context = context;
        }

        public async Task<ClinicDTO> AddClinic(ClinicDTO model,string userId)
        {
            try
            {
                var clinic = new Clinic
                {
                    ClinicName = model.clinicName,
                    Desc = model.desc,
                    IsDelete = false,
                    RegisterTime = DateTime.UtcNow,
                    RegisterUserRef = userId,
                };

                var result = _repository.Add(clinic);

                var clinicDTO = new ClinicDTO
                {
                    clinicName = result.ClinicName,
                    desc = result.Desc,
                    id = result.Id,
                };

                var branch = new BranchDTO
                {
                    branchName = result.ClinicName,
                    address = "",
                    clinicId = result.Id,
                    phone = ""
                };
                await new BranchManagment(_context).AddBranch(branch, userId);

                return clinicDTO;
            }
            catch (Exception)
            {
                return new ClinicDTO();
            }
        }
    }
}
