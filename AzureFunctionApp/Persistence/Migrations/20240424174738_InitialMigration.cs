using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureFunctionApp.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Planner = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    BudgetType = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BrandId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdRuns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Placement = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    MediaType = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Units = table.Column<int>(type: "int", nullable: true),
                    UnitType = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ClientComment = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    BookingComment = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    FinanceComment = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    EstimatedAV = table.Column<double>(type: "float", nullable: true),
                    EstimatedCT = table.Column<int>(type: "int", nullable: true),
                    EstimatedCTR = table.Column<double>(type: "float", nullable: true),
                    EstimatedLead = table.Column<double>(type: "float", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    NetNet = table.Column<double>(type: "float", nullable: true),
                    SalesHouse = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    CampaignId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdRuns_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ChannelId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    CampaignId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    BuyingPeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuyingPeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    SkipBuying = table.Column<bool>(type: "bit", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    MediumId = table.Column<int>(type: "int", nullable: false),
                    TechnicalCostId = table.Column<int>(type: "int", nullable: false),
                    AdvertisingCode = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    AllowInvoiceOverride = table.Column<bool>(type: "bit", nullable: false),
                    AgencyId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    CampaignId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SizeId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    FormatId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    AdRunId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sizes_AdRuns_AdRunId",
                        column: x => x.AdRunId,
                        principalTable: "AdRuns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeeklyBreakdowns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomId = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    NetNet = table.Column<double>(type: "float", nullable: true),
                    AdRunId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyBreakdowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyBreakdowns_AdRuns_AdRunId",
                        column: x => x.AdRunId,
                        principalTable: "AdRuns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdRuns_CampaignId",
                table: "AdRuns",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ClientId",
                table: "Brands",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_BrandId",
                table: "Campaigns",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CampaignId",
                table: "Jobs",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CampaignId",
                table: "Services",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_AdRunId",
                table: "Sizes",
                column: "AdRunId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyBreakdowns_AdRunId",
                table: "WeeklyBreakdowns",
                column: "AdRunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "WeeklyBreakdowns");

            migrationBuilder.DropTable(
                name: "AdRuns");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
