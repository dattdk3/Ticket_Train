using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ticket_Train.Models
{
    public partial class TicketsContext : DbContext
    {
        public TicketsContext()
        {
        }

        public TicketsContext(DbContextOptions<TicketsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Routes> Routes { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;
        public virtual DbSet<Train> Trains { get; set; } = null!;

        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<Seat> Seats { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B2EDHFC\\SQLEXPRESS; Database=TicketTrain;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("passengers");

                entity.Property(e => e.PassengerId)
                    .HasColumnName("passenger_id")
                    .UseIdentityColumn();

                entity.Property(e => e.BirthDate).HasColumnName("birthDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservations");

                entity.HasKey(e => e.ReservationId);

                entity.Property(e => e.ReservationId)
                   .HasColumnName("reservation_Id").UseIdentityColumn();

                entity.Property(e => e.NumTickets).HasColumnName("num_tickets");

                entity.Property(e => e.PassengerId).HasColumnName("passenger_id");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.PassengerId)
                    .HasConstraintName("reservation_passengerFK");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("reservation_scheduleFK");
            });

            modelBuilder.Entity<Routes>(entity =>
            {
                entity.ToTable("routes");
                entity.HasKey(o => o.RouteId);
                entity.Property(e => e.RouteId)
                    .HasColumnName("route_id")
                    .UseIdentityColumn();
                entity.Property(e => e.DestinationId).HasColumnName("destination_id");
                entity.Property(e => e.Distance).HasColumnName("distance");
                entity.Property(e => e.OriginId).HasColumnName("origin_id");

                // Thiết lập khóa ngoại từ `origin_id` đến `station_id`
                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.RouteOrigins)
                    .HasForeignKey(d => d.OriginId)
                    .HasConstraintName("routes_originFK");

                // Thiết lập khóa ngoại từ `destination_id` đến `station_id`
                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.RouteDestinations)
                    .HasForeignKey(d => d.DestinationId)
                    .HasConstraintName("routes_destinationFK");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedules");

                entity.HasKey(o => o.ScheduleId);

                entity.Property(e => e.ScheduleId)
                    .HasColumnName("schedule_id").UseIdentityColumn(); ;


                entity.Property(e => e.DepartureTime).HasColumnName("departure_time");


                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.TrainId).HasColumnName("train_id");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedules_routeFK");

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.TrainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedules_trainFK");

            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("stations");

                entity.HasKey(o => o.StationId);

                entity.Property(e => e.StationId)
                    .HasColumnName("station_id")
                    .UseIdentityColumn(); ;

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.ToTable("train");

                entity.HasKey(o => o.TrainId);

                entity.Property(e => e.TrainId)
                .HasColumnName("train_id")
                .UseIdentityColumn();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("seats");

                entity.HasKey(o => o.SeatId);

                entity.Property(e => e.SeatId)
                    .HasColumnName("seat_id")
                    .UseIdentityColumn();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");

                entity.Property(e => e.TrainId).HasColumnName("train_id");


                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")  // Định dạng kiểu dữ liệu decimal cho giá vé
                    .HasColumnName("price");

                // Thiết lập quan hệ
                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.TrainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seat_trainFK");


            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasDefaultValue(2) // Default role is user
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}