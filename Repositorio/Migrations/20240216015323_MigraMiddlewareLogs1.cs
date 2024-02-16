using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class MigraMiddlewareLogs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CancionesPlaylists",
                schema: "logs",
                table: "CancionesPlaylists");

            migrationBuilder.RenameTable(
                name: "CancionesPlaylists",
                schema: "logs",
                newName: "MiddlewareLogs",
                newSchema: "logs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MiddlewareLogs",
                schema: "logs",
                table: "MiddlewareLogs",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MiddlewareLogs",
                schema: "logs",
                table: "MiddlewareLogs");

            migrationBuilder.RenameTable(
                name: "MiddlewareLogs",
                schema: "logs",
                newName: "CancionesPlaylists",
                newSchema: "logs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CancionesPlaylists",
                schema: "logs",
                table: "CancionesPlaylists",
                column: "ID");
        }
    }
}
