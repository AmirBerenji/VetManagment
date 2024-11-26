using PetManageApi.Data;
using PetManageApi.DTOs;
using PetManageApi.Entities;
using PetManageApi.Repository;

namespace PetManageApi.Services
{
    public class BranchManagment
    {
        private readonly BranchRepository _repository;
        public BranchManagment(PetManageDbContext context)
        {
            _repository = new BranchRepository(context);
        }

        public async Task<List<BranchDTO>> AddBranch(BranchDTO model, string userId)
        {
            var branch = new Branch
            {
                BranchName = model.branchName,
                Phone = model.phone,
                Address = model.address,
                ClinicId = model.clinicId,
                RegisterTime = DateTime.UtcNow,
                RegisterUserRef = userId,
                IsDelete = false
            };

            var result = _repository.Add(branch);
            var listBranchDTO = new List<BranchDTO>();
            if (result.Id > 0)
            {
                var list = _repository.GetAllByClinic(result.ClinicId);
                
                foreach (var item in list) 
                {
                    var dto = new BranchDTO()
                    {
                        address = item.Address,
                        branchName = item.BranchName,
                        clinicId = item.ClinicId,
                        id = item.Id,
                        phone = item.Phone,
                    };

                    listBranchDTO.Add(dto); 
                }

                return  listBranchDTO;

            }
            return listBranchDTO;

        }

        public async Task<List<BranchDTO>> GetAllBranchByClinic(int clinicId, string userId)
        {
            var list = _repository.GetAllByClinic(clinicId);
            var listBranchDTO = new List<BranchDTO>();

            foreach (var item in list)
            {
                var dto = new BranchDTO()
                {
                    address = item.Address,
                    branchName = item.BranchName,
                    clinicId = item.ClinicId,
                    id = item.Id,
                    phone = item.Phone,
                };

                listBranchDTO.Add(dto);
            }

            return listBranchDTO;
        }
    
    }
}
