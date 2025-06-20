using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using ClientePuntoDeVenta.Modelos;

public class InventarioViewModel : INotifyPropertyChanged
{
    private readonly InventarioCliente _servicio;
    public ObservableCollection<ProductoDto> Productos { get; set; } = new();

    /// <summary> GET productos </summary>
    public InventarioViewModel()
    {
        _servicio = new InventarioCliente();
        _ = CargarProductosAsync();
    }

    public async Task CargarProductosAsync()
    {
        var productos = await _servicio.ObtenerProductosAsync();
        Productos.Clear();
        foreach (var producto in productos)
            Productos.Add(producto);
    }

    /// <summary>
    /// Elimina un producto por su ID y actualiza la lista. DELETE productos
    /// </summary>
    public async Task EliminarProductoAsync(ProductoDto producto)
    {
        if (producto == null) return;
        var result = MessageBox.Show($"¿Seguro que deseas eliminar '{producto.Nombre}'?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (result == MessageBoxResult.Yes)
        {
            await _servicio.EliminarProductoAsync(producto.Id);
            Productos.Remove(producto);
        }
    }

    // Implementa INotifyPropertyChanged para el data binding
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
}
