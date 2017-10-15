using CapaControlador;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Pastor_Ignacio_DellStore2WPF
{
    /// <summary>
    /// Lógica de interacción para FacturaPedidos.xaml
    /// </summary>
    public partial class FacturaPedidos : Window
    {
        bool alta;
        Factura miFactura;
        Controlador controlador;
        DataTable tableProductos;
        DataTable tableClientes;

        Customer clienteAltaFactura;
        DataRow rowClienteAltaFactura;
        DataRow rowPedido;
        DataRow[] rowProducto;
        List<Orderline> listaLineasPedidos;
        DataRow[] rowsLineasPedido;

        public FacturaPedidos()
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            alta = false;
            //myFactura = new Factura(new products(), "HOLIIII");
        }
        /// <summary>
        /// Constructor Sobrecargado
        /// Lo utilizaremos cuando vengamos del listado de pedidos (Modificar)
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        /// <param name="pedido">Pedido a modificar</param>
        public FacturaPedidos(Controlador controlador, DataRow pedido)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            this.controlador = controlador;
            this.rowPedido = pedido;
            alta = false;
            listaLineasPedidos = new List<Orderline>();
            CargarObjetoFactura();
            

        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos cuando vengamos de la ventana principal (alta nuevo pedido)
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        public FacturaPedidos(Controlador controlador)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            this.controlador = controlador;
            alta = true;
            VentanaInformativa vInfo = new VentanaInformativa("Por favor, elige el cliente a quien vas a realizar la factura");
            vInfo.ShowDialog();
            rowClienteAltaFactura = null;
            clienteAltaFactura = null;
            miFactura = new Factura(new Customer(), new Order(), new List<Orderline>());
            tbFacturaResult.Visibility = Visibility.Hidden;
            tbFacturaTexto.Visibility = Visibility.Hidden;
            //ClienteWindow cWindow = new ClienteWindow(controlador, rowClienteAltaFactura);
            ClienteWindow cWindow = new ClienteWindow(controlador, miFactura);
            cWindow.ShowDialog();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyGridFactura.DataContext = miFactura;
            tbStatusInfo.Text = "Componentes cargados correctamente.";

        }
        private void CargarObjetoFactura()
        {
            int idCustomer = (int)rowPedido["customerid"];
            tableClientes = controlador.GetDataTable("customers");
            DataRow[] rowCliente = tableClientes.Select("customerid = " + idCustomer); //Consigo el cliente
            rowsLineasPedido = controlador.GetDataTable("orderlines").Select("orderid = " + rowPedido["orderid"]); //Consigo las líneas de pedido
            for (int i = 0; i < rowsLineasPedido.Length; i++)
            {
                rowProducto = controlador.GetDataTable("products").Select("prod_id = " + (int)rowsLineasPedido[i]["prod_id"]); //Consigo el producto de la orderline
                listaLineasPedidos.Add(new Orderline(rowsLineasPedido[i], new products(rowProducto[0]))); //Añado a la lista de orderlines, un nuevo orderline con el producto que contiene
            }
            miFactura = new Factura(new Customer(rowCliente[0]), new Order(rowPedido), listaLineasPedidos);
        }

        private void bPlus_Click(object sender, RoutedEventArgs e)
        {
            if(MyListview.SelectedItem != null)
            {
                Orderline lineModify = (Orderline)MyListview.SelectedItem;
                int index = MyListview.SelectedIndex;
                lineModify.Quantity++;
                MyGridFactura.DataContext = null;
                MyGridFactura.DataContext = miFactura;
                MyListview.SelectedIndex = index;
                tbStatusInfo.Text = "";

            }
            else
                tbStatusInfo.Text = "Debes seleccionar una línea de pedido.";
        }

        private void bMinus_Click(object sender, RoutedEventArgs e)
        {
            if (MyListview.SelectedItem != null)
            {
                Orderline lineModify = (Orderline)MyListview.SelectedItem;
                if (lineModify.Quantity > 1)
                {
                    lineModify.Quantity--;
                    int index = MyListview.SelectedIndex;
                    MyGridFactura.DataContext = null;
                    MyGridFactura.DataContext = miFactura;
                    MyListview.SelectedIndex = index;
                    tbStatusInfo.Text = "";

                }
                else
                    tbStatusInfo.Text = "La cantidad mínima es 1. Si lo desesas puedes eliminar la línea de pedido.";

            }
            else
                tbStatusInfo.Text = "Debes seleccionar una línea de pedido.";

        }

        private void bEliminarLine_Click(object sender, RoutedEventArgs e)
        {
            if (MyListview.SelectedItem != null)
            {
                Orderline lineModify = (Orderline)MyListview.SelectedItem;
                MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
                MessageBoxResult rsltMessageBox = MessageBox.Show("Quieres eliminar la línea de pedido seleccionada?",
                    "Warning!", btnMessageBox, icnMessageBox);
                if (rsltMessageBox == MessageBoxResult.Yes)
                {
                    miFactura.ListaLineasPedido.Remove(lineModify);
                    MyGridFactura.DataContext = null;
                    MyGridFactura.DataContext = miFactura;
                    tbStatusInfo.Text = "Línea de pedido eliminada. Recuerda guardar antes de salir.";
                }
            }
            else
                tbStatusInfo.Text = "Debes seleccionar una línea de pedido.";

        }

        private void bAnyadir_Click(object sender, RoutedEventArgs e)
        {
            tbStatusInfo.Text = "Iniciando operación...";

            ProductoWindow vProducto = new ProductoWindow(controlador, miFactura);
            vProducto.ShowDialog();
            MyGridFactura.DataContext = null;
            MyGridFactura.DataContext = miFactura;
            tbStatusInfo.Text = "Operación realizads correctamente.";

        }

        private void bGuardar_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = "";
                if (alta)
                {
                    try
                    {
                        tbStatusInfo.Text = "Guardando pedido...";

                        controlador.InsertOrder(miFactura);
                        controlador.CargarDatosDataset();
                        DataTable tableOrders = controlador.GetDataTable("orders");
                        DateTime datePrueba = miFactura.Pedido.OrderDate.Date;
                        DataRow[] result = tableOrders.Select("customerid = " + miFactura.Cliente.CustomerId
                            + " and orderdate = '" + miFactura.Pedido.OrderDate.Date + "'");// and tax = " + miFactura.Pedido.Tax);
                        miFactura.Pedido.OrderId = (int)result[0]["orderid"];
                        foreach (Orderline line in miFactura.ListaLineasPedido)
                        {
                            line.OrderId = miFactura.Pedido.OrderId;
                        }

                        controlador.InsertOrderlines(miFactura);
                        controlador.CargarDatosDataset();
                        mensaje = "Pedido guardado correctamente";
                        tbStatusInfo.Text = "Pedido guardado correctamente";

                    }
                    catch (Exception ex) { mensaje = tbStatusInfo.Text = "Ha habido un error guardando el pedido: " + ex.Message; }
                }
                else
                {
                    try
                    {
                        tbStatusInfo.Text = "Actualizando pedido...";

                        controlador.Update(miFactura);
                        controlador.CargarDatosDataset();
                        mensaje = "Pedido modificado correctamente";
                        tbStatusInfo.Text = "Pedido actualizado correctamente";

                    }catch(Exception exc) { mensaje = tbStatusInfo.Text = "Ha habido un error actualizando el pedido: " + exc.Message; }
                }
            VentanaInformativa vInfo = new VentanaInformativa(mensaje);
            vInfo.ShowDialog();
            this.Close();
        }
    }
}
