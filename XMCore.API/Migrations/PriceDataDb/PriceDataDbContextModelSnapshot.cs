﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XMCore.API.Data;

#nullable disable

namespace XMCore.API.Migrations.PriceDataDb
{
    [DbContext(typeof(PriceDataDbContext))]
    partial class PriceDataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("XMCore.API.Models.PriceData", b =>
                {
                    b.Property<int>("PriceDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceDataId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceSourceId")
                        .HasColumnType("int");

                    b.Property<string>("PriceSourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ask")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("high")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("low")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("open")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("open_24")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("percent_change_24")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("timestamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("volume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vwap")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriceDataId");

                    b.HasIndex("PriceSourceId");

                    b.ToTable("PriceData");
                });

            modelBuilder.Entity("XMCore.API.Models.PriceSource", b =>
                {
                    b.Property<int>("PriceSourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceSourceId"), 1L, 1);

                    b.Property<string>("PriceSourceCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceSourceDocsEndpoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceSourceEndpoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceSourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriceSourceId");

                    b.ToTable("PriceSource");
                });

            modelBuilder.Entity("XMCore.API.Models.PriceData", b =>
                {
                    b.HasOne("XMCore.API.Models.PriceSource", "PriceSource")
                        .WithMany()
                        .HasForeignKey("PriceSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceSource");
                });
#pragma warning restore 612, 618
        }
    }
}
