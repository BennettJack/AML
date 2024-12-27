using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories;
using InventoryService.Data.Services;

namespace InventoryService.Data;

public class ComplexDataSeeder(StockService _stockService, MediaModelService _mediaModelService, AttributeRepository _attributeRepository)
{
    public async void SeedData()
    {
        var formatConnections = _mediaModelService.GetAllMediaModelFormatConnections().Result;
        if (formatConnections.Count == 0)
        {
            var mediaModelEntries = _mediaModelService.GetAllMediaItems().Result;
            var formats =  _attributeRepository.GetAllFormats().Result;
            
            var bookFormats = new List<Format>
            {
                formats[0],
                formats[1],
                formats[2]
            };
            foreach (var media in mediaModelEntries)
            {
                foreach (var format in bookFormats)
                {
                    _mediaModelService.AddMediaModelFormatConnection(
                        new MediaModelFormatConnection
                        {
                            Media = media,
                            Format = format
                        });
                }
            }
        }
        //Checks stock records, if there are none, seed data
        var branchStockRecords = _stockService.GetAllBranchStockRecords().Result;
        if (branchStockRecords.Count == 0)
        {
            Random random = new Random();
            var mediaModelFormatConnectionList = _mediaModelService.GetAllMediaModelFormatConnections().Result;
            foreach (var connection in mediaModelFormatConnectionList)
            {
                for (int i = 1; i < 6; i++)
                {
                    var stockRecord = new BranchStockRecordDto
                    {
                        BranchId = i,
                        MediaModelFormatConnection = connection,
                        BorrowedCount = 0,
                        ReservedCount = 0,
                        StockCount = random.Next(10, 50)
                    };

                    await _stockService.AddBranchStockRecord(stockRecord);
                }
            }
            
        }
    }
}