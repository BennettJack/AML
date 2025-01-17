﻿using Microsoft.AspNetCore.Mvc;
using ReportingService.Data.Models.DTOs;
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
        return Ok();
    }

    [HttpPost]
    [Route("ConvertTableToExcel")]
    public async Task<IActionResult> ConvertTableToExcel([FromBody] HtmlContentDto htmlContent)
    {
        try
        {
            var workbook = await _reportingService.ConvertTableToExcel(htmlContent.HtmlContent);
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "report";
            var stream = new MemoryStream();

            workbook.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);

            // Return the file as a FileResult
            return File(
                stream,
                contentType,
                fileName
            );

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}