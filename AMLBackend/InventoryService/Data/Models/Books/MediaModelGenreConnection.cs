using InventoryService.Data.Models.Media;

namespace InventoryService.Data.Models;

public class MediaModelGenreConnection
{
    public int Id { get; set; }
    public MediaModel Media { get; set; }
    public Genre Genre { get; set; }
}