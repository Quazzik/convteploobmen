using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConvTeploobmen.Client.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttackAngles",
                columns: table => new
                {
                    Degree = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackAngles", x => x.Degree);
                });

            migrationBuilder.CreateTable(
                name: "ThermalConductancesKoeffs",
                columns: table => new
                {
                    GasName = table.Column<string>(type: "TEXT", nullable: false),
                    koeff1 = table.Column<double>(type: "REAL", nullable: false),
                    koeff2 = table.Column<double>(type: "REAL", nullable: false),
                    koeff3 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThermalConductancesKoeffs", x => x.GasName);
                });

            migrationBuilder.CreateTable(
                name: "ViscositiesKoeffs",
                columns: table => new
                {
                    GasName = table.Column<string>(type: "TEXT", nullable: false),
                    koeff1 = table.Column<double>(type: "REAL", nullable: false),
                    koeff2 = table.Column<double>(type: "REAL", nullable: false),
                    koeff3 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViscositiesKoeffs", x => x.GasName);
                });

            migrationBuilder.InsertData(
                table: "AttackAngles",
                columns: new[] { "Degree", "Value" },
                values: new object[,]
                {
                    { 10, 0.41999999999999998 },
                    { 20, 0.52000000000000002 },
                    { 30, 0.67000000000000004 },
                    { 40, 0.78000000000000003 },
                    { 50, 0.88 },
                    { 60, 0.93999999999999995 },
                    { 70, 0.97999999999999998 },
                    { 80, 1.0 },
                    { 90, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "ThermalConductancesKoeffs",
                columns: new[] { "GasName", "koeff1", "koeff2", "koeff3" },
                values: new object[,]
                {
                    { "Air", -2E-08, 6.9999999999999994E-05, 0.025399999999999999 },
                    { "CO2", -2E-08, 0.00080000000000000004, 0.14099999999999999 },
                    { "H2O", -6.9999999999999997E-07, 0.00069999999999999999, 0.16789999999999999 },
                    { "N2", -1.9999999999999999E-07, 0.00059999999999999995, 0.2525 },
                    { "O2", -2.9999999999999999E-07, 0.00089999999999999998, 0.24249999999999999 }
                });

            migrationBuilder.InsertData(
                table: "ViscositiesKoeffs",
                columns: new[] { "GasName", "koeff1", "koeff2", "koeff3" },
                values: new object[,]
                {
                    { "Air", 5.9999999999999997E-07, 0.0011000000000000001, 0.11459999999999999 },
                    { "CO2", 3.9999999999999998E-07, 0.00069999999999999999, 0.052999999999999999 },
                    { "H2O", 1.9999999999999999E-06, 0.00089999999999999998, 0.1009 },
                    { "N2", 5.9999999999999997E-07, 0.001, 0.1173 },
                    { "O2", 5.9999999999999997E-07, 0.0011000000000000001, 0.11559999999999999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttackAngles");

            migrationBuilder.DropTable(
                name: "ThermalConductancesKoeffs");

            migrationBuilder.DropTable(
                name: "ViscositiesKoeffs");
        }
    }
}
