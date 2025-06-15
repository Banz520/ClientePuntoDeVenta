namespace PuntoVenta_WebAPI.Modelos
{
    public class Venta
    {
       
        public int Id { get; set; }
        public List<VentaDetalle> Detalles { get; set; }
        public DateTime Fecha { get; set; }
    }
}
