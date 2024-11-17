namespace InventoryService.Data.Models;

public class BookGenreConnection
{
    public int Id { get; set; }
    public Book Book { get; set; }
    public Genre Genre { get; set; }
}