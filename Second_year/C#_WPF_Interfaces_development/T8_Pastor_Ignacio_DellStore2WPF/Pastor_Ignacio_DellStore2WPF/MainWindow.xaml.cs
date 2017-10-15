using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pastor_Ignacio_DellStore2WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CapaControlador.Controlador myControlador;
        public MainWindow()
        {
            InitializeComponent();
            myControlador = new CapaControlador.Controlador();
            tbStatusInfo.Text = "Cargando componentes...";
        }

        private void Click_Clientes_Modificacion(object sender, RoutedEventArgs e)
        {
            ClienteWindow clienteWindow = new ClienteWindow(myControlador);
            clienteWindow.ShowDialog();
        }

        private void Click_Clientes_Alta(object sender, RoutedEventArgs e)
        {
            AltaModificacionCliente altaModCliente = new AltaModificacionCliente(myControlador);
            altaModCliente.ShowDialog();
        }

        private void Click_Productos_Alta(object sender, RoutedEventArgs e)
        {
            AltaModificacionProducto altaModProd = new AltaModificacionProducto(myControlador);
            altaModProd.ShowDialog();
        }

        private void Click_Productos_Modificacion(object sender, RoutedEventArgs e)
        {
            ProductoWindow productoWindow = new ProductoWindow(myControlador);
            productoWindow.ShowDialog();
        }

        private void Click_Pedidos_Alta(object sender, RoutedEventArgs e)
        {
            FacturaPedidos facturaVentana = new FacturaPedidos(myControlador);
            facturaVentana.ShowDialog();
        }

        private void Click_Pedidos_Modificacion(object sender, RoutedEventArgs e)
        {
            PedidoWindow pedidoWindow = new PedidoWindow(myControlador);
            pedidoWindow.ShowDialog();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbStatusInfo.Text = "Cargando datos de la Base de Datos...";
            try { myControlador.CargarDatosDataset(); }catch(Exception ex) { tbStatusInfo.Text = "Error cargando la Base de Datos: " + ex.Message; }
            tbStatusInfo.Text = "Datos de la Base de Datos correctamente cargados.";

        }

        //private void bActualizar_Click(object sender, RoutedEventArgs e)
        //{
        //    //string resultadoActualizacion = myControlador.GuardarDatosEnBD();
        //    //VentanaInformativa info = new VentanaInformativa(resultadoActualizacion);
        //    //info.ShowDialog();
        //}
    }
}



//string messageBoxText = "Has pulsado Pedidos_Modificacion";
//string caption = "Word Processor";
//MessageBoxButton button = MessageBoxButton.OK;
//MessageBoxImage icon = MessageBoxImage.Warning;
//// Display message box
//MessageBox.Show(messageBoxText, caption, button, icon);