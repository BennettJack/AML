using InventoryService.Data.Models.Media;

namespace InventoryService.Data.Models;

public class MediaModelFormatConnection
{
    public int Id { get; set; }
    public MediaModel Media { get; set; }
    public Format Format { get; set; }
}