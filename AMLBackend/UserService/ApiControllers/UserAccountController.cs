using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
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
    public async Task<IActionResult> RegisterNewUser([FromBody] string test)
    {
        return Ok();
    }
}