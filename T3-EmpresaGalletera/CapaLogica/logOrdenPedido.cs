using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaLogica
{
    public class logOrdenPedido
    {
        #region singleton
        private static readonly logOrdenPedido _instancia = new logOrdenPedido();
        public static logOrdenPedido Instancia
        {
            get { return logOrdenPedido._instancia; }
        }
        #endregion singleton

        public static readonly string[] Estados = { "Pendiente", "En atención", "Atendido" };

        #region metodos

        ///listado
        public List<entOrdenPedido> ListarOrdenPedido()
        {
            return datOrdenPedido.Instancia.ListarOrdenPedido();
        }

        public List<entDetalleOrdenPedido> ListarDetalleOrdenPedido(int idOrdenPedido)
        {
            return datOrdenPedido.Instancia.ListarDetalleOrdenPedido(idOrdenPedido);
        }

        public string SiguienteCodigoOrdenPedido()
        {
            return datOrdenPedido.Instancia.SiguienteCodigoOrdenPedido();
        }

        public void InsertaOrdenPedido(entOrdenPedido o)
        {
            o.estadoPedido = Estados[0];      
            o.estOrdenPedido = true;
            ValidarContenido(o);

            if (!datOrdenPedido.Instancia.InsertarOrdenPedido(o))
                throw new Exception("No se pudo registrar la orden de pedido.");
        }

        public void EditaOrdenPedido(entOrdenPedido o)
        {
            entOrdenPedido actual = ListarOrdenPedido().FirstOrDefault(x => x.idOrdenPedido == o.idOrdenPedido);
            if (actual == null)
                throw new InvalidOperationException("La orden de pedido no existe.");
            if (!actual.estOrdenPedido)
                throw new InvalidOperationException("No se puede modificar una orden inhabilitada.");

            int idxActual = Array.IndexOf(Estados, actual.estadoPedido);
            int idxNuevo = Array.IndexOf(Estados, o.estadoPedido);
            if (idxNuevo < 0)
                throw new ArgumentException("Estado no válido.");
            if (idxNuevo < idxActual)
                throw new InvalidOperationException("No se puede regresar la orden a un estado anterior.");
            if (idxNuevo > idxActual + 1)
                throw new InvalidOperationException("Debe avanzar al siguiente estado.");

            Boolean ok;
            if (actual.estadoPedido == Estados[0])
            {
                ValidarContenido(o);
                ok = datOrdenPedido.Instancia.EditarOrdenPedido(o, true);
            }
            else
            {
                o.observacion = actual.observacion;
                ok = datOrdenPedido.Instancia.EditarOrdenPedido(o, false);
            }

            if (!ok)
                throw new Exception("No se pudo actualizar la orden de pedido.");
        }

        public void DeshabilitarOrdenPedido(entOrdenPedido o)
        {
            entOrdenPedido actual = ListarOrdenPedido().FirstOrDefault(x => x.idOrdenPedido == o.idOrdenPedido);
            if (actual == null)
                throw new InvalidOperationException("La orden de pedido no existe.");
            if (actual.estadoPedido == Estados[2])
                throw new InvalidOperationException("No se puede inhabilitar una orden ya atendida.");

            o.estOrdenPedido = false;
            if (!datOrdenPedido.Instancia.DeshabilitarOrdenPedido(o))
                throw new Exception("No se pudo inhabilitar la orden de pedido.");
        }

        private void ValidarContenido(entOrdenPedido o)
        {
            if (string.IsNullOrWhiteSpace(o.codOrdenPedido))
                throw new ArgumentException("El código de la orden es obligatorio.");
            if (!string.IsNullOrEmpty(o.observacion) && o.observacion.Length > 250)
                throw new ArgumentException("La observación no puede superar 250 caracteres.");
            if (o.detalle == null || o.detalle.Count == 0)
                throw new ArgumentException("Debe agregar al menos un componente a la orden.");
            if (o.detalle.Any(d => d.cantidad <= 0))
                throw new ArgumentException("Todas las cantidades deben ser mayores a 0.");
            if (o.detalle.GroupBy(d => d.idComponente).Any(g => g.Count() > 1))
                throw new ArgumentException("Hay componentes repetidos en el detalle.");

            var componentes = logComponente.Instancia.ListarComponente();

            foreach (var d in o.detalle)
            {
                var comp = componentes.FirstOrDefault(
                    c => c.idComponente == d.idComponente);

                if (comp == null)
                    throw new InvalidOperationException(
                        "El componente no existe o está inhabilitado.");

                if (d.cantidad > comp.stockComponente)
                    throw new InvalidOperationException(
                        "Stock insuficiente para: " + d.nomComponente);
            }
        }

        #endregion metodos
    }
}
