using InventoryService.Data.Models.CDDVD;
using InventoryService.Data.Models.Media;

namespace InventoryService.Data.Models
{
    public class CdDvd : MediaModel
    {
        public List<CdTrack> Tracks { get; set; }
    }
}
