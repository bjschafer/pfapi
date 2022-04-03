using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class newdescriptors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "LanguageDependent");

            migrationBuilder.DeleteData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "MindAffecting");

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Figment", 57 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Language-Dependent", 46 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Mind-Affecting", 50 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Figment");

            migrationBuilder.DeleteData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Language-Dependent");

            migrationBuilder.DeleteData(
                table: "Descriptor",
                keyColumn: "Name",
                keyValue: "Mind-Affecting");

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "LanguageDependent", 46 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "MindAffecting", 50 });
        }
    }
}
