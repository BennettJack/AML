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
    public Task<List<BorrowRecord>> GetBorrowRecordByDateAndBranch(int branchId, DateTime startDate, DateTime endDate);
    public Task<List<ReserveRecord>> GetReserveRecordByDateAndBranch(int branchId, DateTime startDate, DateTime endDate);

    public Task<List<BorrowRecord>> GetBranchBorrowRecordsByMedia(int mediaId, int branchId, DateTime startDate,
        DateTime endDate);

    public Task<List<ReserveRecord>> GetBranchReserveRecordsByMedia(int mediaId, int branchId, DateTime startDate,
        DateTime endDate);
}