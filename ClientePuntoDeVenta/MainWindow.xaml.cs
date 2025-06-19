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

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            var inventarioWindow = new InventarioView();
            inventarioWindow.ShowDialog();
        }
    }
}
