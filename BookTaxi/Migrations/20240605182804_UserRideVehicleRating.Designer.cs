﻿// <auto-generated />
using System;
using BookTaxi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookTaxi.Migrations
{
    [DbContext(typeof(EF_DataContext))]
    [Migration("20240605182804_UserRideVehicleRating")]
    partial class UserRideVehicleRating
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookTaxi.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VehicleRTONumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vehicletype")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("BookTaxi.Models.Rating", b =>
                {
                    b.Property<Guid>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("DriverRating")
                        .HasColumnType("double precision");

                    b.Property<Guid>("RideId")
                        .HasColumnType("uuid");

                    b.Property<double>("RiderRating")
                        .HasColumnType("double precision");

                    b.HasKey("RatingId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("BookTaxi.Models.Ride", b =>
                {
                    b.Property<Guid>("RideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DropLocation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OTP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PickUpLocation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RideStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VehcileId")
                        .HasColumnType("uuid");

                    b.HasKey("RideId");

                    b.ToTable("Rides");
                });

            modelBuilder.Entity("BookTaxi.Models.Rider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Riders");
                });

            modelBuilder.Entity("BookTaxi.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserRole")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookTaxi.Models.Vehicle", b =>
                {
                    b.Property<Guid>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("VehicleAvailability")
                        .HasColumnType("integer");

                    b.Property<string>("VehicleRTONumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VehicleType")
                        .HasColumnType("integer");

                    b.HasKey("VehicleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("BookTaxi.Models.Vehicle", b =>
                {
                    b.HasOne("BookTaxi.Models.User", null)
                        .WithOne("Vehicle")
                        .HasForeignKey("BookTaxi.Models.Vehicle", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookTaxi.Models.User", b =>
                {
                    b.Navigation("Vehicle")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
