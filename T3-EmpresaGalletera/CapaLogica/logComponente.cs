using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logComponente
    {
        #region singleton
        private static readonly logComponente _instancia = new logComponente();
        public static logComponente Instancia
        {
            get { return logComponente._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entComponente> ListarComponente()
        {
            return datComponente.Instancia.ListarComponente();
        }
        #endregion metodos
    }
}
