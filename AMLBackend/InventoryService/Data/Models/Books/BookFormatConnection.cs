namespace InventoryService.Data.Models;

public class BookFormatConnection
{
    public int Id { get; set; }
    public Book Book { get; set; }
    public Format Format { get; set; }
}