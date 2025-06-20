using System.Windows;
using ClientePuntoDeVenta.Vistas;

namespace ClientePuntoDeVenta
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            var productosWindow = new ProductosView();
            productosWindow.ShowDialog();
        }

        private void BtnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new Vistas.AgregarProductoView();
            ventana.ShowDialog();
        }

        private void BtnRegistrarVenta_Click(object sender, RoutedEventArgs e)
        {
            //cambiar a la vista de registrar venta
            var ventana = new Vistas.AgregarProductoView();
            ventana.ShowDialog();
        }

        private void BtnVerInventario_Click(object sender, RoutedEventArgs e)
        {
            var inventarioWindow = new InventarioView();
            inventarioWindow.ShowDialog();
        }
    }
}
