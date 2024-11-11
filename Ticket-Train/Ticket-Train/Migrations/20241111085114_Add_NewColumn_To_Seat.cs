using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Train.Migrations
{
    public partial class Add_NewColumn_To_Seat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewColumn",
                table: "seats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // Xóa cột 'schedule_id'
            migrationBuilder.DropColumn(
                name: "NewColumn",
                table: "seats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewColumn",
                table: "seats");
        }
    }
}
