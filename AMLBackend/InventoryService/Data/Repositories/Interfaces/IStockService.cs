using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Data.Repositories.Interfaces;

public interface IStockService
{
    public Task<BorrowRecord> GetBorrowRecordById(int id);

    public Task<List<BranchStockRecordDto>> GetStockRecords(int mediaId);
    public Task<List<BranchStockRecordDto>> GetStockRecords(int mediaId, int branchId);

    public Task TransferStock(StockTransferDto stockTransferDto);

    public Task<List<BranchStockRecord>> GetAllBranchStockRecords();

    public Task AddBranchStockRecord(BranchStockRecordDto stockRecordDto);

    public Task<List<BorrowRecord>> GetAllBorrowRecords();

    public Task<List<ReserveRecord>> GetAllReserveRecords();

    public Task AddBorrowRecord(BorrowRecord record);

    public Task AddReserveRecord(ReserveRecord record);
}