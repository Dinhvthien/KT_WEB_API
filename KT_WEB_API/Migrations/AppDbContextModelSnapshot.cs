﻿// <auto-generated />
using System;
using KT_WEB_API.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KT_WEB_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KT_WEB_API.Entities.ProductDetailPropertyDetails", b =>
                {
                    b.Property<int>("ProductDetailPropertyDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDetailPropertyDetailId"), 1L, 1);

                    b.Property<int>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyDetailId")
                        .HasColumnType("int");

                    b.HasKey("ProductDetailPropertyDetailId");

                    b.HasIndex("ProductDetailId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyDetailId");

                    b.ToTable("ProductDetailPropertyDetails");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.ProductDetails", b =>
                {
                    b.Property<int>("ProductDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDetailId"), 1L, 1);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float(53)");

                    b.Property<string>("ProductDetailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("ShellPrice")
                        .HasColumnType("float(53)");

                    b.HasKey("ProductDetailId");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.Properties", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertySort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PropertyId");

                    b.HasIndex("ProductId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.PropertyDetails", b =>
                {
                    b.Property<int>("PropertyDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyDetailId"), 1L, 1);

                    b.Property<int?>("PropertiesPropertyId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyDetailCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyDetailDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("PropertyDetailId");

                    b.HasIndex("PropertiesPropertyId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.ProductDetailPropertyDetails", b =>
                {
                    b.HasOne("KT_WEB_API.Entities.ProductDetails", "ProductDetail")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("ProductDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KT_WEB_API.Entities.Products", "Product")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KT_WEB_API.Entities.PropertyDetails", "PropertyDetail")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("PropertyDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductDetail");

                    b.Navigation("PropertyDetail");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.ProductDetails", b =>
                {
                    b.HasOne("KT_WEB_API.Entities.ProductDetails", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.Properties", b =>
                {
                    b.HasOne("KT_WEB_API.Entities.Products", "Product")
                        .WithMany("Properties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.PropertyDetails", b =>
                {
                    b.HasOne("KT_WEB_API.Entities.Properties", "Properties")
                        .WithMany("PropertyDetails")
                        .HasForeignKey("PropertiesPropertyId");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.ProductDetails", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.Products", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.Properties", b =>
                {
                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("KT_WEB_API.Entities.PropertyDetails", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
