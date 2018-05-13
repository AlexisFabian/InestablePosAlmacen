using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public UsuariosRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Usuarios> Usuarios
        {
            get
            {
                return _appDbContext.Usuarios.Include(c => c.AreasTrabajo);
            }
        }

        public IEnumerable<Usuarios> EstadoUsuarios
        {
            get
            {
                return _appDbContext.Usuarios.Include(c => c.AreasTrabajo).Where(p => p.Estado);
            }
        }

        public Usuarios GetUsuariosPorCodigo(int CodigoUsuario)
        {
            return _appDbContext.Usuarios.FirstOrDefault(p => p.CodigoUsuario == CodigoUsuario);
        }


    }
}
