using BranchService.Data;
using BranchService.Data.Models.Branch;
using BranchService.Data.Models.DTO;
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
    [Route("GetBranches")]
    public async Task<IActionResult> GetBranches()
    {
        var branches = await _context.Branches.ToListAsync();
        return Ok(branches);
    }

    [HttpPost]
    [Route("AssignUserToBranch")]
    public async Task<IActionResult> AssignUserToBranch([FromBody] NewUserBranchConnectionDto newUserBranchConnection)
    {
        var connection = new BranchUserConnection
        {
            Branch = await _context.Branches.FirstOrDefaultAsync(branch =>
                branch.BranchId == newUserBranchConnection.BranchId),
            UserId = newUserBranchConnection.UserId
        };
        await _context.BranchUserConnections.AddAsync(connection);
        await _context.SaveChangesAsync();
        return Ok();
    }
}