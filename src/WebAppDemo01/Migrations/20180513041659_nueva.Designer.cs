using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebAppDemo01.models;

namespace WebAppDemo01.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180513041659_nueva")]
    partial class nueva
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppDemo01.models.AreasTrabajo", b =>
                {
                    b.Property<int>("CodigoArea")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionArea");

                    b.Property<string>("JefeArea");

                    b.Property<string>("NombreArea");

                    b.HasKey("CodigoArea");

                    b.ToTable("AreasTrabajo");
                });

            modelBuilder.Entity("WebAppDemo01.models.CarroComprasItems", b =>
                {
                    b.Property<int>("codigoProductoSeleccionado")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProductosCodigoProducto");

                    b.Property<int>("cantidadProductoSeleccionado");

                    b.Property<string>("codigoCarroCompras");

                    b.HasKey("codigoProductoSeleccionado");

                    b.HasIndex("ProductosCodigoProducto");

                    b.ToTable("CarroComprasItems");
                });

            modelBuilder.Entity("WebAppDemo01.models.CatProductos", b =>
                {
                    b.Property<int>("CodigoCatProducto")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionCatProducto");

                    b.Property<string>("NombreCatProducto");

                    b.HasKey("CodigoCatProducto");

                    b.ToTable("CategoriasProductos");
                });

            modelBuilder.Entity("WebAppDemo01.models.Productos", b =>
                {
                    b.Property<int>("CodigoProducto")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CatProductosCodigoCatProducto");

                    b.Property<int>("CodigoCategoria");

                    b.Property<string>("DescripCortaProducto");

                    b.Property<string>("DescripLargaProducto");

                    b.Property<string>("DescripProducto");

                    b.Property<bool>("EstadoProducto");

                    b.Property<string>("ImagenPreviaURL");

                    b.Property<string>("ImagenURL");

                    b.Property<string>("NombreProducto");

                    b.Property<decimal>("PreCostoProducto");

                    b.Property<decimal>("PreVentaProducto");

                    b.Property<bool>("ProductoEnExistencia");

                    b.Property<bool>("ProductoEnOferta");

                    b.HasKey("CodigoProducto");

                    b.HasIndex("CatProductosCodigoCatProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("WebAppDemo01.models.Usuarios", b =>
                {
                    b.Property<int>("CodigoUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Acceso");

                    b.Property<string>("ApellidoUsuarios");

                    b.Property<string>("Carago");

                    b.Property<string>("Clave");

                    b.Property<int>("CodigoArea");

                    b.Property<int>("CodigoNivel");

                    b.Property<bool>("Estado");

                    b.Property<string>("FechaCreacion");

                    b.Property<string>("NombreUsuarios");

                    b.HasKey("CodigoUsuario");

                    b.HasIndex("CodigoArea");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebAppDemo01.models.CarroComprasItems", b =>
                {
                    b.HasOne("WebAppDemo01.models.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductosCodigoProducto");
                });

            modelBuilder.Entity("WebAppDemo01.models.Productos", b =>
                {
                    b.HasOne("WebAppDemo01.models.CatProductos", "CatProductos")
                        .WithMany("Productos")
                        .HasForeignKey("CatProductosCodigoCatProducto");
                });

            modelBuilder.Entity("WebAppDemo01.models.Usuarios", b =>
                {
                    b.HasOne("WebAppDemo01.models.AreasTrabajo", "AreasTrabajo")
                        .WithMany("Usuarios")
                        .HasForeignKey("CodigoArea")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
