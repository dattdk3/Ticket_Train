﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ticket_Train.Models;

#nullable disable

namespace Ticket_Train.Migrations
{
    [DbContext(typeof(TicketsContext))]
    [Migration("20241112150014_AddDescriptionToTrain")]
    partial class AddDescriptionToTrain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ticket_Train.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("passenger_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("surname");

                    b.HasKey("PassengerId");

                    b.ToTable("passengers", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reservation_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<int?>("NumTickets")
                        .HasColumnType("int")
                        .HasColumnName("num_tickets");

                    b.Property<int?>("PassengerId")
                        .HasColumnType("int")
                        .HasColumnName("passenger_id");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int")
                        .HasColumnName("schedule_id");

                    b.HasKey("ReservationId");

                    b.HasIndex("PassengerId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("reservations", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Routes", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("route_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"), 1L, 1);

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int")
                        .HasColumnName("destination_id");

                    b.Property<int>("Distance")
                        .HasColumnType("int")
                        .HasColumnName("distance");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OriginId")
                        .HasColumnType("int")
                        .HasColumnName("origin_id");

                    b.HasKey("RouteId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OriginId");

                    b.ToTable("routes", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("schedule_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"), 1L, 1);

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("departure_time");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("route_id");

                    b.Property<int>("TrainId")
                        .HasColumnType("int")
                        .HasColumnName("train_id");

                    b.HasKey("ScheduleId");

                    b.HasIndex("RouteId");

                    b.HasIndex("TrainId");

                    b.ToTable("schedules", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("seat_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"), 1L, 1);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<bool>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<int>("TrainId")
                        .HasColumnType("int")
                        .HasColumnName("train_id");

                    b.HasKey("SeatId");

                    b.HasIndex("TrainId");

                    b.ToTable("seats", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("station_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StationId"), 1L, 1);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("StationId");

                    b.ToTable("stations", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Train", b =>
                {
                    b.Property<int>("TrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("train_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("TrainId");

                    b.ToTable("train", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2)
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Reservation", b =>
                {
                    b.HasOne("Ticket_Train.Models.Passenger", "Passenger")
                        .WithMany("Reservations")
                        .HasForeignKey("PassengerId")
                        .HasConstraintName("reservation_passengerFK");

                    b.HasOne("Ticket_Train.Models.Schedule", "Schedule")
                        .WithMany("Reservations")
                        .HasForeignKey("ScheduleId")
                        .HasConstraintName("reservation_scheduleFK");

                    b.Navigation("Passenger");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Ticket_Train.Models.Routes", b =>
                {
                    b.HasOne("Ticket_Train.Models.Station", "Destination")
                        .WithMany("RouteDestinations")
                        .HasForeignKey("DestinationId")
                        .HasConstraintName("routes_destinationFK");

                    b.HasOne("Ticket_Train.Models.Station", "Origin")
                        .WithMany("RouteOrigins")
                        .HasForeignKey("OriginId")
                        .HasConstraintName("routes_originFK");

                    b.Navigation("Destination");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("Ticket_Train.Models.Schedule", b =>
                {
                    b.HasOne("Ticket_Train.Models.Routes", "Route")
                        .WithMany("Schedules")
                        .HasForeignKey("RouteId")
                        .IsRequired()
                        .HasConstraintName("schedules_routeFK");

                    b.HasOne("Ticket_Train.Models.Train", "Train")
                        .WithMany("Schedules")
                        .HasForeignKey("TrainId")
                        .IsRequired()
                        .HasConstraintName("schedules_trainFK");

                    b.Navigation("Route");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("Ticket_Train.Models.Seat", b =>
                {
                    b.HasOne("Ticket_Train.Models.Train", "Train")
                        .WithMany("Seats")
                        .HasForeignKey("TrainId")
                        .IsRequired()
                        .HasConstraintName("seat_trainFK");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("Ticket_Train.Models.Passenger", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Ticket_Train.Models.Routes", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Ticket_Train.Models.Schedule", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Ticket_Train.Models.Station", b =>
                {
                    b.Navigation("RouteDestinations");

                    b.Navigation("RouteOrigins");
                });

            modelBuilder.Entity("Ticket_Train.Models.Train", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
