using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    public partial class initialpgsql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Descriptor",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptor", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SourceMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    SpellResistance = table.Column<string>(type: "text", nullable: true),
                    SavingThrow = table.Column<string>(type: "text", nullable: true),
                    HasDivineFocusComponent = table.Column<bool>(type: "boolean", nullable: false),
                    HasFocusComponent = table.Column<bool>(type: "boolean", nullable: false),
                    HasMaterialComponent = table.Column<bool>(type: "boolean", nullable: false),
                    HasSomaticComponent = table.Column<bool>(type: "boolean", nullable: false),
                    HasVerbalComponent = table.Column<bool>(type: "boolean", nullable: false),
                    HasCostlyComponents = table.Column<bool>(type: "boolean", nullable: false),
                    MaterialCosts = table.Column<int>(type: "integer", nullable: true),
                    ComponentDetails = table.Column<string>(type: "text", nullable: true),
                    IsDismissable = table.Column<bool>(type: "boolean", nullable: false),
                    IsShapeable = table.Column<bool>(type: "boolean", nullable: false),
                    IsMythic = table.Column<bool>(type: "boolean", nullable: false),
                    MythicText = table.Column<string>(type: "text", nullable: true),
                    MythicAugmented = table.Column<string>(type: "text", nullable: true),
                    CastingTime = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<string>(type: "text", nullable: true),
                    Effect = table.Column<string>(type: "text", nullable: true),
                    Range = table.Column<string>(type: "text", nullable: true),
                    Targets = table.Column<string>(type: "text", nullable: true),
                    Bloodline = table.Column<string>(type: "text", nullable: true),
                    Deity = table.Column<string>(type: "text", nullable: true),
                    Domain = table.Column<string>(type: "text", nullable: true),
                    HauntStatistics = table.Column<string>(type: "text", nullable: true),
                    Patron = table.Column<string>(type: "text", nullable: true),
                    School = table.Column<string>(type: "text", nullable: false),
                    Subschool = table.Column<string>(type: "text", nullable: true),
                    SourceId = table.Column<int>(type: "integer", nullable: false)
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
                name: "ClassSpell",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    SpellId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSpell", x => new { x.ClassId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_ClassSpell_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSpell_Spell_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptorSpell",
                columns: table => new
                {
                    DescriptorsName = table.Column<string>(type: "text", nullable: false),
                    SpellsId = table.Column<int>(type: "integer", nullable: false)
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
                values: new object[,]
                {
                    { 1, "Adept" },
                    { 2, "Alchemist" },
                    { 3, "Antipaladin" },
                    { 4, "Bard" },
                    { 5, "Bloodrager" },
                    { 6, "Cleric" },
                    { 7, "Druid" },
                    { 8, "Hunter" },
                    { 9, "Inquisitor" },
                    { 10, "Investigator" },
                    { 11, "Magus" },
                    { 12, "Medium" },
                    { 13, "Mesmerist" },
                    { 14, "Occultist" },
                    { 15, "Oracle" },
                    { 16, "Paladin" },
                    { 17, "Psychic" },
                    { 18, "Ranger" },
                    { 19, "Shaman" },
                    { 20, "Scald" },
                    { 21, "SpellLikeAbility" },
                    { 22, "Sorcerer" },
                    { 23, "Spiritualist" },
                    { 24, "Summoner" },
                    { 25, "SummonerUnchained" },
                    { 26, "Witch" },
                    { 27, "Wizard" }
                });

            migrationBuilder.InsertData(
                table: "Descriptor",
                columns: new[] { "Name", "Id" },
                values: new object[,]
                {
                    { "Acid", 29 },
                    { "Air", 30 },
                    { "Chaotic", 31 },
                    { "Cold", 32 },
                    { "Curse", 33 },
                    { "Darkness", 34 },
                    { "Death", 35 },
                    { "Disease", 36 },
                    { "Draconic", 37 },
                    { "Earth", 38 },
                    { "Electricity", 39 },
                    { "Emotion", 40 },
                    { "Evil", 41 },
                    { "Fear", 42 },
                    { "Figment", 57 },
                    { "Fire", 43 },
                    { "Force", 44 },
                    { "Good", 45 },
                    { "Language-Dependent", 46 },
                    { "Lawful", 47 },
                    { "Light", 48 },
                    { "Meditative", 49 },
                    { "Mind-Affecting", 50 },
                    { "Pain", 51 },
                    { "Poison", 52 },
                    { "Ruse", 53 },
                    { "Shadow", 54 },
                    { "Sonic", 55 },
                    { "Water", 56 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSpell_SpellId",
                table: "ClassSpell",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptorSpell_SpellsId",
                table: "DescriptorSpell",
                column: "SpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_Spell_Name",
                table: "Spell",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spell_SourceId",
                table: "Spell",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSpell");

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
