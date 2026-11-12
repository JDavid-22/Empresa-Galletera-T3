using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private static readonly Conexion _instancia = new Conexion();

        public static Conexion Instancia
        {
            get { return _instancia; }
        }

        public SqlConnection Conectar()
        {

            string cadena = "Data Source=DESKTOP-G5D8KHE;Initial Catalog=AccionesPreventivas;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }
    }
}
