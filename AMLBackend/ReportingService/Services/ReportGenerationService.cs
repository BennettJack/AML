using System.Data;
using ClosedXML.Excel;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http.HttpResults;

using ReportingService.Services.Interfaces;

namespace ReportingService.Services;

public class ReportGenerationService : IReportGenerationService
{
    public async Task<XLWorkbook> ConvertTableToExcel(string html)
    {
        try
        {
            DataTable dataTable = ConvertHtmlToDataTable(html);


            var excelFile = new XLWorkbook();
            excelFile.Worksheets.Add(dataTable, "report");
            return excelFile;
        }
        catch (NullReferenceException)
        {
            throw new NullReferenceException("Provided HTML table is not in a valid format");
        }
    }
    
    private DataTable ConvertHtmlToDataTable(string html)
    {
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        var dataTable = new DataTable();
        var tableRows = htmlDocument.DocumentNode.SelectNodes("//table/tr|//table/thead/tr|//table/tbody/tr");
        
        var tableHeaders = tableRows[0].SelectNodes("th|td");
        foreach (var header in tableHeaders)
        {
            dataTable.Columns.Add(header.InnerText.Trim());
        }
        
        for (int i = 1; i < tableRows.Count; i++)
        {
            var cells = tableRows[i].SelectNodes("th|td");
            var row = dataTable.NewRow();
            for (int j = 0; j < cells.Count; j++)
            {
                row[j] = cells[j].InnerText.Trim();
            }
            dataTable.Rows.Add(row);
        }

        return dataTable;
    }
}