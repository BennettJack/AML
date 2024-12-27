using InventoryService.Data;
using InventoryService.Data.Models.DTO;
using InventoryService.Data.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediaModelController : ControllerBase
{
    private readonly MediaModelService _mediaModelService;

    public MediaModelController(MediaModelService mediaModelService)
    {
        _mediaModelService = mediaModelService;
    }


    [HttpGet]
    [Route("GetAllMediaItems")]
    public async Task<IActionResult> GetAllMediaItems()
    {
        var mediaItems = await _mediaModelService.GetAllMediaItems();
        return Ok(mediaItems);
    }

    [HttpGet]
    [Route("GetMediaById")]
    public async Task<IActionResult> GetMediaById(int mediaId)
    {
        var mediaItem = await _mediaModelService.GetMediaItemById(mediaId);
        return Ok(mediaItem);
    }

}