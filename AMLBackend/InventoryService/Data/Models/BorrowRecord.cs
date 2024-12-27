namespace InventoryService.Data.Models;

public class BorrowRecord
{
    public int BorrowRecordId { get; set; }
    public MediaModelFormatConnection MediaModelFormatConnection { get; set; }
    public string UserId { get; set; }
    public int BranchId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}