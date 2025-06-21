using Microsoft.AspNetCore.Mvc;
using PuntoVenta_API.Models;
using System.Collections.Generic;
using System.Linq;

// Decorador que marca esta clase como un controlador API
[ApiController]
// Establece la ruta base para los endpoints: api/ventas
[Route("api/[controller]")]
public class VentasController : ControllerBase
{
    // Lista estática en memoria para almacenar ventas (simulación de base de datos)
    private static List<Venta> Ventas = new List<Venta>();

    // Usamos la misma lista de productos que ProductosController
    // En una aplicación real, esto debería ser un servicio inyectado o acceso a base de datos
    private static List<Producto> _productos = ProductosController.Productos;

    public VentasController()
    {
        // Constructor vacío ya que usamos las listas estáticas
        // En producción, aquí se inyectarían servicios necesarios
    }

    // POST: api/ventas
    // Registra una nueva venta y actualiza el inventario
    [HttpPost]
    public ActionResult RegistrarVenta([FromBody] Venta venta)
    {
        // Validación básica del modelo recibido
        if (venta == null || venta.Detalles == null || !venta.Detalles.Any())
        {
            return BadRequest("La venta debe contener al menos un detalle");
        }

        // Asigna un ID autoincremental a la venta
        venta.Id = Ventas.Count + 1;

        // Establece la fecha actual como fecha de venta (sobrescribe cualquier fecha enviada)
        venta.Fecha = DateTime.Now;

        // Procesa cada detalle de la venta
        foreach (var detalle in venta.Detalles)
        {
            // Busca el producto en el inventario
            var producto = _productos.FirstOrDefault(p => p.Id == detalle.ProductoId);

            // Verifica si el producto existe y tiene suficiente stock
            if (producto == null)
            {
                return BadRequest($"Producto con ID {detalle.ProductoId} no encontrado en el inventario.");
            }

            if (producto.Cantidad < detalle.Cantidad)
            {
                return BadRequest($"Stock insuficiente para el producto {producto.Nombre}. Stock actual: {producto.Cantidad}, solicitado: {detalle.Cantidad}");
            }

            // Reduce el stock del producto
            producto.Cantidad -= detalle.Cantidad;
        }

        // Agrega la venta a la lista
        Ventas.Add(venta);

        // Retorna la venta creada con código 200 OK
        return Ok(new
        {
            Mensaje = "Venta registrada exitosamente",
            Venta = venta,
            ProductosActualizados = _productos.Where(p => venta.Detalles.Any(d => d.ProductoId == p.Id))
        });
    }

    // GET: api/ventas
    // Endpoint adicional para obtener todas las ventas (útil para pruebas)
    [HttpGet]
    public ActionResult<IEnumerable<Venta>> Get()
    {
        return Ok(Ventas);
    }
}