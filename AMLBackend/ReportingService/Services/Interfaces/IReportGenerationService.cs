using ClosedXML.Excel;

namespace ReportingService.Services.Interfaces;

public interface IReportGenerationService
{
    public Task<XLWorkbook> ConvertTableToExcel(string html);
}