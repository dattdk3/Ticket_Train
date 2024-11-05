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
    [Migration("20241103163907_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScheduleClass", b =>
                {
                    b.Property<int>("ScheduleId")
                        .HasColumnType("int")
                        .HasColumnName("schedule_id");

                    b.Property<int>("ClassId")
                        .HasColumnType("int")
                        .HasColumnName("class_id");

                    b.HasKey("ScheduleId", "ClassId")
                        .HasName("schedule_class_PK");

                    b.HasIndex("ClassId");

                    b.ToTable("schedule_class", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("class_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("name");

                    b.HasKey("ClassId");

                    b.ToTable("class", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("passenger_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
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
                        .HasColumnType("int")
                        .HasColumnName("reservation_id");

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

            modelBuilder.Entity("Ticket_Train.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("route_id");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int")
                        .HasColumnName("destination_id");

                    b.Property<int>("Distance")
                        .HasColumnType("int")
                        .HasColumnName("distance");

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
                        .HasColumnType("int")
                        .HasColumnName("schedule_id");

                    b.Property<int>("ClassId")
                        .HasColumnType("int")
                        .HasColumnName("class_id");

                    b.Property<DateOnly>("DepartureTime")
                        .HasColumnType("date")
                        .HasColumnName("departure_time");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("route_id");

                    b.Property<int>("TrainId")
                        .HasColumnType("int")
                        .HasColumnName("train_id");

                    b.HasKey("ScheduleId");

                    b.HasIndex("ClassId");

                    b.HasIndex("RouteId");

                    b.HasIndex("TrainId");

                    b.ToTable("schedules", (string)null);
                });

            modelBuilder.Entity("Ticket_Train.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .HasColumnType("int")
                        .HasColumnName("station_id");

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
                        .HasColumnType("int")
                        .HasColumnName("train_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("TrainId");

                    b.ToTable("train", (string)null);
                });

            modelBuilder.Entity("ScheduleClass", b =>
                {
                    b.HasOne("Ticket_Train.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .IsRequired()
                        .HasConstraintName("class_FK");

                    b.HasOne("Ticket_Train.Models.Schedule", null)
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .IsRequired()
                        .HasConstraintName("schedule_FK");
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

            modelBuilder.Entity("Ticket_Train.Models.Route", b =>
                {
                    b.HasOne("Ticket_Train.Models.Station", "Destination")
                        .WithMany("RouteDestinations")
                        .HasForeignKey("DestinationId")
                        .HasConstraintName("routes_destionationFK");

                    b.HasOne("Ticket_Train.Models.Station", "Origin")
                        .WithMany("RouteOrigins")
                        .HasForeignKey("OriginId")
                        .HasConstraintName("routes_originFK");

                    b.Navigation("Destination");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("Ticket_Train.Models.Schedule", b =>
                {
                    b.HasOne("Ticket_Train.Models.Class", "Class")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassId")
                        .IsRequired()
                        .HasConstraintName("schedule_classFK");

                    b.HasOne("Ticket_Train.Models.Route", "Route")
                        .WithMany("Schedules")
                        .HasForeignKey("RouteId")
                        .IsRequired()
                        .HasConstraintName("schedules_routeFK");

                    b.HasOne("Ticket_Train.Models.Train", "Train")
                        .WithMany("Schedules")
                        .HasForeignKey("TrainId")
                        .IsRequired()
                        .HasConstraintName("schedules_trainFK");

                    b.Navigation("Class");

                    b.Navigation("Route");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("Ticket_Train.Models.Class", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Ticket_Train.Models.Passenger", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Ticket_Train.Models.Route", b =>
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
                });
#pragma warning restore 612, 618
        }
    }
}
