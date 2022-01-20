using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class nomoreenums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptors",
                table: "Spell");

            migrationBuilder.RenameColumn(
                name: "Components",
                table: "Spell",
                newName: "HasVerbalComponent");

            migrationBuilder.AddColumn<bool>(
                name: "HasDivineFocusComponent",
                table: "Spell",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFocusComponent",
                table: "Spell",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMaterialComponent",
                table: "Spell",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSomaticComponent",
                table: "Spell",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Descriptor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SpellId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptor_Spell_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spell",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 29, "Acid", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 30, "Air", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 31, "Chaotic", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 32, "Cold", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 33, "Curse", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 34, "Darkness", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 35, "Death", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 36, "Disease", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 37, "Draconic", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 38, "Earth", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 39, "Electricity", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 40, "Emotion", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 41, "Evil", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 42, "Fear", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 43, "Fire", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 44, "Force", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 45, "Good", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 46, "LanguageDependent", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 47, "Lawful", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 48, "Light", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 49, "Meditative", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 50, "MindAffecting", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 51, "Pain", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 52, "Poison", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 53, "Ruse", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 54, "Shadow", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 55, "Sonic", null });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Id", "Name", "SpellId" },
                values: new object[] { 56, "Water", null });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptor_SpellId",
                table: "Descriptor",
                column: "SpellId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptor");

            migrationBuilder.DropColumn(
                name: "HasDivineFocusComponent",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "HasFocusComponent",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "HasMaterialComponent",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "HasSomaticComponent",
                table: "Spell");

            migrationBuilder.RenameColumn(
                name: "HasVerbalComponent",
                table: "Spell",
                newName: "Components");

            migrationBuilder.AddColumn<int>(
                name: "Descriptors",
                table: "Spell",
                type: "INTEGER",
                nullable: true);
        }
    }
}
