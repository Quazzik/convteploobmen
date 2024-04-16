using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConvTeploobmen.App.Migrations
{
    /// <inheritdoc />
    public partial class addMoreData : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttackAngles");
        }
    }
}
