using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entOrdenPedido
    {
        public int idOrdenPedido { get; set; }
        public string codOrdenPedido { get; set; }
        public int? idOrdenTrabajo { get; set; }      
        public DateTime fecOrdenPedido { get; set; }
        public string estadoPedido { get; set; }   
        public string observacion { get; set; }
        public Boolean estOrdenPedido { get; set; } 
        public List<entDetalleOrdenPedido> detalle { get; set; }

        public entOrdenPedido()
        {
            detalle = new List<entDetalleOrdenPedido>();
            estOrdenPedido = true;
        }
    }
}
