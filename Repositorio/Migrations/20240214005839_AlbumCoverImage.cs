using Microsoft.EntityFrameworkCore.Migrations;
using System;


#nullable disable

namespace Repositorio.Migrations
{
    public partial class AlbumCoverImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathCover",
                schema: "dbo",
                table: "Albums");

            migrationBuilder.AddColumn<byte[]>(
                name: "Cover",
                schema: "dbo",
                table: "Albums",
                type: "image",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                schema: "dbo",
                table: "Albums");

            migrationBuilder.AddColumn<string>(
                name: "PathCover",
                schema: "dbo",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
