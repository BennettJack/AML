using InventoryService.Data.Models;
using InventoryService.Data.Models.CDDVD;
using InventoryService.Data.Models.Media;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<MediaModel> MediaModels { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<MultiMediaGame> MultiMediaGames { get; set; }
        public DbSet<Periodical> Periodicals { get; set; }
        public DbSet<CdDvd> CdDvds { get; set; }
        public DbSet<CdTrack> CdTracks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthorConnection>  BookAuthorConnections { get; set; }
        public DbSet<MediaModelGenreConnection> MediaModelGenreConnections { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<MediaModelFormatConnection> MediaModelFormatConnections { get; set; }
        public DbSet<StockEntry> StockEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(x =>{
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


            modelBuilder.Entity<Genre>(x => {
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
        }
    }
}
