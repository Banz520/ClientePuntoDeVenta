using System;
using System.Collections.Generic;

namespace ClientePuntoDeVenta.Modelos
{
    public class VentaDto
    {
        
        public List<VentaDetalleDto> Detalles { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class VentaDetalleDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
