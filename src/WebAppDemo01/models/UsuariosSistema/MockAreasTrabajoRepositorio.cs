using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class MockAreasTrabajoRepositorio : IAreasTrabajoRepositorio
    {
        public IEnumerable<AreasTrabajo> AreasTrabajo
        {
            get
            {
                return new List<AreasTrabajo>
                {
                    new AreasTrabajo {CodigoArea = 1, NombreArea =  "Dep.Ventas", JefeArea = "El Maestro", DescripcionArea = "Departamento de Ventas"}
                };
            }//fin del get
        }//fin de ienumerable
        }
    }//fin de public class

