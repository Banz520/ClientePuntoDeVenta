using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientePuntoDeVenta.Vistas;

namespace ClientePuntoDeVenta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AbrirProductos_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new ProductosView();
            ventana.Show();
        }

        private void AbrirVentas_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new VentasView();
            ventana.Show();
        }

        private void AbrirInventario_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new InventarioView();
            ventana.Show();
        }

        /*
        private void AbrirSincronizacion_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new SincronizacionView();
            ventana.Show();
        }
        */
    }
}