using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitCardGeneratorDotNetApi.Migrations
{
    public partial class UpdatedTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rule",
                schema: "ucg",
                table: "Rule");

            migrationBuilder.RenameTable(
                name: "Rule",
                schema: "ucg",
                newName: "Rules",
                newSchema: "ucg");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rules",
                schema: "ucg",
                table: "Rules",
                column: "RuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rules",
                schema: "ucg",
                table: "Rules");

            migrationBuilder.RenameTable(
                name: "Rules",
                schema: "ucg",
                newName: "Rule",
                newSchema: "ucg");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rule",
                schema: "ucg",
                table: "Rule",
                column: "RuleId");
        }
    }
}
