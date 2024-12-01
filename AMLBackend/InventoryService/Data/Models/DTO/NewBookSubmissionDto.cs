using System.ComponentModel.DataAnnotations;

namespace InventoryService.Data.Models.DTO;

public class NewBookSubmissionDto
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public List<int>? AuthorIds { get; set; }
    [Required]
    public string? PublishDate { get; set; }
    [Required]
    public List<int>? GenreIds { get; set; }
    [Required]
    public List<int>? FormatIds { get; set; }
    [Required]
    public int PublisherId { get; set; }
    [Required]
    public int PageCount { get; set; }
    [Required]
    public long SerialNumber { get; set; }
}