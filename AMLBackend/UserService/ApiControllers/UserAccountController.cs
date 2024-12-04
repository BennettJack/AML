using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        return Ok();
    }
}