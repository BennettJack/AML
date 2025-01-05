using System.ComponentModel.DataAnnotations;

namespace ReportingService.Data.Models.DTOs;

public class ReportRequestWithMediaIdDto : ReportRequestDto
{
    [Required]
    public int MediaModelId { get; set; }
}