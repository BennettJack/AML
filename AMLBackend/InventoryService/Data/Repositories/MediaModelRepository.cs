﻿using InventoryService.Data.Branch;
using InventoryService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Repositories;

public class MediaModelRepository(InventoryDbContext _context)
{
    public async Task AddMediaModelGenreConnection(List<int> genres, long serialNumber)
    {
        foreach (var genreId in genres)
        {
            var mediaModelGenreConnection = new MediaModelGenreConnection
            {
                Media = await _context.MediaModels.FirstOrDefaultAsync(b => b.SerialNumber == serialNumber),
                Genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreId == genreId)
            };
                
            await _context.AddAsync(mediaModelGenreConnection);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddMediaModelFormatConnection(List<int> formats, long serialNumber)
    {
        foreach (var formatId in formats)
        {
            var mediaModelFormatConnection = new MediaModelFormatConnection
            {
                Media = await _context.MediaModels.FirstOrDefaultAsync(b => b.SerialNumber == serialNumber),
                Format = await _context.Formats.FirstOrDefaultAsync(f => f.FormatId == formatId)
            };
            
            await _context.AddAsync(mediaModelFormatConnection);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SetInitialStock(long serialNumber)
    {
        var formatEntries =
            _context.MediaModelFormatConnections.Where(f => f.Media.SerialNumber == serialNumber).ToList();

        var client = new HttpClient();
        var response = await client.GetAsync("https://localhost:7278/api/Branch/UpdateBook");
        var branches = await response.Content.ReadFromJsonAsync<List<BranchDto>>();
        foreach (var branch in branches)
        {
            foreach (var formatEntry in formatEntries)
            {
                var stockEntry = new StockEntry()
                {
                    MediaModelFormatConnection = formatEntry,
                    StockCount = 0,
                    BranchId = branch.BranchId
                };

                await _context.AddAsync(stockEntry);
            }
        }
        await _context.SaveChangesAsync();
    }
}