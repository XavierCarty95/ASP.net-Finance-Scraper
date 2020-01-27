﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Models.Data;

namespace Portfolio.Migrations
{
    [DbContext(typeof(StockContext))]
    partial class StockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Portfolio.Models.Stocks", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AverageVolume")
                        .HasColumnType("TEXT");

                    b.Property<string>("Change")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChangeRate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateScrapped")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarketCapData")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarketTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShareData")
                        .HasColumnType("TEXT");

                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.Property<string>("Volume")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Stock");
                });
#pragma warning restore 612, 618
        }
    }
}
