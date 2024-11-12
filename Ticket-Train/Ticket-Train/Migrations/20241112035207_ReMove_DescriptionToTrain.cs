using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Train.Migrations
{
    public partial class ReMove_DescriptionToTrain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "train");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "train",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
