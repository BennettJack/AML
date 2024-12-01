﻿using InventoryService.Data;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CdDVDController : ControllerBase
{
    private readonly InventoryDbContext _context;
    private readonly MediaModelRepository _mediaModelRepository;

    public CdDVDController(InventoryDbContext context, MediaModelRepository mediaModelRepository)
    {
        _context = context;
        _mediaModelRepository = mediaModelRepository;
    }
}