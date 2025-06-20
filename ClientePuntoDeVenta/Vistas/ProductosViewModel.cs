using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ClientePuntoDeVenta.Modelos;

namespace ClientePuntoDeVenta.Vistas
{
    /// <summary>
    /// ViewModel para la vista de productos. Consume la API para obtener la lista de productos.
    /// </summary>
    public class ProductosViewModel : INotifyPropertyChanged
    {
        private readonly InventarioCliente _servicio;
        public ObservableCollection<ProductoDto> Productos { get; set; } = new();

        public ProductosViewModel()
        {
            _servicio = new InventarioCliente();
            _ = CargarProductosAsync();
        }

        /// <summary>
        /// Carga los productos desde la API y los agrega a la colección observable.
        /// </summary>
        public async Task CargarProductosAsync()
        {
            var productos = await _servicio.ObtenerProductosAsync();
            Productos.Clear();
            foreach (var producto in productos)
                Productos.Add(producto);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
    }
}
