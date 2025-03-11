using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class MigracionUno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    PkAuthor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.PkAuthor);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    PkCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.PkCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Galeria",
                columns: table => new
                {
                    PkGaleria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGaleria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galeria", x => x.PkGaleria);
                });

            migrationBuilder.CreateTable(
                name: "Fotografia",
                columns: table => new
                {
                    PkFotografia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkAuthor = table.Column<int>(type: "int", nullable: false),
                    AuthorPkAuthor = table.Column<int>(type: "int", nullable: true),
                    FkCategoria = table.Column<int>(type: "int", nullable: false),
                    CategoriaPkCategoria = table.Column<int>(type: "int", nullable: true),
                    FkGaleria = table.Column<int>(type: "int", nullable: false),
                    GaleriaPkGaleria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografia", x => x.PkFotografia);
                    table.ForeignKey(
                        name: "FK_Fotografia_Authors_AuthorPkAuthor",
                        column: x => x.AuthorPkAuthor,
                        principalTable: "Authors",
                        principalColumn: "PkAuthor");
                    table.ForeignKey(
                        name: "FK_Fotografia_Categorias_CategoriaPkCategoria",
                        column: x => x.CategoriaPkCategoria,
                        principalTable: "Categorias",
                        principalColumn: "PkCategoria");
                    table.ForeignKey(
                        name: "FK_Fotografia_Galeria_GaleriaPkGaleria",
                        column: x => x.GaleriaPkGaleria,
                        principalTable: "Galeria",
                        principalColumn: "PkGaleria");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotografia_AuthorPkAuthor",
                table: "Fotografia",
                column: "AuthorPkAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografia_CategoriaPkCategoria",
                table: "Fotografia",
                column: "CategoriaPkCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografia_GaleriaPkGaleria",
                table: "Fotografia",
                column: "GaleriaPkGaleria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotografia");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Galeria");
        }
    }
}
