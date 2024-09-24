using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AmlBackend.Data.Models.Users;

public class User : IdentityUser
{
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? OtherNames { get; set; }
}