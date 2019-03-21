using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectNet.Migrations
{
    public partial class listitemsmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_List_ListID",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "ListID",
                table: "Item",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_List_ListID",
                table: "Item",
                column: "ListID",
                principalTable: "List",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_List_ListID",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "ListID",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Item_List_ListID",
                table: "Item",
                column: "ListID",
                principalTable: "List",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
