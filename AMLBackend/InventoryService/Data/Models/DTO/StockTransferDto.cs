namespace InventoryService.Data.Models.DTO;

public class StockTransferDto
{
    public int StockEntryId { get; set; }
    public int BranchIdToTransferTo { get; set; }
    public int TransferCount { get; set; }
}