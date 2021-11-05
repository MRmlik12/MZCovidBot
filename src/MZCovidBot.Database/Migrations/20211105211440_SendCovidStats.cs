using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MZCovidBot.Database.Migrations
{
    public partial class SendCovidStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CovidData",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Infected = table.Column<long>(type: "bigint", nullable: false),
                    Deceased = table.Column<long>(type: "bigint", nullable: false),
                    Recovered = table.Column<long>(type: "bigint", nullable: false),
                    DailyInfected = table.Column<long>(type: "bigint", nullable: false),
                    DailyTested = table.Column<long>(type: "bigint", nullable: false),
                    DailyPositiveTests = table.Column<long>(type: "bigint", nullable: false),
                    DailyDeceased = table.Column<long>(type: "bigint", nullable: false),
                    DailyRecovered = table.Column<long>(type: "bigint", nullable: false),
                    DailyQuarantine = table.Column<long>(type: "bigint", nullable: false),
                    TxtDate = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedAtApify = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAtSource = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    SourceUrl = table.Column<string>(type: "text", nullable: true),
                    HistoryData = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CovidData");
        }
    }
}
