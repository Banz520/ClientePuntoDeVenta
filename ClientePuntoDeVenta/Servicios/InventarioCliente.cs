using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ClientePuntoDeVenta.Modelos;

public class InventarioCliente
{
    private readonly HttpClient _client;

    public InventarioCliente()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://localhost:7299/api/");
    }

    // GET /productos
    public async Task<List<ProductoDto>> ObtenerProductosAsync()
        => await _client.GetFromJsonAsync<List<ProductoDto>>("productos");

    // GET /productos/{id}
    public async Task<ProductoDto> ObtenerProductoPorIdAsync(int id)
        => await _client.GetFromJsonAsync<ProductoDto>($"productos/{id}");

    // POST /productos
    public async Task CrearProductoAsync(ProductoDto producto)
    {
        var response = await _client.PostAsJsonAsync("productos", producto);
        response.EnsureSuccessStatusCode();
    }

    // PUT /productos/{id}
    public async Task ActualizarProductoAsync(int id, ProductoDto producto)
    {
        var response = await _client.PutAsJsonAsync($"productos/{id}", producto);
        response.EnsureSuccessStatusCode();
    }

    // DELETE /productos/{id}
    public async Task EliminarProductoAsync(int id)
    {
        var response = await _client.DeleteAsync($"productos/{id}");
        response.EnsureSuccessStatusCode();
    }

    // POST /ventas
    public async Task RegistrarVentaAsync(VentaDto venta)
    {
        var response = await _client.PostAsJsonAsync("ventas", venta);
        response.EnsureSuccessStatusCode();
    }

    // GET /inventario
    public async Task<List<ProductoDto>> ObtenerInventarioAsync()
        => await _client.GetFromJsonAsync<List<ProductoDto>>("inventario");
}
