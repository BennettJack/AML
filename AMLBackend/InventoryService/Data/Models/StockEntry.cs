using InventoryService.Data.Models.Media;

namespace InventoryService.Data.Models;

public class StockEntry
{
    public int StockEntryId { get; set; }
    public MediaModelFormatConnection MediaModelFormatConnection { get; set; }
    public int BranchId { get; set; }
    public int StockCount { get; set; }
}