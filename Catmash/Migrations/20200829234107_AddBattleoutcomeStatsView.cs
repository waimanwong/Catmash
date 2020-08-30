using Microsoft.EntityFrameworkCore.Migrations;

namespace Catmash.Migrations
{
    public partial class AddBattleoutcomeStatsView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlScript = @"
CREATE VIEW ImageStatistics AS  
SELECT images.id, 
        images.url, 
        IIF(battleStats.selectedCount is null,  0, battleStats.selectedCount) as selectedCount
FROM Images LEFT JOIN 
	(SELECT SelectedImageId AS imageId, count(1) AS selectedCount 
	FROM BattleOutcomes GROUP BY SelectedImageId) AS battleStats ON images.id = battleStats.imageId";

            migrationBuilder.Sql(sqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
