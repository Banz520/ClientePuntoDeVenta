using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientePuntoDeVenta.Servicios
{
    
    //Clase que permite comunicarse con el servidor Web API RESTful para obtener productos y registrar ventas.
    
    public class InventarioCliente
    {
        // Instancia de HttpClient para realizar peticiones HTTP al servidor
        private readonly HttpClient _clienteHttp;

        
        // Constructor: inicializa el cliente HTTP y establece la URL base del API.
        public InventarioCliente()
        {
            _clienteHttp = new HttpClient();

            // Cambia esta URL por la dirección real del servidor API
            _clienteHttp.BaseAddress = new Uri("http://localhost:5000/api/");
        }

        /*
        Realiza una solicitud GET a la API para obtener la lista de productos.
        Devuelve la respuesta en formato JSON como cadena.
        */

        public async Task<string> ObtenerProductosAsync()
        {
            // Se hace la solicitud GET al endpoint /productos
            HttpResponseMessage respuesta = await _clienteHttp.GetAsync("productos");

            // Si hubo error, lanza una excepción
            respuesta.EnsureSuccessStatusCode();

            // Devuelve el contenido de la respuesta como string
            return await respuesta.Content.ReadAsStringAsync();
        }

        /*
        Envía los datos de una venta al servidor como JSON mediante POST.
        <param name="ventaJson">La venta en formato JSON</param>
        */

        public async Task EnviarVentaAsync(string ventaJson)
        {
            // Crea el contenido de la solicitud HTTP con tipo JSON
            var contenido = new StringContent(ventaJson, Encoding.UTF8, "application/json");

            // Envía la solicitud POST al endpoint /ventas
            HttpResponseMessage respuesta = await _clienteHttp.PostAsync("ventas", contenido);

            // Si hubo error, lanza una excepción
            respuesta.EnsureSuccessStatusCode();
        }
    }
}
