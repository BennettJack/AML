using System.Data;
using ClosedXML.Excel;
using HtmlAgilityPack;
using ReportingService.Repositories;
using ReportingService.Repositories.Interfaces;
using ReportingService.Services.Interfaces;

namespace ReportingService.Services;

public class ReportGenerationService : IReportGenerationService
{
    private readonly IInventoryServiceRepository _inventoryServiceRepository;

    public ReportGenerationService(IInventoryServiceRepository rep)
    {
        _inventoryServiceRepository = rep;
    }

    public async Task<XLWorkbook> ConvertTableToExcel(string html)
    {
        DataTable dataTable = HtmlToDataTable(html);

        // Save DataTable to Excel
        var excelFile = new XLWorkbook();
        excelFile.Worksheets.Add(dataTable, "Sheet1");
        return excelFile;
    }
    
    private DataTable HtmlToDataTable(string html)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var table = new DataTable();
        var rows = doc.DocumentNode.SelectNodes("//table/tr|//table/thead/tr|//table/tbody/tr");

        // Process header row
        var headerCells = rows[0].SelectNodes("th|td");
        foreach (var headerCell in headerCells)
        {
            table.Columns.Add(headerCell.InnerText.Trim());
        }

        // Process data rows
        for (int i = 1; i < rows.Count; i++)
        {
            var cells = rows[i].SelectNodes("th|td");
            var row = table.NewRow();
            for (int j = 0; j < cells.Count; j++)
            {
                row[j] = cells[j].InnerText.Trim();
            }
            table.Rows.Add(row);
        }

        return table;
    }
}