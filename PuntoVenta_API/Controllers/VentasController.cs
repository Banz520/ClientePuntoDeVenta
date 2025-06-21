using Microsoft.AspNetCore.Mvc;
using PuntoVenta_API.Models;
using System.Collections.Generic;



// Decorador que marca esta clase como un controlador API
[ApiController]
// Establece la ruta base para los endpoints: api/ventas
[Route("api/[controller]")]
public class VentasController : ControllerBase
{

    // Lista estática en memoria para almacenar ventas (simulación de base de datos)
    private static List<Venta> Ventas = new List<Venta>();

    // Referencia a la lista de productos (debería ser inyectada en una aplicación real)
    private readonly List<Producto> _productos;

    public VentasController(List<Producto> productos)
    {
        _productos = productos;
    }

   
    

    // POST: api/ventas
    // Registra una nueva venta y actualiza el inventario
    [HttpPost]
    public ActionResult RegistrarVenta([FromBody] Venta venta)
    {
        // Asigna un ID autoincremental a la venta
        venta.Id = Ventas.Count + 1;

        // Establece la fecha actual como fecha de venta
        venta.Fecha = DateTime.Now;

        // Procesa cada detalle de la venta
        foreach (var detalle in venta.Detalles)
        {
            // Busca el producto en el inventario
            var producto = _productos.FirstOrDefault(p => p.Id == detalle.ProductoId);

            // Verifica disponibilidad
            if (producto != null && producto.Cantidad >= detalle.Cantidad)
            {
                // Reduce el stock del producto
                producto.Cantidad -= detalle.Cantidad;
            }
            else
            {
                // Si no hay suficiente stock, retorna error 400 Bad Request
                return BadRequest($"Producto {detalle.ProductoId} no disponible en cantidad suficiente.");
            }
        }

        // Agrega la venta a la lista
        Ventas.Add(venta);

        // Retorna la venta creada con código 200 OK
        return Ok(venta);
    }
}