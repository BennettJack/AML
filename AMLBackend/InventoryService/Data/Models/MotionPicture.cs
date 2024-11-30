using InventoryService.Data.Models.Media;

namespace InventoryService.Data.Models;

public class MotionPicture : MediaModel
{
    public int MotionPictureId { get; set; }
    public float Runtime { get; set; }
}