using Microsoft.EntityFrameworkCore;

namespace InventoryService2.Data.Models
{
    public class Book
    {
        
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public DateOnly PublishDate { get; set; }
        public Genre Genre { get; set; }
        public Publisher Publisher { get; set; }
        public int Availability {  get; set; }
        public int PageCount { get; set; }
        public string Type { get; set; }

        public Book() { }
    }
}
