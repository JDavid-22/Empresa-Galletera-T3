using System;

namespace Capa_entidad
{
    public class entPropuesta
    {
        public int PropuestasDeAccionesPreventivasID { get; set; }
        public string insumos_para_reparacion { get; set; }
        public string Encargado_reparacion { get; set; }
        public string Acciones_a_realizar { get; set; }
        public string Hora_ejecucion { get; set; }
        public bool estPropuesta { get; set; }
    }
}