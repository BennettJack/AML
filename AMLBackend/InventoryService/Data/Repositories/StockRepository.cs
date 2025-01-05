﻿using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Repositories;

public class StockRepository(InventoryDbContext _context) : IStockRepository
{
    public async Task UpdateStock(BranchStockRecord record)
    {
        var branchStockRecord = await _context.BranchStockRecords.FirstOrDefaultAsync(bsr =>
            bsr.BranchStockRecordId == record.BranchStockRecordId);
        branchStockRecord.StockCount = record.StockCount;
        await _context.SaveChangesAsync();
    }

    public async Task<List<BorrowRecord>> GetAllBorrowRecords()
    {
        return await _context.BorrowRecords.ToListAsync();
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

    public async Task<List<ReserveRecord>> GetAllReserveRecords()
    {
        return await _context.ReserveRecords.ToListAsync();
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
    public async Task<List<BranchStockRecord>> GetStockRecords(int mediaId, int branchId)
    {
           var records = _context.BranchStockRecords.Include(bsr => bsr.MediaModelFormatConnection.Format)
               .Include(bsr => bsr.MediaModelFormatConnection.MediaModel)
               .Where(bsr =>
                   bsr.BranchId == branchId && bsr.MediaModelFormatConnection.MediaModel.MediaModelId == mediaId).ToListAsync().Result;
        return records;
    }
    
    public async Task<List<BranchStockRecord>> GetStockRecords(int branchId)
    {
        var records = _context.BranchStockRecords.Include(bsr => bsr.MediaModelFormatConnection.Format)
            .Include(bsr => bsr.MediaModelFormatConnection.MediaModel)
            .Where(bsr =>
                bsr.BranchId == branchId).ToListAsync().Result;
        return records;
    }

    public async Task<BranchStockRecord> GetStockRecord(int mediaModelFormatConnectionId, int branchId)
    {
        BranchStockRecord record = await _context.BranchStockRecords.Include(r => r.MediaModelFormatConnection).FirstOrDefaultAsync(r =>
            r.BranchId == branchId && r.MediaModelFormatConnection.MediaModelFormatConnectionId == mediaModelFormatConnectionId);
        return record;
    }
    public async Task AddBorrowRecord(BorrowRecord record)
    {
        await _context.BorrowRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddReserveRecord(ReserveRecord record)
    {
        await _context.ReserveRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }
    
    
}