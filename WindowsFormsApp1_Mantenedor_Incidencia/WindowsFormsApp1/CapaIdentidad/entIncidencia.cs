using System;

namespace CapaIdentidad
{
    // Capa de Identidad (Entidad): representa una fila de la tabla Incidencia
    public class entIncidencia
    {
        public int incidenciaID { get; set; }
        public string codigo { get; set; }
        public decimal valor_observado { get; set; }
        public string nivel_gravedad { get; set; }
        public DateTime fecha_hora { get; set; }
        public string observacion { get; set; }
        public bool estIncidencia { get; set; }  
    }
}
