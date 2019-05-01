using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectNet.Migrations
{
    public partial class username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "List",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Item",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "List");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Item");
        }
    }
}
