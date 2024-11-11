using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Train.Migrations
{
    public partial class Remove_ScheduleId_From_Seat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Xóa chỉ mục phụ thuộc vào cột 'schedule_id'
            migrationBuilder.DropIndex(
                name: "IX_seats_schedule_id",
                table: "seats");

            // Xóa khóa ngoại phụ thuộc vào cột 'schedule_id'
            migrationBuilder.DropForeignKey(
                name: "seat_scheduleFK",
                table: "seats");

            // Xóa cột 'schedule_id'
            migrationBuilder.DropColumn(
                name: "schedule_id",
                table: "seats");

            // Thêm Cột
            //Add - Migration Add_NewColumn_To_Seat
            migrationBuilder.AddColumn<string>(
            name: "NewColumn",
            table: "seats",
            type: "nvarchar(max)",
            nullable: true);
            // Sau đó chạy lệnh Update-Database

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "scheduleid",
            table: "seats",
            type: "int",
            nullable: false,
            defaultValue: 0);
        }
    }
}
