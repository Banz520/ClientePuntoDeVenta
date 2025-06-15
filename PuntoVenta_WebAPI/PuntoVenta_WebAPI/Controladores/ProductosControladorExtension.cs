using PuntoVenta_WebAPI.Modelos;

namespace PuntoVenta_WebAPI.Controladores
{
    public class ProductosControladorExtension
    {
        public static List<Producto> ObtenerProductos() => ProductosControlador.Productos;

    }
}
