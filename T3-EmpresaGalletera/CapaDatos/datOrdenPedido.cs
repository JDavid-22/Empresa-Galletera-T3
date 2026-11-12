using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class datOrdenPedido
    {
        #region singleton
        private static readonly datOrdenPedido _instancia = new datOrdenPedido();
        public static datOrdenPedido Instancia
        {
            get { return datOrdenPedido._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<entOrdenPedido> ListarOrdenPedido()
        {
            SqlCommand cmd = null;
            List<entOrdenPedido> lista = new List<entOrdenPedido>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarOrdenPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entOrdenPedido o = new entOrdenPedido();
                    o.idOrdenPedido = Convert.ToInt32(dr["idOrdenPedido"]);
                    o.codOrdenPedido = dr["codOrdenPedido"].ToString();
                    if (dr["idOrdenTrabajo"] != DBNull.Value)
                        o.idOrdenTrabajo = Convert.ToInt32(dr["idOrdenTrabajo"]);
                    o.fecOrdenPedido = Convert.ToDateTime(dr["fecOrdenPedido"]);
                    o.estadoPedido = dr["estadoPedido"].ToString();
                    o.observacion = dr["observacion"] == DBNull.Value ? null : dr["observacion"].ToString();
                    o.estOrdenPedido = Convert.ToBoolean(dr["estOrdenPedido"]);
                    lista.Add(o);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Connection.Close();
            }
            return lista;
        }

        public List<entDetalleOrdenPedido> ListarDetalleOrdenPedido(int idOrdenPedido)
        {
            SqlCommand cmd = null;
            List<entDetalleOrdenPedido> lista = new List<entDetalleOrdenPedido>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarDetalleOrdenPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idOrdenPedido", idOrdenPedido);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entDetalleOrdenPedido d = new entDetalleOrdenPedido();
                    d.idDetalle = Convert.ToInt32(dr["idDetalle"]);
                    d.idOrdenPedido = Convert.ToInt32(dr["idOrdenPedido"]);
                    d.idComponente = Convert.ToInt32(dr["idComponente"]);
                    d.nomComponente = dr["nomComponente"].ToString();
                    d.cantidad = Convert.ToInt32(dr["cantidad"]);
                    lista.Add(d);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Connection.Close();
            }
            return lista;
        }

        public string SiguienteCodigoOrdenPedido()
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spSiguienteCodigoOrdenPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Connection.Close();
            }
        }

        public Boolean InsertarOrdenPedido(entOrdenPedido o)
        {
            SqlConnection cn = null;
            SqlTransaction tx = null;
            Boolean inserta = false;
            try
            {
                cn = Conexion.Instancia.Conectar();
                cn.Open();
                tx = cn.BeginTransaction();

                SqlCommand cmd = new SqlCommand("spInsertarOrdenPedido", cn, tx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codOrdenPedido", o.codOrdenPedido);
                cmd.Parameters.AddWithValue("@idOrdenTrabajo", (object)o.idOrdenTrabajo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fecOrdenPedido", o.fecOrdenPedido);
                cmd.Parameters.AddWithValue("@estadoPedido", o.estadoPedido);
                cmd.Parameters.AddWithValue("@observacion", (object)o.observacion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@estOrdenPedido", o.estOrdenPedido);
                o.idOrdenPedido = Convert.ToInt32(cmd.ExecuteScalar());

                InsertarDetalle(cn, tx, o);

                tx.Commit();
                inserta = o.idOrdenPedido > 0;
            }
            catch (Exception e)
            {
                if (tx != null) tx.Rollback();
                throw e;
            }
            finally
            {
                if (cn != null) cn.Close();
            }
            return inserta;
        }

        private void InsertarDetalle(SqlConnection cn, SqlTransaction tx, entOrdenPedido o)
        {
            foreach (entDetalleOrdenPedido d in o.detalle)
            {
                SqlCommand cmd = new SqlCommand("spInsertarDetalleOrdenPedido", cn, tx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idOrdenPedido", o.idOrdenPedido);
                cmd.Parameters.AddWithValue("@idComponente", d.idComponente);
                cmd.Parameters.AddWithValue("@cantidad", d.cantidad);
                cmd.ExecuteNonQuery();
            }
        }

        public Boolean EditarOrdenPedido(entOrdenPedido o, Boolean reemplazarDetalle)
        {
            SqlConnection cn = null;
            SqlTransaction tx = null;
            Boolean edita = false;
            try
            {
                cn = Conexion.Instancia.Conectar();
                cn.Open();
                tx = cn.BeginTransaction();

                SqlCommand cmd = new SqlCommand("spEditarOrdenPedido", cn, tx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idOrdenPedido", o.idOrdenPedido);
                cmd.Parameters.AddWithValue("@estadoPedido", o.estadoPedido);
                cmd.Parameters.AddWithValue("@observacion", (object)o.observacion ?? DBNull.Value);
                int i = cmd.ExecuteNonQuery();

                if (reemplazarDetalle)
                {
                    SqlCommand del = new SqlCommand("spLimpiarDetalleOrdenPedido", cn, tx);
                    del.CommandType = CommandType.StoredProcedure;
                    del.Parameters.AddWithValue("@idOrdenPedido", o.idOrdenPedido);
                    del.ExecuteNonQuery();

                    InsertarDetalle(cn, tx, o);
                }

                tx.Commit();
                if (i > 0)
                {
                    edita = true;
                }
            }
            catch (Exception e)
            {
                if (tx != null) tx.Rollback();
                throw e;
            }
            finally
            {
                if (cn != null) cn.Close();
            }
            return edita;
        }

        public Boolean DeshabilitarOrdenPedido(entOrdenPedido o)
        {
            SqlCommand cmd = null;
            Boolean delete = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDeshabilitarOrdenPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idOrdenPedido", o.idOrdenPedido);
                cmd.Parameters.AddWithValue("@estOrdenPedido", o.estOrdenPedido);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    delete = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Connection.Close();
            }
            return delete;
        }

        #endregion metodos
    }
}
