using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.Migrations
{
    public partial class RemovingUniqueness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_userDatas_name",
                table: "userDatas");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "userDatas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "userDatas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userDatas_name",
                table: "userDatas",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");
        }
    }
}
