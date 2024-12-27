using BranchService.Data.Models.Branch;
using BranchService.Data.Repositories;
using Microsoft.VisualBasic;

namespace BranchService.Data.Services;

public class BranchService(BranchRepository _branchRepository)
{
    public async Task<Branch> GetBranchById(int id)
    {
        return await _branchRepository.GetBranchById(id);
    }

    public async Task<List<Branch>> GetAllBranches()
    {
        return await _branchRepository.GetAllBranches();
    }
}