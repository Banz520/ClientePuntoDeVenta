using System.Windows;

namespace ClientePuntoDeVenta.Vistas
{
    /// <summary>
    /// Lógica de interacción para AgregarProductoView.xaml
    /// </summary>
    public partial class AgregarProductoView : Window
    {
        private readonly AgregarProductoViewModel _viewModel = new();

        public AgregarProductoView()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private async void AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.AgregarProductoAsync();
        }
        private void MinimizarVentana_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void CerrarVentana_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
