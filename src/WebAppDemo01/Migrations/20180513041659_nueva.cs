using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppDemo01.Migrations
{
    public partial class nueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasTrabajo",
                columns: table => new
                {
                    CodigoArea = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionArea = table.Column<string>(nullable: true),
                    JefeArea = table.Column<string>(nullable: true),
                    NombreArea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasTrabajo", x => x.CodigoArea);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodigoUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Acceso = table.Column<string>(nullable: true),
                    ApellidoUsuarios = table.Column<string>(nullable: true),
                    Carago = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    CodigoArea = table.Column<int>(nullable: false),
                    CodigoNivel = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    FechaCreacion = table.Column<string>(nullable: true),
                    NombreUsuarios = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodigoUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_AreasTrabajo_CodigoArea",
                        column: x => x.CodigoArea,
                        principalTable: "AreasTrabajo",
                        principalColumn: "CodigoArea",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CodigoArea",
                table: "Usuarios",
                column: "CodigoArea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "AreasTrabajo");
        }
    }
}
