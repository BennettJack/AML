using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Models;

public class BookStockEntry
{
    public int BookStockEntryId { get; set; }
    public MediaModelFormatConnection MediaModelFormatConnection { get; set; }
    public int StockCount { get; set; }
}