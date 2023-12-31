﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WaterConsumptionTracker.Data;

#nullable disable

namespace WaterTracker.API.Migrations
{
    [DbContext(typeof(WaterTrackerDbContext))]
    partial class WaterTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WaterConsumptionTracker.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "gladys.stevens@example.com",
                            Firstname = "Gladys",
                            Surname = "Stevens"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jean.garza@example.com",
                            Firstname = "Jean",
                            Surname = "Garza"
                        },
                        new
                        {
                            Id = 3,
                            Email = "suzanne.lambert@example.com",
                            Firstname = "Suzanne ",
                            Surname = "Lambert"
                        },
                        new
                        {
                            Id = 4,
                            Email = "james.cooper@example.com",
                            Firstname = "James ",
                            Surname = "Cooper"
                        },
                        new
                        {
                            Id = 5,
                            Email = "steven .rice@example.com",
                            Firstname = "Steven ",
                            Surname = "Rice"
                        });
                });

            modelBuilder.Entity("WaterConsumptionTracker.Entities.WaterIntake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsumedWater")
                        .HasColumnType("int");

                    b.Property<DateTime>("IntakeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WaterIntakes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConsumedWater = 6287,
                            IntakeDate = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ConsumedWater = 4856,
                            IntakeDate = new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            ConsumedWater = 6832,
                            IntakeDate = new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            ConsumedWater = 1387,
                            IntakeDate = new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            ConsumedWater = 8567,
                            IntakeDate = new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
