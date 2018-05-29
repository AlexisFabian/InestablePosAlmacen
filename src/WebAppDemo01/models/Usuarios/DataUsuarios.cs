using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppDemo01.models
{
    public static class DataUsuarios
    {
        
        public static void AgregarData(IApplicationBuilder ab)
        {
            AppDbContext contexto = ab.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!contexto.CategoriasUsuarios.Any())
            {
                //CategoriasProductosIniciales es una coleccion local
                contexto.CategoriasUsuarios.AddRange(CategoriasUsuariosIniciales.Select(c => c.Value));
            }
            if (!contexto.Usuarios.Any())
            {
                contexto.AddRange
                (
                    new Usuarios { NombreUsuario = "Alexis", ApellidoUsuario = "Fabian", UserName = "TheBestUser", Contraseña = "123", fechacreacion = "Miercoles 23", UsuariosInactivos = true, ListaNegra = false, CatUsuarios = CategoriasUsuariosIniciales["Departamento de Tecnologia"] },
                    new Usuarios { NombreUsuario = "Carlos", ApellidoUsuario = "Luca", UserName = "TheBestUser", Contraseña = "123", fechacreacion = "Miercoles 23", UsuariosInactivos = false, ListaNegra = false, CatUsuarios = CategoriasUsuariosIniciales["Departamento de Ventas"] },
                    new Usuarios { NombreUsuario = "Pedro", ApellidoUsuario = "Tns", UserName = "TheBestUser", Contraseña = "123", fechacreacion = "Miercoles 23", UsuariosInactivos = true, ListaNegra = false, CatUsuarios = CategoriasUsuariosIniciales["Departamento de Ventas"] },
                    new Usuarios { NombreUsuario = "Samael", ApellidoUsuario = "Del Rio", UserName = "TheBestUser", Contraseña = "123", fechacreacion = "Miercoles 23", UsuariosInactivos = true, ListaNegra = false, CatUsuarios = CategoriasUsuariosIniciales["Departamento de Tecnologia"] },
                    new Usuarios { NombreUsuario = "George", ApellidoUsuario = "Perez", UserName = "TheBestUser", Contraseña = "123", fechacreacion = "Miercoles 23", UsuariosInactivos = false, ListaNegra = false, CatUsuarios = CategoriasUsuariosIniciales["Departamento de Logistica"] },
                    new Usuarios { NombreUsuario = "Benito", ApellidoUsuario = "Calero", UserName = "TheBestUser", Contraseña = "123", fechacreacion = "Miercoles 23", UsuariosInactivos = false, ListaNegra = true, CatUsuarios = CategoriasUsuariosIniciales["Departamento de Logistica"] }



                );
            }

            contexto.SaveChanges();
        }//fin de agregarData

        //se hace referencia a la clase dominio CatProductos
        public static Dictionary<string, CatUsuarios> catUsuariosiniciales;
        public static Dictionary<string, CatUsuarios> CategoriasUsuariosIniciales
        {
            get
            {
                if(catUsuariosiniciales == null)
                {
                    var listadoCategorias = new CatUsuarios[]
                    {
                        new CatUsuarios { NombreCatUo = "Departamento de Tecnologia", DescripcionCatUo ="Encargados de revisar producto relacionado a electronica"},
                        new CatUsuarios { NombreCatUo = "Departamento de Ventas", DescripcionCatUo="Personal para ventas"},
                        new CatUsuarios { NombreCatUo = "Departamento de Logistica", DescripcionCatUo="Creacion de estrategias publicitaria para agilizar las ventas"},
                    };
                    catUsuariosiniciales = new Dictionary<string, CatUsuarios>();

                    foreach(CatUsuarios catproini in listadoCategorias)
                    {
                        catUsuariosiniciales.Add(catproini.NombreCatUo, catproini);
                    }//fin del foreach
                }
                return catUsuariosiniciales;
            }//fin del metodo get
        }//fin de diccionario de categorias
    }
}
