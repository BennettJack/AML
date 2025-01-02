using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories;
using InventoryService.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Data.Services;

public class StockService(IStockRepository stockRepository) : IStockService
{
    public async Task TransferStock(StockTransferDto stockTransferDto)
    {
        foreach (var update in stockTransferDto.StockUpdates)
        {
            var recordToReduce = await stockRepository.GetStockRecord(update.MediaModelFormatConnectionId
                , stockTransferDto.CurrentBranchId);
            recordToReduce.StockCount -= update.StockToTransfer;
            await stockRepository.UpdateStock(recordToReduce);
            var recordToIncrease = await stockRepository.GetStockRecord(update.MediaModelFormatConnectionId
                , stockTransferDto.TargetBranchId);
            recordToIncrease.StockCount += update.StockToTransfer;
            await stockRepository.UpdateStock(recordToIncrease);
        }
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
    
    public async Task<List<BranchStockRecordDto>> GetStockRecords(int mediaId, int branchId)
    {
        
        var records = stockRepository.GetStockRecords(mediaId, branchId).Result;
        var dtoList = GenerateBranchStockRecordDto(records);

        return dtoList;
    }
    
    private List<BranchStockRecordDto> GenerateBranchStockRecordDto(List<BranchStockRecord> records)
    {
        var dtoList = new List<BranchStockRecordDto>();
        foreach (var record in records)
        {
            dtoList.Add(new BranchStockRecordDto
            {
                BranchId = record.BranchId,
                MediaModelFormatConnection = record.MediaModelFormatConnection,
                BorrowedCount = record.BorrowedCount,
                ReservedCount = record.ReservedCount,
                StockCount = record.StockCount
            });
        }

        return dtoList;
    }
    
    public async Task<List<BranchStockRecordDto>> GetStockRecords(int branchId)
    {
        
        var records = stockRepository.GetStockRecords(branchId).Result;
        var dtoList = new List<BranchStockRecordDto>();
        foreach (var record in records)
        {
            dtoList.Add(new BranchStockRecordDto
            {
                BranchId = record.BranchId,
                MediaModelFormatConnection = record.MediaModelFormatConnection,
                BorrowedCount = record.BorrowedCount,
                ReservedCount = record.ReservedCount,
                StockCount = record.StockCount
            });
        }

        return dtoList;
    }

    public async Task<List<BorrowRecord>> GetAllBorrowRecords()
    {
        return await stockRepository.GetAllBorrowRecords();
    }
    
    public async Task<List<ReserveRecord>> GetAllReserveRecords()
    {
        return await stockRepository.GetAllReserveRecords();
    }

    public async Task AddBorrowRecord(BorrowRecord record)
    {
        await stockRepository.AddBorrowRecord(record);
    }

    public async Task AddReserveRecord(ReserveRecord record)
    {
        await stockRepository.AddReserveRecord(record);
    }

    public async Task<BorrowRecord> GetBorrowRecordById(int id)
    {
        return await stockRepository.GetBorrowRecordById(id);
    }
}