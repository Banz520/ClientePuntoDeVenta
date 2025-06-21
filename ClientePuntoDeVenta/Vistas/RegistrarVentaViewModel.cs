using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;
using ClientePuntoDeVenta.Modelos;
using System.Text.Json;
using System.Net.Http;
using System.Net;

namespace ClientePuntoDeVenta.Vistas
{
    public class RegistrarVentaViewModel : INotifyPropertyChanged
    {
        private readonly InventarioCliente _servicio = new();
        private int _productoId;
        private string _nombreProducto;
        private int _cantidadVendida;

        public int ProductoId
        {
            get => _productoId;
            set { _productoId = value; OnPropertyChanged(); }
        }

        public string NombreProducto
        {
            get => _nombreProducto;
            set { _nombreProducto = value; OnPropertyChanged(); }
        }

        public int CantidadVendida
        {
            get => _cantidadVendida;
            set { _cantidadVendida = value; OnPropertyChanged(); }
        }

        public async Task RegistrarVentaAsync()
        {
            if (ProductoId <= 0 || CantidadVendida <= 0)
            {
                MessageBox.Show("Por favor, ingresa un ID de producto y una cantidad v�lida.",
                               "Datos incompletos",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                return;
            }

            var venta = new VentaDto
            {
                Detalles = new List<VentaDetalleDto>
        {
            new VentaDetalleDto
            {
                ProductoId = this.ProductoId,
                Cantidad = this.CantidadVendida
            }
        },
                Fecha = DateTime.Now
            };

            try
            {
                // Versi�n modificada para manejar la respuesta
                var response = await _servicio.RegistrarVentaAsync(venta);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Venta registrada correctamente.",
                                  "�xito",
                                  MessageBoxButton.OK,
                                  MessageBoxImage.Information);

                    ProductoId = 0;
                    NombreProducto = string.Empty;
                    CantidadVendida = 0;
                }
            }
            catch (HttpRequestException httpEx)
            {
                string errorMessage = httpEx.StatusCode switch
                {
                    HttpStatusCode.BadRequest => "Datos de venta inv�lidos. Verifica los detalles.",
                    HttpStatusCode.NotFound => "Producto no encontrado en el inventario.",
                    _ => $"Error al comunicarse con el servidor: {httpEx.Message}"
                };

                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}",
                              "Error",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }

        private async Task<string> ObtenerDetallesErrorAsync(HttpRequestException ex)
        {
            // Si tu servicio devuelve detalles de error en el contenido de la respuesta
            // puedes implementar aqu� la l�gica para extraerlos
            // Ejemplo simplificado:
            return ex.Message;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}