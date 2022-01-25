using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class initial : Migration
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
                name: "Descriptor",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptor", x => x.Name);
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
                    SpellResistance = table.Column<string>(type: "TEXT", nullable: true),
                    SavingThrow = table.Column<string>(type: "TEXT", nullable: true),
                    HasDivineFocusComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasFocusComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasMaterialComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasSomaticComponent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasVerbalComponent = table.Column<bool>(type: "INTEGER", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "DescriptorSpell",
                columns: table => new
                {
                    DescriptorsName = table.Column<string>(type: "TEXT", nullable: false),
                    SpellsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptorSpell", x => new { x.DescriptorsName, x.SpellsId });
                    table.ForeignKey(
                        name: "FK_DescriptorSpell_Descriptor_DescriptorsName",
                        column: x => x.DescriptorsName,
                        principalTable: "Descriptor",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptorSpell_Spell_SpellsId",
                        column: x => x.SpellsId,
                        principalTable: "Spell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Adept" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Alchemist" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Antipaladin" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Bard" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Bloodrager" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Cleric" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Druid" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Hunter" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Inquisitor" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Investigator" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Magus" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Medium" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Mesmerist" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "Occultist" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 15, "Oracle" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "Paladin" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 17, "Psychic" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "Ranger" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 19, "Shaman" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 20, "Scald" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 21, "SpellLikeAbility" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 22, "Sorcerer" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 23, "Spiritualist" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 24, "Summoner" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 25, "SummonerUnchained" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 26, "Witch" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Name" },
                values: new object[] { 27, "Wizard" });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Acid", 29 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Air", 30 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Chaotic", 31 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Cold", 32 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Curse", 33 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Darkness", 34 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Death", 35 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Disease", 36 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Draconic", 37 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Earth", 38 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Electricity", 39 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Emotion", 40 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Evil", 41 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Fear", 42 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Fire", 43 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Force", 44 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Good", 45 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "LanguageDependent", 46 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Lawful", 47 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Light", 48 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Meditative", 49 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "MindAffecting", 50 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Pain", 51 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Poison", 52 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Ruse", 53 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Shadow", 54 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Sonic", 55 });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[] { "Water", 56 });

            migrationBuilder.CreateIndex(
                name: "IX_ClassLevel_ClassId",
                table: "ClassLevel",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassLevel_SpellId",
                table: "ClassLevel",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptorSpell_SpellsId",
                table: "DescriptorSpell",
                column: "SpellsId");

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
                name: "DescriptorSpell");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Descriptor");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "SourceMaterial");
        }
    }
}
