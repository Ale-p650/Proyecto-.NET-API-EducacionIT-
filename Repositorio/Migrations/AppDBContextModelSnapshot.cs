﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositorio;

#nullable disable

namespace Repositorio.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Model.Entidades.Album", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ArtistaID")
                        .HasColumnType("int");

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroTracks")
                        .HasColumnType("int");

                    b.Property<int?>("PaisID")
                        .HasColumnType("int");

                    b.Property<string>("PathCover")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoDisco")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArtistaID");

                    b.HasIndex("PaisID");

                    b.ToTable("Albums", "dbo");
                });

            modelBuilder.Entity("Model.Entidades.AlbumsGeneros", b =>
                {
                    b.Property<int>("GeneroID")
                        .HasColumnType("int");

                    b.Property<int>("AlbumID")
                        .HasColumnType("int");

                    b.HasKey("GeneroID", "AlbumID");

                    b.HasIndex("AlbumID");

                    b.ToTable("AlbumsGeneros", "dbo");
                });

            modelBuilder.Entity("Model.Entidades.Artista", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Oyentes")
                        .HasColumnType("int");

                    b.Property<int>("PaisID")
                        .HasColumnType("int");

                    b.Property<string>("PathFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PaisID");

                    b.ToTable("Artistas", "dbo");
                });

            modelBuilder.Entity("Model.Entidades.Cancion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AlbumID")
                        .HasColumnType("int");

                    b.Property<int>("ArtistaID")
                        .HasColumnType("int");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrdenAlbum")
                        .HasColumnType("int");

                    b.Property<int?>("PlaylistID")
                        .HasColumnType("int");

                    b.Property<int>("Reproducciones")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AlbumID");

                    b.HasIndex("ArtistaID");

                    b.HasIndex("Nombre");

                    b.HasIndex("PlaylistID");

                    b.ToTable("Canciones", "dbo");
                });

            modelBuilder.Entity("Model.Entidades.Genero", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NombreGenero")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("NombreGenero");

                    b.ToTable("Generos", "dbo");
                });

            modelBuilder.Entity("Model.Entidades.Pais", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("NombrePais");

                    b.ToTable("Paises", "dbo");
                });

            modelBuilder.Entity("Model.Entidades.Playlist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroTracks")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Playlists", "dbo");
                });

            modelBuilder.Entity("Model.Entidades.Album", b =>
                {
                    b.HasOne("Model.Entidades.Artista", "Artista")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Entidades.Pais", null)
                        .WithMany("Albums")
                        .HasForeignKey("PaisID");

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("Model.Entidades.AlbumsGeneros", b =>
                {
                    b.HasOne("Model.Entidades.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entidades.Genero", null)
                        .WithMany()
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entidades.Artista", b =>
                {
                    b.HasOne("Model.Entidades.Pais", "Pais")
                        .WithMany("Artistas")
                        .HasForeignKey("PaisID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Model.Entidades.Cancion", b =>
                {
                    b.HasOne("Model.Entidades.Album", "Album")
                        .WithMany("Canciones")
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Entidades.Artista", "Artista")
                        .WithMany("Canciones")
                        .HasForeignKey("ArtistaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Entidades.Playlist", null)
                        .WithMany("Canciones")
                        .HasForeignKey("PlaylistID");

                    b.Navigation("Album");

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("Model.Entidades.Album", b =>
                {
                    b.Navigation("Canciones");
                });

            modelBuilder.Entity("Model.Entidades.Artista", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Canciones");
                });

            modelBuilder.Entity("Model.Entidades.Pais", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Artistas");
                });

            modelBuilder.Entity("Model.Entidades.Playlist", b =>
                {
                    b.Navigation("Canciones");
                });
#pragma warning restore 612, 618
        }
    }
}
