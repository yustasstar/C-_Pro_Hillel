﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiEntityFrameworkCoreDemo.Data;

#nullable disable

namespace WebApiEntityFrameworkCoreDemo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiEntityFrameworkCoreDemo.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1905e08-a903-45e2-973c-1ea1aa7d1eb1"),
                            BirthDate = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Vasya P"
                        },
                        new
                        {
                            Id = new Guid("cb7ac236-ebc6-4e4b-88f8-863e453aad76"),
                            BirthDate = new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Petya R"
                        });
                });

            modelBuilder.Entity("WebApiEntityFrameworkCoreDemo.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b9f223f4-db20-40e7-bacd-6ca24c6606cd"),
                            AuthorId = new Guid("f1905e08-a903-45e2-973c-1ea1aa7d1eb1"),
                            Description = "Description1",
                            Price = 123.11m,
                            Title = "Title1"
                        },
                        new
                        {
                            Id = new Guid("80ce8f39-4696-4e5a-aa11-7a395d9a45f7"),
                            AuthorId = new Guid("f1905e08-a903-45e2-973c-1ea1aa7d1eb1"),
                            Description = "Description2",
                            Price = 113.11m,
                            Title = "Title2"
                        },
                        new
                        {
                            Id = new Guid("870bc805-51e3-41c4-88a8-897bb3108c3b"),
                            AuthorId = new Guid("cb7ac236-ebc6-4e4b-88f8-863e453aad76"),
                            Description = "Description3",
                            Price = 1523.11m,
                            Title = "Title3"
                        });
                });

            modelBuilder.Entity("WebApiEntityFrameworkCoreDemo.Models.Book", b =>
                {
                    b.HasOne("WebApiEntityFrameworkCoreDemo.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("WebApiEntityFrameworkCoreDemo.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
