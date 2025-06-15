using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientePuntoDeVenta.Modelos
{
    internal class Venta
    {
        public int Id { get; set; }
        public List<VentaDetalle> Detalles { get; set; }
        public DateTime Fecha { get; set; }
    }
}
