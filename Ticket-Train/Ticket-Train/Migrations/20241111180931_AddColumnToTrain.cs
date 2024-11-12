using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Train.Migrations
{
    public partial class AddColumnToTrain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ////Thêm cột description
            /////Add-Migration AddDateOfBirthToUsers
            //migrationBuilder.AddColumn<string>(
            //    name: "description",
            //    table: "train",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //Xoá Cột
            migrationBuilder.DropColumn(
                name: "description",
                table: "train");
            // chỉ cần tạo trường mới ở model rồi Add-Migration mới là sẽ có, sau đó Update-Database 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "train");
        }
    }
}
