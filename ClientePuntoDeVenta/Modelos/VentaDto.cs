using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientePuntoDeVenta.Modelos
{
    public class VentaDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CantidadVendida { get; set; }
        public DateTime Fecha { get; set; }
    }
}
