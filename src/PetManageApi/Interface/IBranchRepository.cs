using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetManageApi.Entities;

namespace PetManageApi.Interface
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        List<Branch> GetAllByClinic(int clinicId);
    }
}