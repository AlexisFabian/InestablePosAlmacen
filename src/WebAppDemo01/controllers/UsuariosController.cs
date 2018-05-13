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

        private readonly IAreasTrabajoRepositorio _areastrabajoRepositorio;
        private readonly IUsuariosRepositorio _usuariosRepositorio;

        //constructor de esta clase controller

    public UsuariosController(IAreasTrabajoRepositorio areastrabajoRepositorio, IUsuariosRepositorio usuariosRepositorio)
        {
            _areastrabajoRepositorio = areastrabajoRepositorio;
            _usuariosRepositorio = usuariosRepositorio;
        } //Fin del constructor

        //metodo para devolber la vista con datos iyectados
        public ViewResult ListaUsuarios()
        {
            //objetos para mostrar las categorias de los productos
            ListaUsuariosViewModel listausuariosViewModel = new ListaUsuariosViewModel();
            listausuariosViewModel.Usuarios = _usuariosRepositorio.Usuarios;

            //pasando intencionalmente un valor a la variable de la clase
            listausuariosViewModel.AreasTrabajo = "Lista de Usuarios";


            // return View(_productosRepositorio.Productos);
            return View(listausuariosViewModel);
        }//fin del metodo listaProductos
    }
}
