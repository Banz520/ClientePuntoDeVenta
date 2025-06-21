using System;
using System.Collections.Generic;

namespace ClientePuntoDeVenta.Modelos
{
    /// <summary>
    /// Representa el detalle de una venta (producto y cantidad).
    /// </summary>
    public class VentaDetalleDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }

    /// <summary>
    /// Representa una venta para enviar a la API.
    /// </summary>
    public class VentaDto
    {
        public int Id { get; set; }
        public List<VentaDetalleDto> Detalles { get; set; }
        public DateTime Fecha { get; set; }
    }
}
