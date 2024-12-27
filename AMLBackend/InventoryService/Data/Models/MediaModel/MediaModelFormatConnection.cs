using InventoryService.Data.Models.Media;

namespace InventoryService.Data.Models;

public class MediaModelFormatConnection
{
    public int MediaModelFormatConnectionId { get; set; }
    public MediaModel MediaModel { get; set; }
    public Format Format { get; set; }
}