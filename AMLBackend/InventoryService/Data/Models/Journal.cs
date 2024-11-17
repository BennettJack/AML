using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Models
{
    public class Journal
    {
        public int JournalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateOnly PublishDate { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int Availability { get; set; }
        public int PageCount { get; set; }
        public string Type { get; set; }

        public Journal() { }
    }
}
