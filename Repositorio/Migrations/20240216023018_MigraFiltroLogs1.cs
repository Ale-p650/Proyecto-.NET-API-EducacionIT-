using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class MigraFiltroLogs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "FiltroLogs",
                newName: "FiltroLogs",
                newSchema: "logs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "FiltroLogs",
                schema: "logs",
                newName: "FiltroLogs");
        }
    }
}
