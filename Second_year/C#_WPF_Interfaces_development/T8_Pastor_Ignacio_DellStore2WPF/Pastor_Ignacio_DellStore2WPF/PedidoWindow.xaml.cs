using CapaControlador;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para PedidoWindow.xaml
    /// </summary>
    public partial class PedidoWindow : Window
    {
        private CollectionViewSource MiVista;
        ObservableCollection<Order> listaPedidos;
        DataTable tableOrders;
        Controlador controlador;
        DataSet dataSetBD;
        public PedidoWindow()
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";

        }
        public PedidoWindow(Controlador controlador)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            this.controlador = controlador;
            listaPedidos = new ObservableCollection<Order>();
            MiVista = (CollectionViewSource)FindResource("MisPedidos");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataSetBD = controlador.GetDataSet();
            //GridPedido.DataContext = dataSetBD.DefaultViewManager;

            tableOrders = controlador.GetDataTable("orders");

            GridPedido.DataContext = tableOrders.DefaultView;

            foreach (DataRow row in tableOrders.Rows)
                listaPedidos.Add(new Order(row));

            MiVista.Source = listaPedidos;
            tbStatusInfo.Text = "Componentes cargados correctamente.";
        }
        private void FiltrarPedidos(object sender, FilterEventArgs e)
        {
            Order elemento = (Order)e.Item;
            if (elemento != null)
            {
                bool falsacionador = true;
                try
                {
                    if (tbNombre.Text != "")
                        if (!elemento.CustomerId.ToString().Contains(tbNombre.Text))
                            falsacionador = false;
                }
                catch (FormatException) { }
                try
                {
                    if (tbFactura.Text != "")
                        if (!elemento.OrderId.ToString().Contains(tbFactura.Text))
                            falsacionador = false;
                }
                catch (FormatException) { }

                e.Accepted = falsacionador;
            }
        }
        private void bFiltrar_Click(object sender, RoutedEventArgs e)
        {
            MiVista.Filter -= FiltrarPedidos;
            MiVista.Filter += FiltrarPedidos;
            tbStatusInfo.Text = "Filtro activo.";
        }

        private void bQuitarFiltros_Click(object sender, RoutedEventArgs e)
        {
            tbNombre.Text = tbFactura.Text = "";
            MiVista.Filter -= FiltrarPedidos;
            tbStatusInfo.Text = "Filtros eliminados.";
        }

        private void bModificar_Click(object sender, RoutedEventArgs e)
        {
            if (MyListview.SelectedItem != null)
            {
                tbStatusInfo.Text = "Procesando operación...";
                //DataRow itemSeleccionado = ((DataRowView)MyListview.SelectedItem).Row;
                Order pedidoSeleccionado = (Order)MyListview.SelectedItem;
                DataRow[] result = tableOrders.Select("orderid = " + pedidoSeleccionado.OrderId); //Devuelve un array de coincidencias

                FacturaPedidos ventanaModificar = new FacturaPedidos(controlador, result[0]);
                ventanaModificar.ShowDialog();
                this.Close();
            }
            tbStatusInfo.Text = "Debes seleccionar un pedido";
        }
    }
}


//private void bFiltrar_Click(object sender, RoutedEventArgs e)
//{
//    int nombreBuscar, facturaBuscar;
//    string cSelect = "";
//    try
//    {
//        nombreBuscar = Convert.ToInt32(tbNombre.Text);
//        cSelect += "customerid = " + nombreBuscar + "";
//    }
//    catch (FormatException) { }
//    cSelect += (cSelect.Length > 4) ? " and " : "";
//    try
//    {
//        facturaBuscar = Convert.ToInt32(tbFactura.Text);
//        cSelect += "orderid = " + facturaBuscar + "";
//    }
//    catch (FormatException) { }
//    cSelect = (cSelect.Length > 4) ? ((cSelect.Substring(cSelect.Length - 4, 4) == "and ") ? cSelect.Substring(0, cSelect.Length - 5) : cSelect) : cSelect;

//    tableOrders.DefaultView.RowFilter = cSelect;
//}

//private void bQuitarFiltros_Click(object sender, RoutedEventArgs e)
//{
//    tbNombre.Text = tbFactura.Text = "";
//    tableOrders.DefaultView.RowFilter = "orderid is not null";
//}