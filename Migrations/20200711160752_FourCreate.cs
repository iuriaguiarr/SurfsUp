using Microsoft.EntityFrameworkCore.Migrations;

namespace TaDandoOnda.Migrations
{
    public partial class FourCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Aérea",
                table: "Manobras",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Aérea",
                table: "Manobras",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
