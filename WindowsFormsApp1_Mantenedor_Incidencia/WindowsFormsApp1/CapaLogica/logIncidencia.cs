using System;
using System.Collections.Generic;
using CapaDatos;
using CapaIdentidad;

namespace CapaLogica
{
    // Capa Logica (Negocio): valida las reglas y llama a la capa de datos
    public class logIncidencia
    {
        #region singleton
        private static readonly logIncidencia _instancia = new logIncidencia();

        public static logIncidencia Instancia
        {
            get { return logIncidencia._instancia; }
        }
        #endregion singleton

        // Niveles de gravedad permitidos (RFD-02 del informe)
        public static readonly string[] NivelesGravedad = { "Leve", "Moderada", "Crítica" };

        #region metodos

        public List<entIncidencia> ListarIncidencia()
        {
            return datIncidencia.Instancia.ListarIncidencia();
        }

        public Boolean InsertaIncidencia(entIncidencia inc)
        {
            Validar(inc);
            inc.fecha_hora = DateTime.Now;   // la fecha y hora la asigna el sistema (paso B7 de la especificacion)
            inc.estIncidencia = true;
            return datIncidencia.Instancia.InsertarIncidencia(inc);
        }

        public Boolean EditaIncidencia(entIncidencia inc)
        {
            if (inc == null || inc.incidenciaID <= 0)
                throw new ArgumentException("Seleccione una incidencia para modificar.");
            Validar(inc);
            return datIncidencia.Instancia.EditarIncidencia(inc);
        }

        public Boolean DeshabilitarIncidencia(entIncidencia inc)
        {
            if (inc == null || inc.incidenciaID <= 0)
                throw new ArgumentException("Seleccione una incidencia para deshabilitar.");
            return datIncidencia.Instancia.DeshabilitarIncidencia(inc);
        }

        private void Validar(entIncidencia inc)
        {
            if (inc == null || string.IsNullOrWhiteSpace(inc.nivel_gravedad))
                throw new ArgumentException("Debe completar los datos obligatorios.");
            if (Array.IndexOf(NivelesGravedad, inc.nivel_gravedad) < 0)
                throw new ArgumentException("El nivel de gravedad debe ser Leve, Moderada o Crítica.");
            if (Math.Abs(inc.valor_observado) > 99999999.99m)
                throw new ArgumentException("El valor observado excede el rango permitido.");
            if (inc.observacion != null && inc.observacion.Length > 100)
                throw new ArgumentException("La observación no puede superar los 100 caracteres.");
        }

        #endregion metodos
    }
}
