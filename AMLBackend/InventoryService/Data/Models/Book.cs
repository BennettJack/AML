﻿using Microsoft.EntityFrameworkCore;

namespace InventoryService2.Data.Models
{
    public class Book
    {
        
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateOnly PublishDate { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int Availability {  get; set; }
        public int PageCount { get; set; }
        public string Type { get; set; }

        public Book() { }
    }
}
