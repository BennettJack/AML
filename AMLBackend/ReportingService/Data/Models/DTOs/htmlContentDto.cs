using System.ComponentModel.DataAnnotations;

namespace ReportingService.Data.Models.DTOs;

public class HtmlContentDto
{
    [Required]
    public string? HtmlContent { get; set; }
}