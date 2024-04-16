using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConvTeploobmen.App.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gases",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    KinematicViscosity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gases", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Prandtls",
                columns: table => new
                {
                    Temperature = table.Column<double>(type: "REAL", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prandtls", x => x.Temperature);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gases");

            migrationBuilder.DropTable(
                name: "Prandtls");
        }
    }
}
