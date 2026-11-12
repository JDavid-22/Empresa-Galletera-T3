using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entDetalleOrdenPedido
    {
        public int idDetalle { get; set; }
        public int idOrdenPedido { get; set; }
        public int idComponente { get; set; }
        public string nomComponente { get; set; }
        public int cantidad { get; set; }
    }
}
