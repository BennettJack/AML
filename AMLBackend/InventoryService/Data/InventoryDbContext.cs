using InventoryService.Data.Models;
using InventoryService.Data.Models.CDDVD;
using InventoryService.Data.Models.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryService.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
            
        }

        public InventoryDbContext()
        {
            
        }
        public virtual DbSet<MediaModel> MediaModels { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }
        public virtual DbSet<MultiMediaGame> MultiMediaGames { get; set; }
        public virtual DbSet<Periodical> Periodicals { get; set; }
        public virtual DbSet<CdDvd> CdDvds { get; set; }
        public virtual DbSet<CdTrack> CdTracks { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookAuthorConnection>  BookAuthorConnections { get; set; }
        public virtual DbSet<MediaModelGenreConnection> MediaModelGenreConnections { get; set; }
        public virtual DbSet<Format> Formats { get; set; }
        public virtual DbSet<BranchStockRecord> BranchStockRecords { get; set; }
        public virtual DbSet<BorrowRecord> BorrowRecords { get; set; }
        public virtual DbSet<ReserveRecord> ReserveRecords { get; set; }
        public virtual DbSet<MediaModelFormatConnection> MediaModelFormatConnections { get; set; }
        public virtual DbSet<StockEntry> StockEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(x =>
            {
                x.HasData(
                    new Author { AuthorId = 1, AuthorName = "J.R.R Tolkien" },
                    new Author { AuthorId = 2, AuthorName = "Patric Rothfuss" },
                    new Author { AuthorId = 3, AuthorName = "Steven King" }
                );
            });

            modelBuilder.Entity<Format>(x =>
            {
                x.HasData(
                    new Format { FormatId = 1, FormatName = "Paperback" },
                    new Format { FormatId = 2, FormatName = "Hardback" },
                    new Format { FormatId = 3, FormatName = "Digital" },
                    new Format { FormatId = 4, FormatName = "DVD" },
                    new Format { FormatId = 5, FormatName = "Bluray" },
                    new Format { FormatId = 6, FormatName = "Streaming" },
                    new Format { FormatId = 7, FormatName = "Journal" },
                    new Format { FormatId = 8, FormatName = "Newspaper" },
                    new Format { FormatId = 9, FormatName = "Magazine" },
                    new Format { FormatId = 10, FormatName = "CD" },
                    new Format { FormatId = 11, FormatName = "PS5Game" },
                    new Format { FormatId = 12, FormatName = "SwitchGame" },
                    new Format { FormatId = 13, FormatName = "XboxGame" }
                );
            });


            modelBuilder.Entity<Genre>(x =>
            {
                x.HasData(
                    new Genre { GenreId = 1, GenreName = "Horror" },
                    new Genre { GenreId = 2, GenreName = "Action" },
                    new Genre { GenreId = 3, GenreName = "Comedy" }
                );
            });

            modelBuilder.Entity<Publisher>(x =>
            {
                x.HasData(
                    new Publisher { PublisherId = 1, PublisherName = "Penguin" },
                    new Publisher { PublisherId = 2, PublisherName = "Sony" },
                    new Publisher { PublisherId = 3, PublisherName = "Activision" }
                );
            });

            modelBuilder.Entity<Book>(x =>
            {
                x.HasData(
                    new Book
                    {
                        MediaModelId = 1,
                        Description = "BOOK 1 DESCRIPTION",
                        PageCount = 300,
                        PublishDate = new(1992, 12, 4),
                        FullImageUrl = "Book1PlaceholderImage.png",
                        SerialNumber = 4892109905,
                        Title = "Book 1"
                    },
                    new Book
                    {
                        MediaModelId = 2,
                        Description = "BOOK 2 DESCRIPTION",
                        PageCount = 410,
                        PublishDate = new(1992, 12, 4),
                        FullImageUrl = "Book2PlaceholderImage.png",
                        SerialNumber = 4892109906,
                        Title = "Book 2"
                    },
                    new Book
                    {
                        MediaModelId = 3,
                        Description = "BOOK 3 DESCRIPTION",
                        PageCount = 89,
                        PublishDate = new(1992, 12, 4),
                        FullImageUrl = "Book3PlaceholderImage.png",
                        SerialNumber = 4892109907,
                        Title = "Book 3"
                    },
                    new Book
                    {
                        MediaModelId = 4,
                        Description = "BOOK 4 DESCRIPTION",
                        PageCount = 280,
                        PublishDate = new(1992, 12, 4),
                        FullImageUrl = "Book4PlaceholderImage.png",
                        SerialNumber = 4892109908,
                        Title = "Book 4"
                    },
                    new Book
                    {
                        MediaModelId = 5,
                        Description = "BOOK 5 DESCRIPTION",
                        PageCount = 390,
                        PublishDate = new(1992, 12, 4),
                        FullImageUrl = "Book5PlaceholderImage.png",
                        SerialNumber = 4892109909,
                        Title = "Book 5"
                    }
                );
            });
        }
    }
}
