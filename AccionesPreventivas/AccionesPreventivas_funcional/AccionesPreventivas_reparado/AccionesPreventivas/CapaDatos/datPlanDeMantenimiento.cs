using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;


namespace CapaDatos
{
    public class datPlanDeMantenimiento
    {
        #region Singleton

        private static readonly datPlanDeMantenimiento _instancia =
            new datPlanDeMantenimiento();

        public static datPlanDeMantenimiento Instancia
        {
            get { return _instancia; }
        }

        #endregion

        #region Metodos

        // LISTAR PLANES
        public List<entPlanDeMantenimiento> ListarPlanDeMantenimiento()
        {
            SqlCommand cmd = null;
            List<entPlanDeMantenimiento> lista =
                new List<entPlanDeMantenimiento>();

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    cmd = new SqlCommand(
                        "spListarPlanDeMantenimiento", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            entPlanDeMantenimiento plan =
                                new entPlanDeMantenimiento();

                            plan.PlanDeMantenimientoID =
                                Convert.ToInt32(dr["PlanDeMantenimientoID"]);

                            plan.EquipoID =
                                Convert.ToInt32(dr["EquipoID"]);

                            plan.Prioridad =
                                dr["Prioridad"].ToString();

                            plan.FechaInicio =
                                Convert.ToDateTime(dr["FechaInicio"]);

                            plan.FechaFin =
                                Convert.ToDateTime(dr["FechaFin"]);

                            plan.TiempoParada =
                                dr["TiempoParada"] == DBNull.Value
                                ? (decimal?)null
                                : Convert.ToDecimal(dr["TiempoParada"]);

                            plan.Estado =
                                Convert.ToBoolean(dr["Estado"]);

                            lista.Add(plan);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Error al listar los planes: " + ex.Message);
                }
            }

            return lista;
        }

        // INSERTAR PLAN
        public Boolean InsertarPlanDeMantenimiento(
            entPlanDeMantenimiento plan)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "spInsertarPlanDeMantenimiento", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@PlanDeMantenimientoID",
                        plan.PlanDeMantenimientoID);

                    cmd.Parameters.AddWithValue(
                        "@EquipoID", plan.EquipoID);

                    cmd.Parameters.AddWithValue(
                        "@Prioridad", plan.Prioridad);

                    cmd.Parameters.AddWithValue(
                        "@FechaInicio", plan.FechaInicio);

                    cmd.Parameters.AddWithValue(
                        "@FechaFin", plan.FechaFin);

                    SqlParameter pTiempo = cmd.Parameters.Add("@TiempoParada", SqlDbType.Decimal);
                    pTiempo.Precision = 6;
                    pTiempo.Scale = 2;
                    pTiempo.Value =
                        plan.TiempoParada.HasValue
                        ? (object)plan.TiempoParada.Value
                        : DBNull.Value;

                    cmd.Parameters.AddWithValue(
                        "@Estado", plan.Estado);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Error al insertar el plan: " + ex.Message);
                }
            }
        }

        // EDITAR PLAN
        public Boolean EditarPlanDeMantenimiento(
            entPlanDeMantenimiento plan)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "spEditarPlanDeMantenimiento", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@PlanDeMantenimientoID",
                        plan.PlanDeMantenimientoID);

                    cmd.Parameters.AddWithValue(
                        "@EquipoID", plan.EquipoID);

                    cmd.Parameters.AddWithValue(
                        "@Prioridad", plan.Prioridad);

                    cmd.Parameters.AddWithValue(
                        "@FechaInicio", plan.FechaInicio);

                    cmd.Parameters.AddWithValue(
                        "@FechaFin", plan.FechaFin);

                    SqlParameter pTiempo = cmd.Parameters.Add("@TiempoParada", SqlDbType.Decimal);
                    pTiempo.Precision = 6;
                    pTiempo.Scale = 2;
                    pTiempo.Value =
                        plan.TiempoParada.HasValue
                        ? (object)plan.TiempoParada.Value
                        : DBNull.Value;

                    cmd.Parameters.AddWithValue(
                        "@Estado", plan.Estado);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Error al editar el plan: " + ex.Message);
                }
            }
        }

        // INHABILITAR PLAN
        public Boolean DeshabilitarPlanDeMantenimiento(
            entPlanDeMantenimiento plan)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "spDeshabilitarPlanDeMantenimiento", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@PlanDeMantenimientoID",
                        plan.PlanDeMantenimientoID);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "Error al inhabilitar el plan: " + ex.Message);
                }
            }
        }

        #endregion
    }
}

