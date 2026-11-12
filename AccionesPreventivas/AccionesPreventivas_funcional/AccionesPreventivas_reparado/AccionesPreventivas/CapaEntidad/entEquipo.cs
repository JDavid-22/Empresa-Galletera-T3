using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entEquipo
    {
        public int EquipoID { get; set; }
        public int CatalogoDeComponentesID { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
    }
}
