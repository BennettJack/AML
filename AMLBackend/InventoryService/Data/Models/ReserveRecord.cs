namespace InventoryService.Data.Models;

public class ReserveRecord
{
    public int ReserveRecordId { get; set; }
    public MediaModelFormatConnection MediaModelFormatConnection { get; set; }
    public string UserId { get; set; }
    public int BranchId { get; set; }
    public DateTime ReservationDate { get; set; }
}