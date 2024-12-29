namespace InventoryService.Data.Models.DTO;

public class StockTransferDto
{
    public int CurrentBranchId { get; set; }
    public int TargetBranchId { get; set; }
    public List<StockUpdate> StockUpdates  { get; set; }
}

public class StockUpdate()
{
    public int MediaModelFormatConnectionId { get; set; }
    public int StockToTransfer { get; set; }
}