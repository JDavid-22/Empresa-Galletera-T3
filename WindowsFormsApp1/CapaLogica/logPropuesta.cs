using Capa_entidad;
using CapaDatos;
using System.Collections.Generic;

namespace CapaLogica
{
    public class logPropuesta
    {
        #region singleton
        private static readonly logPropuesta _instancia = new logPropuesta();
        public static logPropuesta Instancia
        {
            get { return logPropuesta._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entPropuesta> ListarPropuesta()
        {
            return datPropuesta.Instancia.ListarPropuesta();
        }

        public void InsertaPropuesta(entPropuesta p)
        {
            datPropuesta.Instancia.InsertarPropuesta(p);
        }

        public void EditaPropuesta(entPropuesta p)
        {
            datPropuesta.Instancia.EditarPropuesta(p);
        }

        public void DeshabilitarPropuesta(entPropuesta p)
        {
            datPropuesta.Instancia.DeshabilitarPropuesta(p);
        }
        #endregion metodos
    }
}