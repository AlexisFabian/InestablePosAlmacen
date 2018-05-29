using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppDemo01.Migrations
{
    public partial class myo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasProductos",
                columns: table => new
                {
                    CodigoCatProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionCatProducto = table.Column<string>(nullable: true),
                    NombreCatProducto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProductos", x => x.CodigoCatProducto);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasUsuarios",
                columns: table => new
                {
                    CodigoCatUo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionCatUo = table.Column<string>(nullable: true),
                    NombreCatUo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasUsuarios", x => x.CodigoCatUo);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodigoProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatProductosCodigoCatProducto = table.Column<int>(nullable: true),
                    CodigoCategoria = table.Column<int>(nullable: false),
                    DescripCortaProducto = table.Column<string>(nullable: true),
                    DescripLargaProducto = table.Column<string>(nullable: true),
                    DescripProducto = table.Column<string>(nullable: true),
                    EstadoProducto = table.Column<bool>(nullable: false),
                    ImagenPreviaURL = table.Column<string>(nullable: true),
                    ImagenURL = table.Column<string>(nullable: true),
                    NombreProducto = table.Column<string>(nullable: true),
                    PreCostoProducto = table.Column<decimal>(nullable: false),
                    PreVentaProducto = table.Column<decimal>(nullable: false),
                    ProductoEnExistencia = table.Column<bool>(nullable: false),
                    ProductoEnOferta = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodigoProducto);
                    table.ForeignKey(
                        name: "FK_Productos_CategoriasProductos_CatProductosCodigoCatProducto",
                        column: x => x.CatProductosCodigoCatProducto,
                        principalTable: "CategoriasProductos",
                        principalColumn: "CodigoCatProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodigoUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApellidoUsuario = table.Column<string>(nullable: true),
                    CatUsuariosCodigoCatUo = table.Column<int>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    ListaNegra = table.Column<bool>(nullable: false),
                    NombreUsuario = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UsuariosInactivos = table.Column<bool>(nullable: false),
                    fechacreacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodigoUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_CategoriasUsuarios_CatUsuariosCodigoCatUo",
                        column: x => x.CatUsuariosCodigoCatUo,
                        principalTable: "CategoriasUsuarios",
                        principalColumn: "CodigoCatUo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarroComprasItems",
                columns: table => new
                {
                    codigoProductoSeleccionado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductosCodigoProducto = table.Column<int>(nullable: true),
                    cantidadProductoSeleccionado = table.Column<int>(nullable: false),
                    codigoCarroCompras = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroComprasItems", x => x.codigoProductoSeleccionado);
                    table.ForeignKey(
                        name: "FK_CarroComprasItems_Productos_ProductosCodigoProducto",
                        column: x => x.ProductosCodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroComprasItems_ProductosCodigoProducto",
                table: "CarroComprasItems",
                column: "ProductosCodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CatProductosCodigoCatProducto",
                table: "Productos",
                column: "CatProductosCodigoCatProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CatUsuariosCodigoCatUo",
                table: "Usuarios",
                column: "CatUsuariosCodigoCatUo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroComprasItems");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "CategoriasUsuarios");

            migrationBuilder.DropTable(
                name: "CategoriasProductos");
        }
    }
}
