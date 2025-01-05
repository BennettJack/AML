using System.Net;
using ReportingService.Repositories;
using ReportingService.Repositories.Interfaces;
using ReportingService.Services;
using ReportingService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<IInventoryServiceRepository, InventoryServiceRepository>();
builder.Services.AddScoped<IReportGenerationService, ReportGenerationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();