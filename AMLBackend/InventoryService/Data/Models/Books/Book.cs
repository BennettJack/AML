using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Models
{
    public class Book
    {
        
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public Publisher? Publisher { get; set; }
        public int? PageCount { get; set; }
        public int? SerialNumber { get; set; }
    }
    
    
}
