﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PRODUCT_CRUD.Model;

#nullable disable

namespace PRODUCT_CRUD.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231125071201_Product table")]
    partial class Producttable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PRODUCT_CRUD.Contracts.DBModel.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            Description = "Samsung SmartPhone 2023",
                            Name = "Samsung SmartPhone",
                            Price = 400m
                        },
                        new
                        {
                            ProductID = 2,
                            Description = "Dell Laptop 2023",
                            Name = "Dell Laptop",
                            Price = 500m
                        },
                        new
                        {
                            ProductID = 3,
                            Description = "Iphone Smartwatch 2023",
                            Name = "Iphone Smartwatch",
                            Price = 5000m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
