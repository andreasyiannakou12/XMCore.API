using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XMCore.API.Migrations.PriceDataDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceSource",
                columns: table => new
                {
                    PriceSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceSourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceSourceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceSourceEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceSourceDocsEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceSource", x => x.PriceSourceId);
                });

            migrationBuilder.CreateTable(
                name: "PriceData",
                columns: table => new
                {
                    PriceDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    volume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percent_change_24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vwap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    high = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    low = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    open_24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    open = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceSourceId = table.Column<int>(type: "int", nullable: false),
                    PriceSourceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceData", x => x.PriceDataId);
                    table.ForeignKey(
                        name: "FK_PriceData_PriceSource_PriceSourceId",
                        column: x => x.PriceSourceId,
                        principalTable: "PriceSource",
                        principalColumn: "PriceSourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceData_PriceSourceId",
                table: "PriceData",
                column: "PriceSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceData");

            migrationBuilder.DropTable(
                name: "PriceSource");
        }
    }
}
