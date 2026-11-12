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
    public class datComponente
    {
        #region singleton
        private static readonly datComponente _instancia = new datComponente();
        public static datComponente Instancia
        {
            get { return datComponente._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entComponente> ListarComponente()
        {
            SqlCommand cmd = null;
            List<entComponente> lista = new List<entComponente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarComponente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entComponente c = new entComponente();
                    c.idComponente = Convert.ToInt32(dr["idComponente"]);
                    c.codComponente = dr["codComponente"].ToString();
                    c.nomComponente = dr["nomComponente"].ToString();
                    c.stockComponente = Convert.ToInt32(dr["stockComponente"]);
                    c.estComponente = Convert.ToBoolean(dr["estComponente"]);
                    lista.Add(c);
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
        #endregion metodos
    }
}
