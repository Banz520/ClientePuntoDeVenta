using Microsoft.AspNetCore.Mvc;
using PuntoVenta_WebAPI.Modelos;

namespace PuntoVenta_WebAPI.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasControlador:ControllerBase
    {
        // Lista estática para almacenar las ventas realizadas
        private static List<Venta> Ventas = new List<Venta>();

        // Acceso a la lista de productos desde ProductosController
        private static List<Producto> Productos => ProductosControladorExtension.ObtenerProductos();


        // POST: api/ventas
        // Registra una venta y actualiza el inventario
        [HttpPost]
        public ActionResult RegistrarVenta([FromBody] Venta venta)
        {
            venta.Id = Ventas.Count + 1;
            venta.Fecha = DateTime.Now;

            foreach (var detalle in venta.Detalles)
            {
                var producto = Productos.FirstOrDefault(p => p.Id == detalle.ProductoId);
                if (producto != null && producto.Cantidad >= detalle.Cantidad)
                {
                    producto.Cantidad -= detalle.Cantidad;
                }
                else
                {
                    return BadRequest($"Producto {detalle.ProductoId} no disponible en cantidad suficiente.");
                }
            }

            Ventas.Add(venta);
            return Ok(venta);
        }
    }
}
