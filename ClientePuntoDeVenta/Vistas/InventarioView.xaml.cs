using System.Windows;
using System.Windows.Controls;
using ClientePuntoDeVenta.Modelos;

namespace ClientePuntoDeVenta.Vistas
{
    public partial class InventarioView : Window
    {
        public InventarioView()
        {
            InitializeComponent();
            DataContext = new InventarioViewModel();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Evento para eliminar producto
        private async void EliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is ProductoDto producto)
            {
                if (DataContext is InventarioViewModel vm)
                {
                    await vm.EliminarProductoAsync(producto);
                }
            }
        }
    }
}
