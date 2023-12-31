﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TruckAplication.Data;

#nullable disable

namespace TruckAplication.Migrations
{
    [DbContext(typeof(TruckAplicationContext))]
    [Migration("20230108154130_CorectareReqs")]
    partial class CorectareReqs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TruckAplication.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TruckAplication.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("TruckAplication.Models.Driver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("TruckAplication.Models.Request", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<decimal>("RentedDays")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TruckID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("TruckID");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("TruckAplication.Models.Truck", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("AvailableDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DriverID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("DriverID");

                    b.ToTable("Truck");
                });

            modelBuilder.Entity("TruckAplication.Models.TruckCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("TruckID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("TruckID");

                    b.ToTable("TruckCategory");
                });

            modelBuilder.Entity("TruckAplication.Models.Request", b =>
                {
                    b.HasOne("TruckAplication.Models.Client", "Client")
                        .WithMany("Requests")
                        .HasForeignKey("ClientID");

                    b.HasOne("TruckAplication.Models.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckID");

                    b.Navigation("Client");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("TruckAplication.Models.Truck", b =>
                {
                    b.HasOne("TruckAplication.Models.Driver", "Driver")
                        .WithMany("Trucks")
                        .HasForeignKey("DriverID");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("TruckAplication.Models.TruckCategory", b =>
                {
                    b.HasOne("TruckAplication.Models.Category", "Category")
                        .WithMany("TruckCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TruckAplication.Models.Truck", "Truck")
                        .WithMany("TruckCategories")
                        .HasForeignKey("TruckID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("TruckAplication.Models.Category", b =>
                {
                    b.Navigation("TruckCategories");
                });

            modelBuilder.Entity("TruckAplication.Models.Client", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("TruckAplication.Models.Driver", b =>
                {
                    b.Navigation("Trucks");
                });

            modelBuilder.Entity("TruckAplication.Models.Truck", b =>
                {
                    b.Navigation("TruckCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
