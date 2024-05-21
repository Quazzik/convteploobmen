using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConvTeploobmen.Client.Migrations
{
    /// <inheritdoc />
    public partial class mistakeEdits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ThermalConductancesKoeffs",
                keyColumn: "GasName",
                keyValue: "Air");

            migrationBuilder.DeleteData(
                table: "ViscositiesKoeffs",
                keyColumn: "GasName",
                keyValue: "Air");

            migrationBuilder.UpdateData(
                table: "ThermalConductancesKoeffs",
                keyColumn: "GasName",
                keyValue: "CO2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 2.0000000000000001E-10, 8.0000000000000007E-05, 0.0141 });

            migrationBuilder.UpdateData(
                table: "ThermalConductancesKoeffs",
                keyColumn: "GasName",
                keyValue: "H2O",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 7.0000000000000005E-08, 6.9999999999999994E-05, 0.016789999999999999 });

            migrationBuilder.UpdateData(
                table: "ThermalConductancesKoeffs",
                keyColumn: "GasName",
                keyValue: "N2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { -2E-08, 6.0000000000000002E-05, 0.025250000000000002 });

            migrationBuilder.UpdateData(
                table: "ThermalConductancesKoeffs",
                keyColumn: "GasName",
                keyValue: "O2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { -2.9999999999999997E-08, 9.0000000000000006E-05, 0.024250000000000001 });

            migrationBuilder.UpdateData(
                table: "ViscositiesKoeffs",
                keyColumn: "GasName",
                keyValue: "CO2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 3.9999999999999998E-11, 7.0000000000000005E-08, 5.0000000000000004E-06 });

            migrationBuilder.UpdateData(
                table: "ViscositiesKoeffs",
                keyColumn: "GasName",
                keyValue: "H2O",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 2.0000000000000001E-10, 8.9999999999999999E-08, 1.0000000000000001E-05 });

            migrationBuilder.UpdateData(
                table: "ViscositiesKoeffs",
                keyColumn: "GasName",
                keyValue: "N2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 6E-11, 9.9999999999999995E-08, 1.0000000000000001E-05 });

            migrationBuilder.UpdateData(
                table: "ViscositiesKoeffs",
                keyColumn: "GasName",
                keyValue: "O2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 6E-11, 9.9999999999999995E-08, 1.0000000000000001E-05 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ThermalConductancesKoeffs",
                keyColumn: "GasName",
                keyValue: "CO2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { -2E-08, 0.00080000000000000004, 0.14099999999999999 });

            migrationBuilder.UpdateData(
                table: "ThermalConductancesKoeffs",
                keyColumn: "GasName",
                keyValue: "H2O",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { -6.9999999999999997E-07, 0.00069999999999999999, 0.16789999999999999 });

            migrationBuilder.UpdateData(
                table: "ThermalConductancesKoeffs",
                keyColumn: "GasName",
                keyValue: "N2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { -1.9999999999999999E-07, 0.00059999999999999995, 0.2525 });

            migrationBuilder.UpdateData(
                table: "ThermalConductancesKoeffs",
                keyColumn: "GasName",
                keyValue: "O2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { -2.9999999999999999E-07, 0.00089999999999999998, 0.24249999999999999 });

            migrationBuilder.InsertData(
                table: "ThermalConductancesKoeffs",
                columns: new[] { "GasName", "koeff1", "koeff2", "koeff3" },
                values: new object[] { "Air", -2E-08, 6.9999999999999994E-05, 0.025399999999999999 });

            migrationBuilder.UpdateData(
                table: "ViscositiesKoeffs",
                keyColumn: "GasName",
                keyValue: "CO2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 3.9999999999999998E-07, 0.00069999999999999999, 0.052999999999999999 });

            migrationBuilder.UpdateData(
                table: "ViscositiesKoeffs",
                keyColumn: "GasName",
                keyValue: "H2O",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 1.9999999999999999E-06, 0.00089999999999999998, 0.1009 });

            migrationBuilder.UpdateData(
                table: "ViscositiesKoeffs",
                keyColumn: "GasName",
                keyValue: "N2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 5.9999999999999997E-07, 0.001, 0.1173 });

            migrationBuilder.UpdateData(
                table: "ViscositiesKoeffs",
                keyColumn: "GasName",
                keyValue: "O2",
                columns: new[] { "koeff1", "koeff2", "koeff3" },
                values: new object[] { 5.9999999999999997E-07, 0.0011000000000000001, 0.11559999999999999 });

            migrationBuilder.InsertData(
                table: "ViscositiesKoeffs",
                columns: new[] { "GasName", "koeff1", "koeff2", "koeff3" },
                values: new object[] { "Air", 5.9999999999999997E-07, 0.0011000000000000001, 0.11459999999999999 });
        }
    }
}
