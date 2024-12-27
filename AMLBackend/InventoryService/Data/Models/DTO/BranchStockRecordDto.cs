namespace InventoryService.Data.Models.DTO;

public class BranchStockRecordDto
{
    public int BranchId;
    public MediaModelFormatConnection MediaModelFormatConnection { get; set; }
    public int StockCount { get; set; }
    public int BorrowedCount { get; set; }
    public int ReservedCount { get; set; }
}