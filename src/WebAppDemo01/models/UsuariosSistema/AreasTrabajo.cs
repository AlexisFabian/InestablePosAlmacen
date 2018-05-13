using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models

{
    public class AreasTrabajo
    {
        [Key]
        public int CodigoArea { get; set; }
        public string NombreArea { get; set; }
        public string JefeArea { get; set; }
        public string DescripcionArea { get; set; }
        public List<Usuarios> Usuarios { get; set; }
    }
}
