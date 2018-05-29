using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDemo01.models;

namespace WebAppDemo01.Componentes
{
    public class UO: ViewComponent
    {
        private readonly ICatUsuariosRepositorio _catUsuariosRepositorio;
        public UO(ICatUsuariosRepositorio catUsuariosRepositorio)
        {
            _catUsuariosRepositorio = catUsuariosRepositorio;
        }//fin del constructor
        public IViewComponentResult Invoke()
        {
            var catUsaurios = _catUsuariosRepositorio.CategoriasUsuarios.OrderBy(cp => cp.NombreCatUo);
            return View(catUsaurios);
        }
    }
}
