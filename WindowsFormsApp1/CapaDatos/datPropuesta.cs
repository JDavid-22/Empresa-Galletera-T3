using Capa_entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class datPropuesta
    {
        #region singleton
        private static readonly datPropuesta _instancia = new datPropuesta();
        public static datPropuesta Instancia
        {
            get { return datPropuesta._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entPropuesta> ListarPropuesta()
        {
            SqlCommand cmd = null;
            List<entPropuesta> lista = new List<entPropuesta>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarPropuesta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entPropuesta p = new entPropuesta();
                    p.PropuestasDeAccionesPreventivasID = Convert.ToInt32(dr["PropuestasDeAccionesPreventivasID"]);
                    p.insumos_para_reparacion = dr["insumos_para_reparacion"].ToString();
                    p.Encargado_reparacion = dr["Encargado_reparacion"].ToString();
                    p.Acciones_a_realizar = dr["Acciones_a_realizar"].ToString();
                    p.Hora_ejecucion = dr["Hora_ejecucion"].ToString();
                    p.estPropuesta = Convert.ToBoolean(dr["estPropuesta"]);
                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null) cmd.Connection.Close();
            }
            return lista;
        }

        public Boolean InsertarPropuesta(entPropuesta p)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarPropuesta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@insumos_para_reparacion", p.insumos_para_reparacion);
                cmd.Parameters.AddWithValue("@Encargado_reparacion", p.Encargado_reparacion);
                cmd.Parameters.AddWithValue("@Acciones_a_realizar", p.Acciones_a_realizar);
                cmd.Parameters.AddWithValue("@Hora_ejecucion", p.Hora_ejecucion);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) inserta = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null) cmd.Connection.Close();
            }
            return inserta;
        }

        public Boolean EditarPropuesta(entPropuesta p)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarPropuesta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PropuestasDeAccionesPreventivasID", p.PropuestasDeAccionesPreventivasID);
                cmd.Parameters.AddWithValue("@insumos_para_reparacion", p.insumos_para_reparacion);
                cmd.Parameters.AddWithValue("@Encargado_reparacion", p.Encargado_reparacion);
                cmd.Parameters.AddWithValue("@Acciones_a_realizar", p.Acciones_a_realizar);
                cmd.Parameters.AddWithValue("@Hora_ejecucion", p.Hora_ejecucion);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) edita = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null) cmd.Connection.Close();
            }
            return edita;
        }

        public Boolean DeshabilitarPropuesta(entPropuesta p)
        {
            SqlCommand cmd = null;
            Boolean delete = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDeshabilitarPropuesta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PropuestasDeAccionesPreventivasID", p.PropuestasDeAccionesPreventivasID);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) delete = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null) cmd.Connection.Close();
            }
            return delete;
        }
        #endregion metodos
    }
}