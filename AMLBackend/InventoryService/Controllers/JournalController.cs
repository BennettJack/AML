using InventoryService.Data;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers;


[ApiController]
[Route("api/[controller]")]
public class JournalController : ControllerBase
{
    private readonly InventoryDbContext _context;
    private readonly MediaModelRepository _mediaModelRepository;

    public JournalController(InventoryDbContext context, MediaModelRepository mediaModelRepository)
    {
        _context = context;
        _mediaModelRepository = mediaModelRepository;
    }
}