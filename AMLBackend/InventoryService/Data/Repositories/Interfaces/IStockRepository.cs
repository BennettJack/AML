using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;

namespace InventoryService.Data.Repositories.Interfaces;

public interface IStockRepository
{
    Task UpdateStock(BranchStockRecord record);

    Task<List<BorrowRecord>> GetAllBorrowRecords();
    Task<BorrowRecord> GetBorrowRecordById(int id);
    Task<BorrowRecord> GetBorrowRecord(MediaModelFormatConnection formatConnection);
    Task<BorrowRecord> GetBorrowRecord(MediaModelFormatConnection formatConnection, int branchId);
    
    Task<ReserveRecord> GetReserveRecordById(int id);
    Task<ReserveRecord> GetReserveBorrowRecord(MediaModelFormatConnection formatConnection);
    Task<ReserveRecord> GetReserveRecord(MediaModelFormatConnection formatConnection, int branchId);
    
    Task AddBranchStockRecord(BranchStockRecord branchStockRecord);
    Task<List<BranchStockRecord>> GetAllBranchStockRecords();
    
    Task<BranchStockRecord> GetStockRecord(int mediaModelFormatConnectionId, int branchId);

    Task<List<BranchStockRecord>> GetStockRecords(int mediaId, int branchId);
    Task<List<BranchStockRecord>> GetStockRecords(int branchId);
    Task AddBorrowRecord(BorrowRecord record);
    Task AddReserveRecord(ReserveRecord record);
    Task<List<ReserveRecord>> GetAllReserveRecords();
    
    public Task<List<BorrowRecord>> GetBorrowRecordByDateAndBranch(int branchId, DateTime startDate, DateTime endDate);
    public Task<List<ReserveRecord>> GetReserveRecordByDateAndBranch(int branchId, DateTime startDate, DateTime endDate);
}