using InventoryService.Data.Models;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Repositories;
using InventoryService.Data.Repositories.Interfaces;
using InventoryService.Data.Services;

namespace InventoryService.Data;

public class ComplexDataSeeder(IStockService _stockService, MediaModelService _mediaModelService, AttributeRepository _attributeRepository)
{
    public async void SeedData()
    {
        //Checks formatconnections, if none, creates
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
                            MediaModel = media,
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

        var borrowRecords = await _stockService.GetAllBorrowRecords();
        if (borrowRecords.Count == 0)
        {
            formatConnections = await _mediaModelService.GetAllMediaModelFormatConnections();
            var recList = new List<BorrowRecord>
            {
                new (){
                BorrowDate = DateTime.Today,
                BranchId = 3,
                CurrentlyBorrowing = true,
                MediaModelFormatConnection = formatConnections[3],
                RecordCreationDate = DateTime.Today,
                ReturnDate = DateTime.Today.AddDays(14),
                UserId = "5"
                },
                new (){
                    BorrowDate = DateTime.Today.AddDays(-6),
                    BranchId = 2,
                    CurrentlyBorrowing = true,
                    MediaModelFormatConnection = formatConnections[1],
                    RecordCreationDate = DateTime.Today.AddDays(-6),
                    ReturnDate = DateTime.Today.AddDays(-6),
                    UserId = "9"
                },
                new (){
                    BorrowDate = DateTime.Today.AddDays(-61),
                    BranchId = 3,
                    CurrentlyBorrowing = false,
                    MediaModelFormatConnection = formatConnections[9],
                    RecordCreationDate = DateTime.Today.AddDays(-61),
                    ReturnDate = DateTime.Today.AddDays(-61),
                    UserId = "5"
                },
                new (){
                    BorrowDate = DateTime.Today,
                    BranchId = 1,
                    CurrentlyBorrowing = true,
                    MediaModelFormatConnection = formatConnections[11],
                    RecordCreationDate = DateTime.Today,
                    ReturnDate = DateTime.Today.AddDays(14),
                    UserId = "1"
                },
                new (){
                    BorrowDate = DateTime.Today,
                    BranchId = 1,
                    CurrentlyBorrowing = true,
                    MediaModelFormatConnection = formatConnections[4],
                    RecordCreationDate = DateTime.Today,
                    ReturnDate = DateTime.Today.AddDays(14),
                    UserId = "1"
                },
            };
            foreach (var record in recList)
            {
                await _stockService.AddBorrowRecord(record);
            }
        }

        var reserveRecords = await _stockService.GetAllReserveRecords();
        if (reserveRecords.Count == 0)
        {
            formatConnections = await _mediaModelService.GetAllMediaModelFormatConnections();
            var recList = new List<ReserveRecord>
            {
                new()
                {
                    MediaModelFormatConnection = formatConnections[1],
                    UserId = "1",
                    BranchId = 2,
                    ReservationDate = DateTime.Today,
                    DateReservedFor = DateTime.Today.AddDays(9),
                    ReservationActive = true,
                    RecordCreationDate = DateTime.Today
                },
                new()
                {
                    MediaModelFormatConnection = formatConnections[8],
                    UserId = "11",
                    BranchId = 1,
                    ReservationDate = DateTime.Today,
                    DateReservedFor = DateTime.Today.AddDays(9),
                    ReservationActive = true,
                    RecordCreationDate = DateTime.Today
                },
                new()
                {
                    MediaModelFormatConnection = formatConnections[3],
                    UserId = "4",
                    BranchId = 1,
                    ReservationDate = DateTime.Today,
                    DateReservedFor = DateTime.Today.AddDays(9),
                    ReservationActive = true,
                    RecordCreationDate = DateTime.Today
                },
                new()
                {
                    MediaModelFormatConnection = formatConnections[5],
                    UserId = "2",
                    BranchId = 3,
                    ReservationDate = DateTime.Today,
                    DateReservedFor = DateTime.Today.AddDays(9),
                    ReservationActive = true,
                    RecordCreationDate = DateTime.Today
                },
                new()
                {
                    MediaModelFormatConnection = formatConnections[6],
                    UserId = "1",
                    BranchId = 3,
                    ReservationDate = DateTime.Today,
                    DateReservedFor = DateTime.Today.AddDays(9),
                    ReservationActive = true,
                    RecordCreationDate = DateTime.Today
                },
            };
            foreach (var rec in recList)
            {
                await _stockService.AddReserveRecord(rec);
            }
        }
    }
}