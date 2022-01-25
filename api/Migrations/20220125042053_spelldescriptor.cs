using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class spelldescriptor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptor_Spell_SpellId",
                table: "Descriptor");

            migrationBuilder.DropIndex(
                name: "IX_Descriptor_SpellId",
                table: "Descriptor");

            migrationBuilder.DropColumn(
                name: "SpellId",
                table: "Descriptor");

            migrationBuilder.CreateTable(
                name: "SpellDescriptor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpellId = table.Column<int>(type: "INTEGER", nullable: false),
                    DescriptorName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDescriptor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellDescriptor_Descriptor_DescriptorName",
                        column: x => x.DescriptorName,
                        principalTable: "Descriptor",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellDescriptor_Spell_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpellDescriptor_DescriptorName",
                table: "SpellDescriptor",
                column: "DescriptorName");

            migrationBuilder.CreateIndex(
                name: "IX_SpellDescriptor_SpellId",
                table: "SpellDescriptor",
                column: "SpellId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellDescriptor");

            migrationBuilder.AddColumn<int>(
                name: "SpellId",
                table: "Descriptor",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Descriptor_SpellId",
                table: "Descriptor",
                column: "SpellId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptor_Spell_SpellId",
                table: "Descriptor",
                column: "SpellId",
                principalTable: "Spell",
                principalColumn: "Id");
        }
    }
}
