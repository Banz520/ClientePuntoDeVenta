using System.Windows;

namespace ClientePuntoDeVenta.Vistas
{
    /// <summary>
    /// Code-behind para la ventana de registro de ventas.
    /// </summary>
    public partial class RegistrarVentaView : Window
    {
        private readonly RegistrarVentaViewModel _viewModel = new();

        public RegistrarVentaView()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private async void RegistrarVenta_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.RegistrarVentaAsync();
        }

        private void MinimizarVentana_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void CerrarVentana_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ayuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Para registrar una venta:\n\n" +
                "- El id debe corresponder a un producto existente.\n" +
                "- La cantidad debe ser un número entero mayor o igual a 0.\n\n" +
                
                "Asegúrate de ingresar datos válidos antes de hacer clic en 'Registrar Venta'.",
                "Ayuda - Registrar Venta",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
    }
}
