using System.ComponentModel.DataAnnotations;

namespace InventoryService.Data.Models;

public class Format
{
    public int FormatId { get; set; }
    
    public string FormatName { get; set; }
}