﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductFeederCoreLib.Data;

#nullable disable

namespace ProductFeederCoreLib.Migrations
{
    [DbContext(typeof(FeederProductsDbContext))]
    [Migration("20220825233453_setNullProdutFields")]
    partial class setNullProdutFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProductFeederCoreLib.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreationDateTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<DateTime?>("DeletionDateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prefix")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreationDateTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<DateTime?>("DeletionDateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("conditionDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Conditions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreationDateTimeStamp = new DateTime(2022, 8, 25, 18, 34, 53, 423, DateTimeKind.Local).AddTicks(3142),
                            conditionDescription = "NEW"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreationDateTimeStamp = new DateTime(2022, 8, 25, 18, 34, 53, 423, DateTimeKind.Local).AddTicks(3189),
                            conditionDescription = "REFURBISH"
                        });
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Feed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreationDateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletionDateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("feedUid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("file")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("processId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreationDateTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<DateTime?>("DeletionDateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndPriceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ListPrice")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartPriceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<decimal?>("BaseCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("ConditionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDateTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<DateTime?>("DeletionDateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("EAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UPC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Warranty")
                        .HasColumnType("bit");

                    b.Property<string>("sku")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal?>("unitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ConditionId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreationDateTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<DateTime?>("DeletionDateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prefix")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("RFC")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("RazonSocial")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Brand", b =>
                {
                    b.HasOne("ProductFeederCoreLib.Models.Supplier", "Supplier")
                        .WithMany("brands")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Price", b =>
                {
                    b.HasOne("ProductFeederCoreLib.Models.Product", null)
                        .WithMany("Prices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Product", b =>
                {
                    b.HasOne("ProductFeederCoreLib.Models.Brand", "Brand")
                        .WithMany("products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductFeederCoreLib.Models.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId");

                    b.Navigation("Brand");

                    b.Navigation("Condition");
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Brand", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Product", b =>
                {
                    b.Navigation("Prices");
                });

            modelBuilder.Entity("ProductFeederCoreLib.Models.Supplier", b =>
                {
                    b.Navigation("brands");
                });
#pragma warning restore 612, 618
        }
    }
}
