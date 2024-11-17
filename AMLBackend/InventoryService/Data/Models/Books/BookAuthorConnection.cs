namespace InventoryService.Data.Models;

public class BookAuthorConnection
{
    public int Id { get; set; }
    public Book Book { get; set; }
    public Author Author { get; set; }
}