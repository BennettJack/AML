using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Models.CDDVD;

[PrimaryKey("TrackId")]
public class CdTrack
{
    public int TrackId { get; set; }
    public string TrackName { get; set; }
    public CdDvd CdDvd { get; set; }
}