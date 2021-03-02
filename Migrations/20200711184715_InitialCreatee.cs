using Microsoft.EntityFrameworkCore.Migrations;

namespace TaDandoOnda.Migrations
{
    public partial class InitialCreatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manobras_Surfistas_SurfistaId",
                table: "Manobras");

            migrationBuilder.AddForeignKey(
                name: "FK_Manobras_Surfistas_SurfistaId",
                table: "Manobras",
                column: "SurfistaId",
                principalTable: "Surfistas",
                principalColumn: "SurfistaId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manobras_Surfistas_SurfistaId",
                table: "Manobras");

            migrationBuilder.AddForeignKey(
                name: "FK_Manobras_Surfistas_SurfistaId",
                table: "Manobras",
                column: "SurfistaId",
                principalTable: "Surfistas",
                principalColumn: "SurfistaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
