using Microsoft.AspNetCore.Identity;

namespace UserService.Data.Models.Users;

public class User : IdentityUser
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}