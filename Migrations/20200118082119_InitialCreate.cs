using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Symbol = table.Column<string>(nullable: true),
                    LastPrice = table.Column<string>(nullable: true),
                    DateScrapped = table.Column<DateTime>(nullable: false),
                    Change = table.Column<string>(nullable: true),
                    ChangeRate = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    MarketTime = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true),
                    ShareData = table.Column<string>(nullable: true),
                    AverageVolume = table.Column<string>(nullable: true),
                    MarketCapData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
