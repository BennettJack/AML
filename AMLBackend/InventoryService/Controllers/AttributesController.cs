using InventoryService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttributesController : ControllerBase
{
    private readonly InventoryDbContext _context;

    public AttributesController(InventoryDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("GetGenresList")]
    public async Task<IActionResult> GetGenresList()
    {
        var genres = await _context.Genres.ToListAsync();
        return Ok(genres);
    }
    
    [HttpGet]
    [Route("GetAuthorsList")]
    public async Task<IActionResult> GetAuthorsList()
    {
        var authors = await _context.Authors.ToListAsync();
        return Ok(authors);
    }
    
    [HttpGet]
    [Route("GetPublishersList")]
    public async Task<IActionResult> GetPublishersList()
    {
        var publishers = await _context.Publishers.ToListAsync();
        return Ok(publishers);
    }
    
    [HttpGet]
    [Route("GetFormatsList")]
    public async Task<IActionResult> GetFormatsList()
    {
        var formats = await _context.Formats.ToListAsync();
        return Ok(formats);
    }
}