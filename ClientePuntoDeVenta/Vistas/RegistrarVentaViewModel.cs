using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;
using ClientePuntoDeVenta.Modelos;
using System.Text.Json;

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

        /// <summary>
        /// Envía la venta a la API en el formato correcto.
        /// </summary>
        public async Task RegistrarVentaAsync()
        {

            if (ProductoId <= 0 || CantidadVendida <= 0)
            {
                MessageBox.Show("Por favor, ingresa un ID de producto y una cantidad válida.", "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Crea la venta con la lista de detalles
            // ... dentro de RegistrarVentaAsync()
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

            // Serializa el objeto a JSON
            string json = JsonSerializer.Serialize(venta, new JsonSerializerOptions { WriteIndented = true });

            // Muestra el JSON en consola
            Console.WriteLine(json);

            // O en un MessageBox (útil en WPF)
            MessageBox.Show(json, "JSON enviado a la API");

            try
            {
                await _servicio.RegistrarVentaAsync(venta);
                MessageBox.Show("Venta registrada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                ProductoId = 0;
                NombreProducto = string.Empty;
                CantidadVendida = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
