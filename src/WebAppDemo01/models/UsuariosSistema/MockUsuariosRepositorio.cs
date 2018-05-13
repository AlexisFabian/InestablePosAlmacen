using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class MockUsuariosRepositorio: IUsuariosRepositorio
    {
        private readonly IAreasTrabajoRepositorio _AreasTrabajoRepositorio = new MockAreasTrabajoRepositorio();

        public IEnumerable<Usuarios> Usuarios
        {
            get
            {
                return new List<Usuarios>
                {
                    new Usuarios {CodigoUsuario = 1, CodigoArea = 1, CodigoNivel = 1, NombreUsuarios = "Don Bolsi", ApellidoUsuarios = "Carrero Welmir", Carago = "Vendedor", Clave = "abc123", FechaCreacion= "11/03/2018", Estado = true, Acceso = "Bajo" },
                    new Usuarios {CodigoUsuario = 2, CodigoArea = 1, CodigoNivel = 1, NombreUsuarios = "Juan", ApellidoUsuarios = "Alas", Carago = "Servicio Cliente", Clave = "abc123", FechaCreacion= "11/03/2018", Estado = true, Acceso = "Bajo" },

                };
            }//fin del get
        }//fin de IEnumerable Productos

        public IEnumerable<Usuarios> EstadoUsuarios { get; }
        public Usuarios GetUsuariosPorCodigo(int CodigoUsuario)
        {
            throw new System.NotImplementedException();
        }
    }//fin de public class
}
