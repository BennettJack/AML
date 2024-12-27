using BranchService.Data.Models.Branch;
using Microsoft.EntityFrameworkCore;

namespace BranchService.Data.Repositories;

public class BranchRepository(BranchDbContext _context): IBranchRepository
{
    public Task<List<Branch>> GetAllBranches()
    {
        return _context.Branches.ToListAsync();
    }

    public Task<Branch> GetBranchById(int id)
    {
        return _context.Branches.FirstOrDefaultAsync(b => b.BranchId == id);
    }
}