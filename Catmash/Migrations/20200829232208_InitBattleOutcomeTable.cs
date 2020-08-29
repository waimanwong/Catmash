using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catmash.Migrations
{
    public partial class InitBattleOutcomeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BattleOutcomes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    SelectedImageId = table.Column<string>(nullable: true),
                    UnselectedImageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleOutcomes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleOutcomes");
        }
    }
}
