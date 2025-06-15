using Microsoft.AspNetCore.Mvc;
using PuntoVenta_WebAPI.Modelos;


namespace PuntoVenta_WebAPI.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosControlador:ControllerBase
    {
        // Lista estática que simula una base de datos en memoria
        internal static List<Producto> Productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Producto 1", Cantidad = 50, Precio = 10.0m },
            new Producto { Id = 2, Nombre = "Producto 2", Cantidad = 30, Precio = 15.0m }
        };

        // GET: api/productos
        // Devuelve la lista completa de productos
        [HttpGet]
        public IEnumerable<Producto> Get() => Productos;

        // GET: api/productos/{id}
        // Devuelve un producto específico por ID
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = Productos.FirstOrDefault(p => p.Id == id);
            return producto == null ? NotFound() : Ok(producto);
        }

        // POST: api/productos
        // Agrega un nuevo producto a la lista
        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto producto)
        {
            producto.Id = Productos.Count + 1;
            Productos.Add(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        // PUT: api/productos/{id}
        // Modifica los datos de un producto existente
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            var existing = Productos.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.Nombre = producto.Nombre;
            existing.Cantidad = producto.Cantidad;
            existing.Precio = producto.Precio;
            return NoContent();
        }

        // DELETE: api/productos/{id}
        // Elimina un producto por ID
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = Productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            Productos.Remove(producto);
            return NoContent();
        }
    }
}
