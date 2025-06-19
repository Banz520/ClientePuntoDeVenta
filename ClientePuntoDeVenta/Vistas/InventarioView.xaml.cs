using System.Windows;

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
    }
}
