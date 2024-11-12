using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Train.Migrations
{
    public partial class AlterStatusToSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seats_schedules_ScheduleId",
                table: "seats");

            migrationBuilder.DropIndex(
                name: "IX_seats_ScheduleId",
                table: "seats");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "seats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "seats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_seats_ScheduleId",
                table: "seats",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_seats_schedules_ScheduleId",
                table: "seats",
                column: "ScheduleId",
                principalTable: "schedules",
                principalColumn: "schedule_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
