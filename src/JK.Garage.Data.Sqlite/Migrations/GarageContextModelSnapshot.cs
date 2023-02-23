﻿// <auto-generated />
using System;
using JK.Garage.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JK.Garage.Data.Sqlite.Migrations
{
    [DbContext(typeof(GarageContext))]
    partial class GarageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("JK.Garage.Common.Garage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Garages", (string)null);
                });

            modelBuilder.Entity("JK.Garage.Common.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("JK.Garage.Common.Maintenance", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<decimal?>("Cost")
                        .HasPrecision(10, 2)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("TEXT")
                        .HasColumnName("LocationId");

                    b.Property<int>("Mileage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .IsUnicode(true)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Maintenances", (string)null);
                });

            modelBuilder.Entity("JK.Garage.Common.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<Guid?>("GarageId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GarageId");

                    b.ToTable("Vehicles", (string)null);
                });

            modelBuilder.Entity("JK.Garage.Common.Maintenance", b =>
                {
                    b.HasOne("JK.Garage.Common.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JK.Garage.Common.Vehicle", null)
                        .WithMany("Maintenances")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("JK.Garage.Common.Vehicle", b =>
                {
                    b.HasOne("JK.Garage.Common.Garage", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("GarageId");
                });

            modelBuilder.Entity("JK.Garage.Common.Garage", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("JK.Garage.Common.Vehicle", b =>
                {
                    b.Navigation("Maintenances");
                });
#pragma warning restore 612, 618
        }
    }
}
