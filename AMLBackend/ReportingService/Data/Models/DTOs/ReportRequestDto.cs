using System.ComponentModel.DataAnnotations;

namespace ReportingService.Data.Models.DTOs;

public class ReportRequestDto
{
    [Required]
    public int BranchId { get; set; }
    [Required]
    public DateTime FromDate { get; set; }
    [Required]
    public DateTime ToDate { get; set; }
}