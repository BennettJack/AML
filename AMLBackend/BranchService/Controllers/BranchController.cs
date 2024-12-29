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
    private readonly Data.Services.BranchService _branchService;

    public BranchController(BranchDbContext branchDbContext, Data.Services.BranchService branchService)
    {
        _context = branchDbContext;
        _branchService = branchService;
    }
    
    [HttpGet]
    [Route("GetAllBranches")]
    public async Task<IActionResult> GetAllBranches()
    {
        var branches = _branchService.GetAllBranches().Result;
        return Ok(branches);
    }
    
    [HttpGet]
    [Route("GetBranchById")]
    public async Task<IActionResult> GetBranchById([FromBody] int branchId)
    {
        var branch = _branchService.GetBranchById(branchId);
        return Ok(branch);
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