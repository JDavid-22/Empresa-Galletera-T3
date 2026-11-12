using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entObservacionesDeAjustes
    {
        public int ObservacionesDeAjustesID { get; set; }
        public int? PlanDeMantenimientoID { get; set; }
        public DateTime? Fecha { get; set; }
        public string Observacion { get; set; }
    }
}
