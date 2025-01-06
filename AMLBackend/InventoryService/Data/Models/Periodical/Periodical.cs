using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using InventoryService.Data.Models.Media;

namespace InventoryService.Data.Models
{
    public class Periodical : MediaModel
    {
        
        public int? PageCount { get; set; }
        
    }
    
    
}