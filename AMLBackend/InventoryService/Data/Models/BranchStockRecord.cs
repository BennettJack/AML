namespace InventoryService.Data.Models;

public class BranchStockRecord
{
    public int BranchStockRecordId { get; set; }
    public int BranchId { get; set; }
    public MediaModelFormatConnection? MediaModelFormatConnection { get; set; }
    public int StockCount { get; set; }
    public int BorrowedCount { get; set; }
    public int ReservedCount { get; set; }
}