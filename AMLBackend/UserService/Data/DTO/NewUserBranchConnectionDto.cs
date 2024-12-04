using System.ComponentModel.DataAnnotations;

namespace BranchService.Data.Models.DTO;

public class NewUserBranchConnectionDto
{
    [Required]
    public int BranchId { get; set; }
    
    [Required]
    public string? UserId { get; set; }
}