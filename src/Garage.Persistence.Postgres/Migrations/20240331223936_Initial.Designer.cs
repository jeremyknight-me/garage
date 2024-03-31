﻿// <auto-generated />
using System;
using Garage.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Garage.Persistence.Postgres.Migrations
{
    [DbContext(typeof(GarageDbContext))]
    [Migration("20240331223936_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("app")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Garage.Core.Entities.Garage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Garage", "app");
                });

            modelBuilder.Entity("Garage.Core.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Location", "app");
                });

            modelBuilder.Entity("Garage.Core.Entities.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Cost")
                        .HasPrecision(9, 2)
                        .HasColumnType("numeric(9,2)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<int?>("Mileage")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Maintenance", "app");
                });

            modelBuilder.Entity("Garage.Core.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Vehicle", "app");
                });

            modelBuilder.Entity("GarageVehicle", b =>
                {
                    b.Property<int>("GaragesId")
                        .HasColumnType("integer");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("integer");

                    b.HasKey("GaragesId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("GarageVehicle", "app");
                });

            modelBuilder.Entity("Garage.Core.Entities.Maintenance", b =>
                {
                    b.HasOne("Garage.Core.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage.Core.Entities.Vehicle", "Vehicle")
                        .WithMany("Maintenances")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("GarageVehicle", b =>
                {
                    b.HasOne("Garage.Core.Entities.Garage", null)
                        .WithMany()
                        .HasForeignKey("GaragesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage.Core.Entities.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Garage.Core.Entities.Vehicle", b =>
                {
                    b.Navigation("Maintenances");
                });
#pragma warning restore 612, 618
        }
    }
}