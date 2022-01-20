using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SourceMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: false),
                    Descriptors = table.Column<int>(type: "INTEGER", nullable: true),
                    Components = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellResistance = table.Column<string>(type: "TEXT", nullable: true),
                    SavingThrow = table.Column<string>(type: "TEXT", nullable: true),
                    HasCostlyComponents = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaterialCosts = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDismissable = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsShapeable = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMythic = table.Column<bool>(type: "INTEGER", nullable: false),
                    MythicText = table.Column<string>(type: "TEXT", nullable: true),
                    MythicAugmented = table.Column<string>(type: "TEXT", nullable: true),
                    CastingTime = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: false),
                    Area = table.Column<string>(type: "TEXT", nullable: true),
                    Effect = table.Column<string>(type: "TEXT", nullable: true),
                    Range = table.Column<string>(type: "TEXT", nullable: true),
                    Targets = table.Column<string>(type: "TEXT", nullable: true),
                    Bloodline = table.Column<string>(type: "TEXT", nullable: true),
                    Deity = table.Column<string>(type: "TEXT", nullable: true),
                    Domain = table.Column<string>(type: "TEXT", nullable: true),
                    HauntStatistics = table.Column<string>(type: "TEXT", nullable: true),
                    Patron = table.Column<string>(type: "TEXT", nullable: true),
                    School = table.Column<string>(type: "TEXT", nullable: false),
                    Subschool = table.Column<string>(type: "TEXT", nullable: true),
                    SourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spell_SourceMaterial_SourceId",
                        column: x => x.SourceId,
                        principalTable: "SourceMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassLevel_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassLevel_Spell_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spell",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassLevel_ClassId",
                table: "ClassLevel",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassLevel_SpellId",
                table: "ClassLevel",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_Spell_SourceId",
                table: "Spell",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassLevel");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "SourceMaterial");
        }
    }
}
