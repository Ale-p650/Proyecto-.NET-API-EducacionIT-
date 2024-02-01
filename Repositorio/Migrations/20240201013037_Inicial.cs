using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Generos",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGenero = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePais = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTracks = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oyentes = table.Column<int>(type: "int", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    PathFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Artistas_Paises_PaisID",
                        column: x => x.PaisID,
                        principalSchema: "dbo",
                        principalTable: "Paises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDisco = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    NumeroTracks = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    PathCover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistaID = table.Column<int>(type: "int", nullable: false),
                    PaisID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Albums_Artistas_ArtistaID",
                        column: x => x.ArtistaID,
                        principalSchema: "dbo",
                        principalTable: "Artistas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Albums_Paises_PaisID",
                        column: x => x.PaisID,
                        principalSchema: "dbo",
                        principalTable: "Paises",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AlbumsGeneros",
                schema: "dbo",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    GeneroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumsGeneros", x => new { x.GeneroID, x.AlbumID });
                    table.ForeignKey(
                        name: "FK_AlbumsGeneros_Albums_AlbumID",
                        column: x => x.AlbumID,
                        principalSchema: "dbo",
                        principalTable: "Albums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumsGeneros_Generos_GeneroID",
                        column: x => x.GeneroID,
                        principalSchema: "dbo",
                        principalTable: "Generos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Canciones",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrdenAlbum = table.Column<int>(type: "int", nullable: false),
                    Reproducciones = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    ArtistaID = table.Column<int>(type: "int", nullable: false),
                    PlaylistID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Canciones_Albums_AlbumID",
                        column: x => x.AlbumID,
                        principalSchema: "dbo",
                        principalTable: "Albums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Canciones_Artistas_ArtistaID",
                        column: x => x.ArtistaID,
                        principalSchema: "dbo",
                        principalTable: "Artistas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Canciones_Playlists_PlaylistID",
                        column: x => x.PlaylistID,
                        principalSchema: "dbo",
                        principalTable: "Playlists",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistaID",
                schema: "dbo",
                table: "Albums",
                column: "ArtistaID");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_PaisID",
                schema: "dbo",
                table: "Albums",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumsGeneros_AlbumID",
                schema: "dbo",
                table: "AlbumsGeneros",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_PaisID",
                schema: "dbo",
                table: "Artistas",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_AlbumID",
                schema: "dbo",
                table: "Canciones",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_ArtistaID",
                schema: "dbo",
                table: "Canciones",
                column: "ArtistaID");

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_Nombre",
                schema: "dbo",
                table: "Canciones",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_PlaylistID",
                schema: "dbo",
                table: "Canciones",
                column: "PlaylistID");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_NombreGenero",
                schema: "dbo",
                table: "Generos",
                column: "NombreGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_NombrePais",
                schema: "dbo",
                table: "Paises",
                column: "NombrePais");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UsuarioID",
                schema: "dbo",
                table: "Playlists",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumsGeneros",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Canciones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Generos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Albums",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Playlists",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Artistas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Paises",
                schema: "dbo");
        }
    }
}
