using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDescriptorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Descriptor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Descriptor",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Acid",
                column: "Id",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Air",
                column: "Id",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Chaotic",
                column: "Id",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Cold",
                column: "Id",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Curse",
                column: "Id",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Darkness",
                column: "Id",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Death",
                column: "Id",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Disease",
                column: "Id",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Draconic",
                column: "Id",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Earth",
                column: "Id",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Electricity",
                column: "Id",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Emotion",
                column: "Id",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Evil",
                column: "Id",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Fear",
                column: "Id",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Figment",
                column: "Id",
                value: 57);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Fire",
                column: "Id",
                value: 43);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Force",
                column: "Id",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Good",
                column: "Id",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Language-Dependent",
                column: "Id",
                value: 46);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Lawful",
                column: "Id",
                value: 47);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Light",
                column: "Id",
                value: 48);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Meditative",
                column: "Id",
                value: 49);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Mind-Affecting",
                column: "Id",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Pain",
                column: "Id",
                value: 51);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Poison",
                column: "Id",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Ruse",
                column: "Id",
                value: 53);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Shadow",
                column: "Id",
                value: 54);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Sonic",
                column: "Id",
                value: 55);

            migrationBuilder.UpdateData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Water",
                column: "Id",
                value: 56);
        }
    }
}
