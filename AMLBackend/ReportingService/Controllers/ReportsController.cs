using Microsoft.AspNetCore.Mvc;
using ReportingService.Services;
using ReportingService.Services.Interfaces;

namespace ReportingService.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IReportGenerationService _reportingService;

    public ReportsController(IReportGenerationService service)
    {
        _reportingService = service;
    }

    [HttpGet]
    [Route("test")]
    public async Task<IActionResult> Test()
    {
        return Ok(_reportingService.Test());
    }
}