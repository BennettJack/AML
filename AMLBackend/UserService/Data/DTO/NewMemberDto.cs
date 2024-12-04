using System.ComponentModel.DataAnnotations;

namespace UserService.Data.DTO;

public class NewMemberDto
{
    [Required]
    public string? Username { get; set; }
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    public string? Password { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public int BranchId { get; set; }
}