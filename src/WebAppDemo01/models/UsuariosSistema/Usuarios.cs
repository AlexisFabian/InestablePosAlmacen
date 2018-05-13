using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class Usuarios
    {
        [Key]
        public int CodigoUsuario { get; set; }
        public int CodigoArea { get; set; }
        public int CodigoNivel { get; set; }
        public string NombreUsuarios { get; set; }
        public string ApellidoUsuarios { get; set; }
        public string Carago { get; set; }
        public string Clave { get; set; }
        public string FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public string Acceso { get; set; }
        public virtual AreasTrabajo AreasTrabajo { get; set; }

    }
}
