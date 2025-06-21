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

        private void Ayuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Para agregar un producto:\n\n" +
                "- El nombre no puede estar vacío ni contener números.\n" +
                "- La cantidad debe ser un número entero mayor o igual a 0.\n" +
                "- El precio debe ser un número mayor o igual a 0 (no se permiten valores negativos).\n\n" +
                "Asegúrate de ingresar datos válidos antes de hacer clic en 'Agregar Producto'.",
                "Ayuda - Agregar Producto",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }

    }
}
