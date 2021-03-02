using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaDandoOnda.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surfistas",
                columns: table => new
                {
                    SurfistaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false),
                    Idade = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surfistas", x => x.SurfistaId);
                });

            migrationBuilder.CreateTable(
                name: "Manobras",
                columns: table => new
                {
                    ManobraId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Aérea = table.Column<bool>(nullable: false),
                    TipoDeOnda = table.Column<int>(nullable: false),
                    SurfistaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manobras", x => x.ManobraId);
                    table.ForeignKey(
                        name: "FK_Manobras_Surfistas_SurfistaId",
                        column: x => x.SurfistaId,
                        principalTable: "Surfistas",
                        principalColumn: "SurfistaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manobras_SurfistaId",
                table: "Manobras",
                column: "SurfistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manobras");

            migrationBuilder.DropTable(
                name: "Surfistas");
        }
    }
}
