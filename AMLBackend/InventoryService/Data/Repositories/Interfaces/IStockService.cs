using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;

namespace InventoryService.Data.Repositories.Interfaces;

public interface IStockService
{
    public Task<BorrowRecord> GetBorrowRecordById(int id);

    public Task<List<BranchStockRecordDto>> GetStockRecords(int mediaId);
    public Task<List<BranchStockRecordDto>> GetStockRecords(int mediaId, int branchId);

    public Task TransferStock(StockTransferDto stockTransferDto);
}