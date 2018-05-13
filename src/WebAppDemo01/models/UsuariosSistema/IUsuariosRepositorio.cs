using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public interface IUsuariosRepositorio
    {
        IEnumerable<Usuarios> Usuarios { get; }
        IEnumerable<Usuarios> EstadoUsuarios { get; }
        Usuarios GetUsuariosPorCodigo(int CodigoUsuario);
    }
}
