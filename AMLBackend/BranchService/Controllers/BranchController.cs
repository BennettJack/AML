using BranchService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BranchService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchController : ControllerBase
{
    private readonly BranchDbContext _context;

    public BranchController(BranchDbContext branchDbContext)
    {
        _context = branchDbContext;
    }
    
    [HttpGet]
    [Route("UpdateBook")]
    public async Task<IActionResult> GetBranches()
    {
        var branches = await _context.Branches.ToListAsync();
        return Ok(branches);
    }
}