﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Domain.Entities.BasicBookingScheduleRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EndTimeId")
                        .HasColumnType("int");

                    b.Property<bool>("FridaySelected")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("MondaySelected")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("SaturdaySelected")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("StartTimeId")
                        .HasColumnType("int");

                    b.Property<bool>("SundaySelected")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ThursdaySelected")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TuesdaySelected")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("WednesdaySelected")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("BasicBookingScheduleRules");
                });

            modelBuilder.Entity("Domain.Entities.BookingItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BookingItems");
                });

            modelBuilder.Entity("Domain.Entities.BookingOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EarlyBooking")
                        .HasColumnType("int");

                    b.Property<int>("LateBooking")
                        .HasColumnType("int");

                    b.Property<int>("MaxPartySize")
                        .HasColumnType("int");

                    b.Property<int>("MinPartySize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BookingOptions");
                });

            modelBuilder.Entity("Domain.Entities.SchedulingExceptionBookingRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("SchedulingExceptionBookingRule");
                });
#pragma warning restore 612, 618
        }
    }
}
