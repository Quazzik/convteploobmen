using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConvTeploobmen.App.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gases",
                columns: new[] { "Name", "KinematicViscosity" },
                values: new object[,]
                {
                    { "Ar", 20.75 },
                    { "C2H6", 10.470000000000001 },
                    { "C3H8", 9.6999999999999993 },
                    { "C4H10", 8.7599999999999998 },
                    { "C5H12", 7.9100000000000001 },
                    { "C6H14", 7.04 },
                    { "CH4", 11.130000000000001 },
                    { "CO", 14.869999999999999 },
                    { "CO2", 15.609999999999999 },
                    { "H2", 8.7599999999999998 },
                    { "He", 17.760000000000002 },
                    { "Kr", 19.649999999999999 },
                    { "N2", 16.809999999999999 },
                    { "Ne", 17.719999999999999 },
                    { "O2", 17.649999999999999 },
                    { "Xe", 21.18 }
                });

            migrationBuilder.InsertData(
                table: "Prandtls",
                columns: new[] { "Temperature", "Value" },
                values: new object[,]
                {
                    { -50.0, 0.72799999999999998 },
                    { -40.0, 0.72799999999999998 },
                    { -30.0, 0.72299999999999998 },
                    { -20.0, 0.71599999999999997 },
                    { -10.0, 0.71199999999999997 },
                    { 0.0, 0.70699999999999996 },
                    { 10.0, 0.70499999999999996 },
                    { 20.0, 0.70299999999999996 },
                    { 30.0, 0.70099999999999996 },
                    { 40.0, 0.69899999999999995 },
                    { 50.0, 0.69799999999999995 },
                    { 60.0, 0.69599999999999995 },
                    { 70.0, 0.69399999999999995 },
                    { 80.0, 0.69199999999999995 },
                    { 90.0, 0.68999999999999995 },
                    { 100.0, 0.68799999999999994 },
                    { 120.0, 0.68600000000000005 },
                    { 140.0, 0.68400000000000005 },
                    { 160.0, 0.68200000000000005 },
                    { 180.0, 0.68100000000000005 },
                    { 200.0, 0.68000000000000005 },
                    { 250.0, 0.67700000000000005 },
                    { 300.0, 0.67400000000000004 },
                    { 350.0, 0.67600000000000005 },
                    { 400.0, 0.67800000000000005 },
                    { 500.0, 0.68700000000000006 },
                    { 600.0, 0.69899999999999995 },
                    { 700.0, 0.70599999999999996 },
                    { 800.0, 0.71299999999999997 },
                    { 900.0, 0.71699999999999997 },
                    { 1000.0, 0.71899999999999997 },
                    { 1100.0, 0.72199999999999998 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "Ar");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "C2H6");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "C3H8");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "C4H10");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "C5H12");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "C6H14");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "CH4");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "CO");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "CO2");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "H2");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "He");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "Kr");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "N2");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "Ne");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "O2");

            migrationBuilder.DeleteData(
                table: "Gases",
                keyColumn: "Name",
                keyValue: "Xe");

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: -50.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: -40.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: -30.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: -20.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: -10.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 0.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 10.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 20.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 30.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 40.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 50.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 60.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 70.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 80.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 90.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 100.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 120.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 140.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 160.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 180.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 200.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 250.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 300.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 350.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 400.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 500.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 600.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 700.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 800.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 900.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 1000.0);

            migrationBuilder.DeleteData(
                table: "Prandtls",
                keyColumn: "Temperature",
                keyValue: 1100.0);
        }
    }
}
