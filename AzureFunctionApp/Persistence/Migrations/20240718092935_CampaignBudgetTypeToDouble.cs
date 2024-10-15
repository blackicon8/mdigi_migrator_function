using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureFunctionApp.Persistence.Migrations
{
    public partial class CampaignBudgetTypeToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Budget",
                table: "Campaigns",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "SumRatecard",
                table: "AdRuns",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SumRatecard",
                table: "AdRuns");

            migrationBuilder.AlterColumn<int>(
                name: "Budget",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
