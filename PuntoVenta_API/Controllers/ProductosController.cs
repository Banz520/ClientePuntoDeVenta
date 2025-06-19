using Microsoft.AspNetCore.Mvc;
using PuntoVenta_API.Models;
using System.Collections.Generic;
using System.Linq;

// Decorador que indica que esta clase es un controlador API
// y manejará solicitudes HTTP con respuestas en formato JSON/XML
[ApiController]
// Establece la ruta base para todos los endpoints en este controlador
// [controller] será reemplazado por "Productos" (nombre del controlador sin sufijo)
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    // Lista estática en memoria que simula una base de datos temporal
    // En una aplicación real, esto sería reemplazado por un contexto de base de datos
    private static List<Producto> Productos = new List<Producto>
    {
        // Datos de ejemplo iniciales
        new Producto { Id = 1, Nombre = "Producto 1", Cantidad = 50, Precio = 10.0m },
        new Producto { Id = 2, Nombre = "Producto 2", Cantidad = 30, Precio = 15.0m }
    };

    // GET: api/productos
    // Obtiene todos los productos disponibles
    [HttpGet]
    public IEnumerable<Producto> Get()
    {
        // Retorna la lista completa de productos
        // El código de estado HTTP 200 (OK) es implícito
        return Productos;
    }

    // GET: api/productos/{id}
    // Obtiene un producto específico por su ID
    [HttpGet("{id}")]
    public ActionResult<Producto> Get(int id)
    {
        // Busca el producto por ID
        var producto = Productos.FirstOrDefault(p => p.Id == id);

        // Si no se encuentra, retorna 404 Not Found
        if (producto == null) return NotFound();

        // Si se encuentra, retorna el producto con código 200 OK
        return producto;
    }

    // POST: api/productos
    // Crea un nuevo producto
    [HttpPost]
    public ActionResult<Producto> Post([FromBody] Producto producto)
    {
        // Asigna un nuevo ID (en producción usaría ID generado por BD)
        producto.Id = Productos.Count + 1;

        // Agrega el producto a la lista
        Productos.Add(producto);

        // Retorna el producto creado con código 201 Created
        // Incluye la ubicación del nuevo recurso en los headers
        return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
    }

    // PUT: api/productos/{id}
    // Actualiza completamente un producto existente
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Producto producto)
    {
        // Busca el producto existente
        var existing = Productos.FirstOrDefault(p => p.Id == id);

        // Si no existe, retorna 404 Not Found
        if (existing == null) return NotFound();

        // Actualiza las propiedades del producto
        existing.Nombre = producto.Nombre;
        existing.Cantidad = producto.Cantidad;
        existing.Precio = producto.Precio;

        // Retorna 204 No Content (éxito sin contenido en la respuesta)
        return NoContent();
    }

    // DELETE: api/productos/{id}
    // Elimina un producto existente
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        // Busca el producto
        var producto = Productos.FirstOrDefault(p => p.Id == id);

        // Si no existe, retorna 404 Not Found
        if (producto == null) return NotFound();

        // Elimina el producto
        Productos.Remove(producto);

        // Retorna 204 No Content
        return NoContent();
    }
}