using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Data.Services;

public class StockService(StockRepository stockRepository)
{
    public Task TransferStock(long serialNumber, int count, int branchId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BranchStockRecord>> GetAllBranchStockRecords()
    {
        return await stockRepository.GetAllBranchStockRecords();
    }

    public async Task AddBranchStockRecord(BranchStockRecordDto stockRecordDto)
    {
        var branchStockRecord = new BranchStockRecord
        {
            BranchId = stockRecordDto.BranchId,
            MediaModelFormatConnection = stockRecordDto.MediaModelFormatConnection,
            BorrowedCount = stockRecordDto.BorrowedCount,
            ReservedCount = stockRecordDto.ReservedCount,
            StockCount = stockRecordDto.StockCount
        };
        await stockRepository.AddBranchStockRecord(branchStockRecord);
    }
}