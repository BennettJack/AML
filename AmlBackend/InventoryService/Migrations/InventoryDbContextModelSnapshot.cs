﻿// <auto-generated />
using System;
using InventoryService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryService.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("InventoryService.Data.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            AuthorName = "J.R.R Tolkien"
                        },
                        new
                        {
                            AuthorId = 2,
                            AuthorName = "Patric Rothfuss"
                        },
                        new
                        {
                            AuthorId = 3,
                            AuthorName = "Steven King"
                        });
                });

            modelBuilder.Entity("InventoryService.Data.Models.BookAuthorConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookMediaModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookMediaModelId");

                    b.ToTable("BookAuthorConnections");
                });

            modelBuilder.Entity("InventoryService.Data.Models.BorrowRecord", b =>
                {
                    b.Property<int>("BorrowRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BranchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaModelFormatConnectionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BorrowRecordId");

                    b.HasIndex("MediaModelFormatConnectionId");

                    b.ToTable("BorrowRecords");
                });

            modelBuilder.Entity("InventoryService.Data.Models.BranchStockRecord", b =>
                {
                    b.Property<int>("BranchStockRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BorrowedCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BranchId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MediaModelFormatConnectionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReservedCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StockCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("BranchStockRecordId");

                    b.HasIndex("MediaModelFormatConnectionId");

                    b.ToTable("BranchStockRecords");
                });

            modelBuilder.Entity("InventoryService.Data.Models.CDDVD.CdTrack", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CdDvdMediaModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TrackId");

                    b.HasIndex("CdDvdMediaModelId");

                    b.ToTable("CdTracks");
                });

            modelBuilder.Entity("InventoryService.Data.Models.Format", b =>
                {
                    b.Property<int>("FormatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FormatName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FormatId");

                    b.ToTable("Formats");

                    b.HasData(
                        new
                        {
                            FormatId = 1,
                            FormatName = "Paperback"
                        },
                        new
                        {
                            FormatId = 2,
                            FormatName = "Hardback"
                        },
                        new
                        {
                            FormatId = 3,
                            FormatName = "Digital"
                        },
                        new
                        {
                            FormatId = 4,
                            FormatName = "DVD"
                        },
                        new
                        {
                            FormatId = 5,
                            FormatName = "Bluray"
                        },
                        new
                        {
                            FormatId = 6,
                            FormatName = "Streaming"
                        },
                        new
                        {
                            FormatId = 7,
                            FormatName = "Journal"
                        },
                        new
                        {
                            FormatId = 8,
                            FormatName = "Newspaper"
                        },
                        new
                        {
                            FormatId = 9,
                            FormatName = "Magazine"
                        },
                        new
                        {
                            FormatId = 10,
                            FormatName = "CD"
                        },
                        new
                        {
                            FormatId = 11,
                            FormatName = "PS5Game"
                        },
                        new
                        {
                            FormatId = 12,
                            FormatName = "SwitchGame"
                        },
                        new
                        {
                            FormatId = 13,
                            FormatName = "XboxGame"
                        });
                });

            modelBuilder.Entity("InventoryService.Data.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GenreName = "Horror"
                        },
                        new
                        {
                            GenreId = 2,
                            GenreName = "Action"
                        },
                        new
                        {
                            GenreId = 3,
                            GenreName = "Comedy"
                        });
                });

            modelBuilder.Entity("InventoryService.Data.Models.Media.MediaModel", b =>
                {
                    b.Property<int>("MediaModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<long?>("SerialNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ThumbnailImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("MediaModelId");

                    b.ToTable("MediaModels");

                    b.HasDiscriminator().HasValue("MediaModel");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("InventoryService.Data.Models.MediaModelFormatConnection", b =>
                {
                    b.Property<int>("MediaModelFormatConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FormatId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MediaModelFormatConnectionId");

                    b.HasIndex("FormatId");

                    b.HasIndex("MediaModelId");

                    b.ToTable("MediaModelFormatConnections");
                });

            modelBuilder.Entity("InventoryService.Data.Models.MediaModelGenreConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MediaModelId");

                    b.ToTable("MediaModelGenreConnections");
                });

            modelBuilder.Entity("InventoryService.Data.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            PublisherName = "Penguin"
                        },
                        new
                        {
                            PublisherId = 2,
                            PublisherName = "Sony"
                        },
                        new
                        {
                            PublisherId = 3,
                            PublisherName = "Activision"
                        });
                });

            modelBuilder.Entity("InventoryService.Data.Models.ReserveRecord", b =>
                {
                    b.Property<int>("ReserveRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BranchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaModelFormatConnectionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ReserveRecordId");

                    b.HasIndex("MediaModelFormatConnectionId");

                    b.ToTable("ReserveRecords");
                });

            modelBuilder.Entity("InventoryService.Data.Models.StockEntry", b =>
                {
                    b.Property<int>("StockEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaModelFormatConnectionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StockCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("StockEntryId");

                    b.HasIndex("MediaModelFormatConnectionId");

                    b.ToTable("StockEntries");
                });

            modelBuilder.Entity("InventoryService.Data.Models.Book", b =>
                {
                    b.HasBaseType("InventoryService.Data.Models.Media.MediaModel");

                    b.Property<int?>("PageCount")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Book");

                    b.HasData(
                        new
                        {
                            MediaModelId = 1,
                            Description = "BOOK 1 DESCRIPTION",
                            FullImageUrl = "Book1PlaceholderImage.png",
                            PublishDate = new DateTime(1992, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = 4892109905L,
                            Title = "Book 1",
                            PageCount = 300
                        },
                        new
                        {
                            MediaModelId = 2,
                            Description = "BOOK 2 DESCRIPTION",
                            FullImageUrl = "Book2PlaceholderImage.png",
                            PublishDate = new DateTime(1992, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = 4892109906L,
                            Title = "Book 2",
                            PageCount = 410
                        },
                        new
                        {
                            MediaModelId = 3,
                            Description = "BOOK 3 DESCRIPTION",
                            FullImageUrl = "Book3PlaceholderImage.png",
                            PublishDate = new DateTime(1992, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = 4892109907L,
                            Title = "Book 3",
                            PageCount = 89
                        },
                        new
                        {
                            MediaModelId = 4,
                            Description = "BOOK 4 DESCRIPTION",
                            FullImageUrl = "Book4PlaceholderImage.png",
                            PublishDate = new DateTime(1992, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = 4892109908L,
                            Title = "Book 4",
                            PageCount = 280
                        },
                        new
                        {
                            MediaModelId = 5,
                            Description = "BOOK 5 DESCRIPTION",
                            FullImageUrl = "Book5PlaceholderImage.png",
                            PublishDate = new DateTime(1992, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = 4892109909L,
                            Title = "Book 5",
                            PageCount = 390
                        });
                });

            modelBuilder.Entity("InventoryService.Data.Models.CdDvd", b =>
                {
                    b.HasBaseType("InventoryService.Data.Models.Media.MediaModel");

                    b.Property<int>("CdDvdId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("CdDvd");
                });

            modelBuilder.Entity("InventoryService.Data.Models.Journal", b =>
                {
                    b.HasBaseType("InventoryService.Data.Models.Media.MediaModel");

                    b.Property<int>("JournalId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Journal");
                });

            modelBuilder.Entity("InventoryService.Data.Models.MultiMediaGame", b =>
                {
                    b.HasBaseType("InventoryService.Data.Models.Media.MediaModel");

                    b.HasDiscriminator().HasValue("MultiMediaGame");
                });

            modelBuilder.Entity("InventoryService.Data.Models.Periodical", b =>
                {
                    b.HasBaseType("InventoryService.Data.Models.Media.MediaModel");

                    b.Property<int?>("PageCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeriodicalId")
                        .HasColumnType("INTEGER");

                    b.ToTable("MediaModels", t =>
                        {
                            t.Property("PageCount")
                                .HasColumnName("Periodical_PageCount");
                        });

                    b.HasDiscriminator().HasValue("Periodical");
                });

            modelBuilder.Entity("InventoryService.Data.Models.BookAuthorConnection", b =>
                {
                    b.HasOne("InventoryService.Data.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryService.Data.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookMediaModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("InventoryService.Data.Models.BorrowRecord", b =>
                {
                    b.HasOne("InventoryService.Data.Models.MediaModelFormatConnection", "MediaModelFormatConnection")
                        .WithMany()
                        .HasForeignKey("MediaModelFormatConnectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaModelFormatConnection");
                });

            modelBuilder.Entity("InventoryService.Data.Models.BranchStockRecord", b =>
                {
                    b.HasOne("InventoryService.Data.Models.MediaModelFormatConnection", "MediaModelFormatConnection")
                        .WithMany()
                        .HasForeignKey("MediaModelFormatConnectionId");

                    b.Navigation("MediaModelFormatConnection");
                });

            modelBuilder.Entity("InventoryService.Data.Models.CDDVD.CdTrack", b =>
                {
                    b.HasOne("InventoryService.Data.Models.CdDvd", "CdDvd")
                        .WithMany()
                        .HasForeignKey("CdDvdMediaModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CdDvd");
                });

            modelBuilder.Entity("InventoryService.Data.Models.MediaModelFormatConnection", b =>
                {
                    b.HasOne("InventoryService.Data.Models.Format", "Format")
                        .WithMany()
                        .HasForeignKey("FormatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryService.Data.Models.Media.MediaModel", "MediaModel")
                        .WithMany()
                        .HasForeignKey("MediaModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Format");

                    b.Navigation("MediaModel");
                });

            modelBuilder.Entity("InventoryService.Data.Models.MediaModelGenreConnection", b =>
                {
                    b.HasOne("InventoryService.Data.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryService.Data.Models.Media.MediaModel", "Media")
                        .WithMany()
                        .HasForeignKey("MediaModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("InventoryService.Data.Models.ReserveRecord", b =>
                {
                    b.HasOne("InventoryService.Data.Models.MediaModelFormatConnection", "MediaModelFormatConnection")
                        .WithMany()
                        .HasForeignKey("MediaModelFormatConnectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaModelFormatConnection");
                });

            modelBuilder.Entity("InventoryService.Data.Models.StockEntry", b =>
                {
                    b.HasOne("InventoryService.Data.Models.MediaModelFormatConnection", "MediaModelFormatConnection")
                        .WithMany()
                        .HasForeignKey("MediaModelFormatConnectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaModelFormatConnection");
                });
#pragma warning restore 612, 618
        }
    }
}
