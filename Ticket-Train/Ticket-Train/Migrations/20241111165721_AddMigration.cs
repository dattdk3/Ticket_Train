using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Train.Migrations
{
    public partial class AddMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    passenger_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.passenger_id);
                });

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    station_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stations", x => x.station_id);
                });

            migrationBuilder.CreateTable(
                name: "train",
                columns: table => new
                {
                    train_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_train", x => x.train_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    role = table.Column<int>(type: "int", nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    route_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origin_id = table.Column<int>(type: "int", nullable: true),
                    destination_id = table.Column<int>(type: "int", nullable: true),
                    distance = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routes", x => x.route_id);
                    table.ForeignKey(
                        name: "routes_destinationFK",
                        column: x => x.destination_id,
                        principalTable: "stations",
                        principalColumn: "station_id");
                    table.ForeignKey(
                        name: "routes_originFK",
                        column: x => x.origin_id,
                        principalTable: "stations",
                        principalColumn: "station_id");
                });

            migrationBuilder.CreateTable(
                name: "seats",
                columns: table => new
                {
                    seat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    train_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", maxLength: 20, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seats", x => x.seat_id);
                    table.ForeignKey(
                        name: "seat_trainFK",
                        column: x => x.train_id,
                        principalTable: "train",
                        principalColumn: "train_id");
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    schedule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    train_id = table.Column<int>(type: "int", nullable: false),
                    route_id = table.Column<int>(type: "int", nullable: false),
                    departure_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.schedule_id);
                    table.ForeignKey(
                        name: "schedules_routeFK",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "route_id");
                    table.ForeignKey(
                        name: "schedules_trainFK",
                        column: x => x.train_id,
                        principalTable: "train",
                        principalColumn: "train_id");
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    reservation_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    schedule_id = table.Column<int>(type: "int", nullable: true),
                    passenger_id = table.Column<int>(type: "int", nullable: true),
                    num_tickets = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.reservation_Id);
                    table.ForeignKey(
                        name: "reservation_passengerFK",
                        column: x => x.passenger_id,
                        principalTable: "passengers",
                        principalColumn: "passenger_id");
                    table.ForeignKey(
                        name: "reservation_scheduleFK",
                        column: x => x.schedule_id,
                        principalTable: "schedules",
                        principalColumn: "schedule_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_passenger_id",
                table: "reservations",
                column: "passenger_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_schedule_id",
                table: "reservations",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_routes_destination_id",
                table: "routes",
                column: "destination_id");

            migrationBuilder.CreateIndex(
                name: "IX_routes_origin_id",
                table: "routes",
                column: "origin_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_route_id",
                table: "schedules",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_train_id",
                table: "schedules",
                column: "train_id");

            migrationBuilder.CreateIndex(
                name: "IX_seats_train_id",
                table: "seats",
                column: "train_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "seats");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "train");

            migrationBuilder.DropTable(
                name: "stations");
        }
    }
}
