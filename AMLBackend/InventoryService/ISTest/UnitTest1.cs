using InventoryService.Controllers;
using InventoryService.Data;
using InventoryService.Data.Models;
using InventoryService.Data.Repositories;
using InventoryService.Data.Repositories.Interfaces;
using InventoryService.Data.Services;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ISTest;

public class UnitTest1
{

    public UnitTest1()
    {
       
    }
        
    [Fact]
    public async void GetBorrowRecordById()
    {
        //Assert
        var mockSet = new Mock<DbSet<BorrowRecord>>();
        var data = GetBorrowRecordTestData().AsQueryable();
        mockSet.As<IQueryable<BorrowRecord>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<BorrowRecord>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<BorrowRecord>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<BorrowRecord>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
        var mockContext = new Mock<InventoryDbContext>();
        
        mockContext.Setup(c => c.BorrowRecords).ReturnsDbSet(GetBorrowRecordTestData());
        var stockRepository = new StockRepository(mockContext.Object);
        var test = await stockRepository.GetBorrowRecordById(1);

        Assert.NotNull(test);

    }

    private List<BorrowRecord> GetBorrowRecordTestData()
    {
        var record = new List<BorrowRecord>{
        new() {
            BorrowRecordId = 1,
            BranchId = 4,
            CurrentlyBorrowing = false,
            BorrowDate = DateTime.Today.AddDays(-30),
            ReturnDate = DateTime.Today.AddDays(-26),
            UserId = "92",
            MediaModelFormatConnection = new MediaModelFormatConnection
            {
                Format = new Format
                {
                    FormatId = 8,
                    FormatName = "Horror"
                },
                MediaModel = new Book
                {
                    MediaModelId = 1,
                    Description = "BOOK 1 DESCRIPTION",
                    PageCount = 300,
                    PublishDate = new(1992, 12, 4),
                    FullImageUrl = "Book1PlaceholderImage.png",
                    SerialNumber = 4892109905,
                    Title = "Book 1"
                },
            }
            }
        };
        
        return record;
    }
}