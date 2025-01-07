using Microsoft.AspNetCore.Mvc;
using Moq;
using ReportingService.Controllers;
using ReportingService.Data.Models.DTOs;
using ReportingService.Services;
using ReportingService.Services.Interfaces;

namespace ReportingServiceTest;

public class ReportingServiceTest
{
    private readonly ReportGenerationService _service;
    public ReportingServiceTest()
    {
        _service = new ReportGenerationService();
    }
    [Fact]
    public async void TestBadHtmlPresented()
    {
        //Arrange
        var badHtmlTable = @"
        <thead>
            <tr>
                <th>#</th>
                <th>Name</th>
                <th>Age</th>
                <th>Country</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>1</td>
                <td>John Doe</td>
                <td>25</td>
                <td>USA</td>
            </tr>
            <tr>
                <td>2</td>
                <td>Jane Smith</td>
                <td>30</td>
                <td>Canada</td>
            </tr>
            <tr>
                <td>3</td>
                <td>Samuel Green</td>
                <td>22</td>
                <td>UK</td>
        </tbody>";
        
        //Act
        var res = await Assert.ThrowsAsync<NullReferenceException>(() =>  _service.ConvertTableToExcel(badHtmlTable));
        //Assert
       
        var exception = res.Message;
        Assert.Equal("Provided HTML table is not in a valid format", exception);
    }
}