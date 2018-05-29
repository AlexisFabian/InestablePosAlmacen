using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppDemo01.models;
using WebAppDemo01.viewmodels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppDemo01.controllers
{
    public class UsuariosController : Controller
    {
        //objetos de solo lectura que sera instancias de las clases repositorios
        private readonly ICatUsuariosRepositorio _catUsuariosRepositorio;
        private readonly IUsuariosRepositorio _UsuariosRepositorio;

        //constructor de esta clase controller
        public UsuariosController(ICatUsuariosRepositorio catUsuariosRepositorio, IUsuariosRepositorio UsuariosRepositorio)
        {
            _catUsuariosRepositorio = catUsuariosRepositorio;
            _UsuariosRepositorio = UsuariosRepositorio;
        }//fin del constructor

        //metodo para devolver la vista con datos inyectados
        public ViewResult ListaUsuarios(string categoriasUsuarios)
        {
            //bug: si la categoria no se digite justo como esta 
            //almacenada genera un NullReferenceException
            IEnumerable<Usuarios> usuarios;
            string categoriaActual = string.Empty;
            if (string.IsNullOrEmpty(categoriasUsuarios))
            {
                usuarios = _UsuariosRepositorio.Usuarios.OrderBy(p => p.CodigoUsuario);
                categoriaActual = "Todos los Usuarios";
            }
            else
            {
                usuarios = _UsuariosRepositorio.Usuarios.Where(p => p.CatUsuarios.NombreCatUo == categoriasUsuarios)
                    .OrderBy(p => p.CodigoUsuario);
                categoriaActual = _catUsuariosRepositorio.CategoriasUsuarios.FirstOrDefault(c => c.NombreCatUo == categoriasUsuarios).NombreCatUo;
            }

            return View(new ListaUsuariosViewModel
            {
                Usuarios = usuarios,
                CategoriasUsuarios = categoriaActual
            });
        }//fin del metodo ListaProductos

        public IActionResult Detalles(int codigo)
        {
            var usuarios = _UsuariosRepositorio.GetUsuariosPorCodigo(codigo);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }
    }
}
