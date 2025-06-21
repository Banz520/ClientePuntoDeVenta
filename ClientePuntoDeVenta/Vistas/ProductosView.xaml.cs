using System.Windows;

namespace ClientePuntoDeVenta.Vistas
{
    /// <summary>
    /// Code-behind para la vista de productos. Asigna el ViewModel como DataContext.
    /// </summary>
    public partial class ProductosView : Window
    {
        public ProductosView()
        {
            InitializeComponent();
            DataContext = new ProductosViewModel();
        }

        // Opcional: métodos para minimizar/cerrar la ventana si tienes botones personalizados
        private void MinimizarVentana_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CerrarVentana_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
