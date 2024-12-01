using InventoryService.Data.Models;

namespace InventoryService2.Data.Models
{
    public class Periodical
    {
        public int PeriodicalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public DateOnly PublishDate { get; set; }
        public Genre Genre { get; set; }
        public Publisher Publisher { get; set; }
        public int Availability { get; set; }
        public int PageCount { get; set; }
        public string PublicationType { get; set; }
    }
}
