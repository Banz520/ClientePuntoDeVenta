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
    }
}
