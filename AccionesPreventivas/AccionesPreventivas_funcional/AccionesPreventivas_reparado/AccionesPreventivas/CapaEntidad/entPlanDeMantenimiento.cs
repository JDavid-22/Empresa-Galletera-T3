using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPlanDeMantenimiento
    {
        public int PlanDeMantenimientoID { get; set; }
        public int EquipoID { get; set; }
        public string Prioridad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal? TiempoParada { get; set; }
        public bool Estado { get; set; }
    }
}
