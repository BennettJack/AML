using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Repositories;

public class StockRepository(InventoryDbContext _context) : IStockRepository
{
    public Task UpdateStock(long serialNumber, int count, int branchId)
    {
        throw new NotImplementedException();
    }

    public Task<List<BorrowRecord>> GetAllBorrowRecords()
    {
        throw new NotImplementedException();
    }

    public Task<BorrowRecord> GetBorrowRecordById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BorrowRecord> GetBorrowRecord(MediaModelFormatConnection formatConnection)
    {
        throw new NotImplementedException();
    }

    public Task<BorrowRecord> GetBorrowRecord(MediaModelFormatConnection formatConnection, int branchId)
    {
        throw new NotImplementedException();
    }

    public Task<ReserveRecord> GetReserveRecordById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ReserveRecord> GetReserveBorrowRecord(MediaModelFormatConnection formatConnection)
    {
        throw new NotImplementedException();
    }

    public Task<ReserveRecord> GetReserveRecord(MediaModelFormatConnection formatConnection, int branchId)
    {
        throw new NotImplementedException();
    }

    public async Task AddBranchStockRecord(BranchStockRecord branchStockRecord)
    {
        await _context.BranchStockRecords.AddAsync(branchStockRecord);
        await _context.SaveChangesAsync();
    }

    public async Task<List<BranchStockRecord>> GetAllBranchStockRecords()
    {
        return await _context.BranchStockRecords.ToListAsync();
    }

    public async Task<List<BranchStockRecord>> GetStockRecords(int branchId, int mediaId)
    {
           var records = _context.BranchStockRecords.Where(r =>
            r.BranchId == branchId && r.MediaModelFormatConnection.MediaModel.MediaModelId == mediaId).ToListAsync().Result;
        return records;
    }

    public async Task<BranchStockRecord> GetStockRecord(BranchStockRecord record)
    {
        BranchStockRecord test = await _context.BranchStockRecords.FirstOrDefaultAsync(r =>
            r.BranchStockRecordId == record.BranchStockRecordId);
        return test;
    }
    public Task AddBorrowRecord(BranchStockRecord branchStockRecord)
    {
        throw new NotImplementedException();
    }
}