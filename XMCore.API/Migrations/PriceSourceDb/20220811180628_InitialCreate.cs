using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XMCore.API.Migrations.PriceSourceDb
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceSource");
        }
    }
}
