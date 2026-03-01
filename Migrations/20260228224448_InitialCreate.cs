using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockActual = table.Column<int>(type: "int", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesReposicion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesReposicion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesReposicion_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Calzado" },
                    { 2, "Ropa Superior" },
                    { 3, "Pantalones" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "Nombre", "Precio", "StockActual", "StockMinimo" },
                values: new object[,]
                {
                    { 1, 1, "Tenis Nike Air Max 270 - Talla 40", 580000m, 15, 5 },
                    { 2, 1, "Tenis Adidas Ultraboost - Talla 38", 620000m, 2, 8 },
                    { 3, 2, "Camiseta Básica Oversize Blanca - M", 85000m, 50, 20 },
                    { 4, 2, "Hoodie Negro Algodón - L", 145000m, 4, 10 },
                    { 5, 3, "Jeans Slim Fit Azul - Talla 32", 180000m, 25, 15 },
                    { 6, 3, "Joggers de Entrenamiento Gris - S", 120000m, 3, 7 },
                    { 7, 1, "Tenis Puma Rider - Talla 41", 320000m, 12, 5 },
                    { 8, 2, "Chaqueta Denim Clásica - M", 210000m, 1, 5 },
                    { 9, 3, "Shorts Deportivos Pro - L", 95000m, 30, 10 },
                    { 10, 1, "Tenis Jordan Retro 1 - Talla 42", 850000m, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesReposicion_ProductoId",
                table: "OrdenesReposicion",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesReposicion");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
