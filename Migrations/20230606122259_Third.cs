using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NWS_Api1.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statut",
                table: "NwsEffectif");

            migrationBuilder.AddColumn<int>(
                name: "StatutId",
                table: "NwsEffectif",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatutEffectif",
                columns: table => new
                {
                    StatutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameStatut = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Since = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutEffectif", x => x.StatutId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NwsEffectif_StatutId",
                table: "NwsEffectif",
                column: "StatutId");

            migrationBuilder.AddForeignKey(
                name: "FK_NwsEffectif_StatutEffectif_StatutId",
                table: "NwsEffectif",
                column: "StatutId",
                principalTable: "StatutEffectif",
                principalColumn: "StatutId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NwsEffectif_StatutEffectif_StatutId",
                table: "NwsEffectif");

            migrationBuilder.DropTable(
                name: "StatutEffectif");

            migrationBuilder.DropIndex(
                name: "IX_NwsEffectif_StatutId",
                table: "NwsEffectif");

            migrationBuilder.DropColumn(
                name: "StatutId",
                table: "NwsEffectif");

            migrationBuilder.AddColumn<string>(
                name: "Statut",
                table: "NwsEffectif",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
