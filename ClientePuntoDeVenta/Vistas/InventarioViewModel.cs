using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ClientePuntoDeVenta.Modelos;

public class InventarioViewModel : INotifyPropertyChanged
{
    private readonly InventarioCliente _servicio;
    public ObservableCollection<ProductoDto> Productos { get; set; } = new();

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

    // Implementa INotifyPropertyChanged para el data binding
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
}
