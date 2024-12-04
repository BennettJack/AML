using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using BranchService.Data.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Data.DTO;
using UserService.Data.Models.Users;

namespace UserService.ApiControllers;

[ApiController]
[Route("api/[controller]")]
public class UserAccountController : ControllerBase
{
    private readonly UserDbContext _context;
    private readonly UserManager<User> _userManager;

    public UserAccountController(UserDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    [HttpPost]
    [Route("RegisterNewUser")]
    public async Task<IActionResult> RegisterNewUser([FromBody] NewMemberDto newMemberRequest)
    {
        var user = new User
        {
            UserName = newMemberRequest.Username,
            Email = newMemberRequest.Email,
            Name = newMemberRequest.Name
        };

        var identityUser = await _userManager.CreateAsync(user, newMemberRequest.Password);
        if (identityUser.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "Member");
        }

        var userDbo = await _context.Users.FirstOrDefaultAsync(u =>
            u.UserName == user.UserName);
        var connectionDto = new NewUserBranchConnectionDto
        {
            BranchId = newMemberRequest.BranchId,
            UserId = userDbo.Id
        };

        using StringContent connJson = new(JsonSerializer.Serialize(connectionDto), Encoding.UTF8, "application/json");
        HttpClient client = new HttpClient();
        var res = await client.PostAsync("https://localhost:7095/BranchService/api/Branch/AssignUserToBranch", connJson);
        var test = "";
        return Ok();
    }
}