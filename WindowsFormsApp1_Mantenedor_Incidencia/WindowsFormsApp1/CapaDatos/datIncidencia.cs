using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaIdentidad;

namespace CapaDatos
{
    // Capa de Datos: es la unica capa que habla con SQL Server (usa procedimientos almacenados)
    public class datIncidencia
    {
        #region singleton
        private static readonly datIncidencia _instancia = new datIncidencia();

        public static datIncidencia Instancia
        {
            get { return datIncidencia._instancia; }
        }
        #endregion singleton

        #region metodos

        //////////////////// Listado de incidencias habilitadas
        public List<entIncidencia> ListarIncidencia()
        {
            List<entIncidencia> lista = new List<entIncidencia>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spListarIncidencia", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entIncidencia inc = new entIncidencia();
                        inc.incidenciaID = Convert.ToInt32(dr["IncidenciaID"]);
                        inc.codigo = dr["codigo"].ToString();
                        inc.valor_observado = Convert.ToDecimal(dr["valor_observado"]);
                        inc.nivel_gravedad = dr["nivel_gravedad"].ToString();
                        inc.fecha_hora = Convert.ToDateTime(dr["fecha_hora"]);
                        inc.observacion = dr["observacion"] == DBNull.Value ? "" : dr["observacion"].ToString();
                        inc.estIncidencia = Convert.ToBoolean(dr["estIncidencia"]);
                        lista.Add(inc);
                    }
                }
            }
            return lista;
        }

        //////////////////// Inserta una incidencia (el codigo lo genera el procedimiento)
        public Boolean InsertarIncidencia(entIncidencia inc)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spInsertarIncidencia", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@valor_observado", inc.valor_observado);
                cmd.Parameters.AddWithValue("@nivel_gravedad", inc.nivel_gravedad);
                cmd.Parameters.AddWithValue("@fecha_hora", inc.fecha_hora);
                cmd.Parameters.AddWithValue("@observacion", string.IsNullOrWhiteSpace(inc.observacion) ? (object)DBNull.Value : inc.observacion);
                cmd.Parameters.AddWithValue("@estIncidencia", inc.estIncidencia);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //////////////////// Edita una incidencia (no cambia ni el codigo ni la fecha de registro)
        public Boolean EditarIncidencia(entIncidencia inc)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spEditarIncidencia", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IncidenciaID", inc.incidenciaID);
                cmd.Parameters.AddWithValue("@valor_observado", inc.valor_observado);
                cmd.Parameters.AddWithValue("@nivel_gravedad", inc.nivel_gravedad);
                cmd.Parameters.AddWithValue("@observacion", string.IsNullOrWhiteSpace(inc.observacion) ? (object)DBNull.Value : inc.observacion);
                cmd.Parameters.AddWithValue("@estIncidencia", inc.estIncidencia);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //////////////////// Deshabilita (borrado logico, no elimina la fila)
        public Boolean DeshabilitarIncidencia(entIncidencia inc)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spDeshabilitarIncidencia", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IncidenciaID", inc.incidenciaID);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        #endregion metodos
    }
}
