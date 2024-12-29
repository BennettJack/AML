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
}