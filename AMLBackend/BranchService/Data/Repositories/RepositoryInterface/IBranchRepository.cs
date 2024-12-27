using BranchService.Data.Models.Branch;

namespace BranchService.Data;

public interface IBranchRepository
{
    public Task<List<Branch>> GetAllBranches();
    public Task<Branch> GetBranchById(int id);
}