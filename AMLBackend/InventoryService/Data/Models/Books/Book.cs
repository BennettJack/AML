using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Models
{
    public class Book
    {
        
        public int BookId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime? PublishDate { get; set; }
        [Required]
        public Publisher? Publisher { get; set; }
        [Required]
        public int? PageCount { get; set; }
        [Required]
        public int? SerialNumber { get; set; }
        
    }
}
