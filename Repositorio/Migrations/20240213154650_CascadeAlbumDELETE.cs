using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class CascadeAlbumDELETE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Canciones_Albums_AlbumID",
                schema: "dbo",
                table: "Canciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Canciones_Albums_AlbumID",
                schema: "dbo",
                table: "Canciones",
                column: "AlbumID",
                principalSchema: "dbo",
                principalTable: "Albums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Canciones_Albums_AlbumID",
                schema: "dbo",
                table: "Canciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Canciones_Albums_AlbumID",
                schema: "dbo",
                table: "Canciones",
                column: "AlbumID",
                principalSchema: "dbo",
                principalTable: "Albums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
