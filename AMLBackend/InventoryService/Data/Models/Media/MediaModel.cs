namespace InventoryService.Data.Models.Media;

public class MediaModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? PublishDate { get; set; }
    public long? SerialNumber { get; set; }
}