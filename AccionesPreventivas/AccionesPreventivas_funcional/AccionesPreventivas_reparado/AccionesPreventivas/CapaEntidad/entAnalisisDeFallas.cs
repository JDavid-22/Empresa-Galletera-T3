using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entAnalisisDeFallas
    {
        public int AnalisisDeFallasID { get; set; }
        public int EquipoID { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
