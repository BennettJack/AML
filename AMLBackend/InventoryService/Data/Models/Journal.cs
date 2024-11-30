using InventoryService.Data.Models.Media;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Models
{
    public class Journal : MediaModel
    {
        public int JournalId { get; set; }

    }
}
