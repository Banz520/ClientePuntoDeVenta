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

        private void MinimizarVentana_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void CerrarVentana_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new ProductosView();
            ventana.ShowDialog();
        }

        private void BtnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new Vistas.AgregarProductoView();
            ventana.ShowDialog();
        }

        private void BtnRegistrarVenta_Click(object sender, RoutedEventArgs e)
        {
            
            var ventana = new Vistas.RegistrarVentaView();
            ventana.ShowDialog();
        }

        private void BtnVerInventario_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new InventarioView();
            ventana.ShowDialog();
        }
    }
}
