using CapaControlador;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Pastor_Ignacio_DellStore2WPF
{
    /// <summary>
    /// Lógica de interacción para ProductoWindow.xaml
    /// </summary>
    public partial class ProductoWindow : Window
    {
        //bool filtroCategoria;
        //bool filtroBuscar;
        DataTable tableProducts;
        private CollectionViewSource MiVista;
        private ObservableCollection<products> ListaProductos;
        bool anyadirProductoFactura;
        Factura factura;


        public Controlador controlador;
        
        public ProductoWindow()
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            ListaProductos = new ObservableCollection<products>();
            MiVista = (CollectionViewSource)FindResource("MisProductos");

            controlador = new Controlador();
            anyadirProductoFactura = false;
        }
        public ProductoWindow(Controlador controlador)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            ListaProductos = new ObservableCollection<products>();
            MiVista = (CollectionViewSource)FindResource("MisProductos");

            this.controlador = controlador;
            anyadirProductoFactura = false;
        }
        public ProductoWindow(Controlador controlador, Factura factura)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            ListaProductos = new ObservableCollection<products>();
            MiVista = (CollectionViewSource)FindResource("MisProductos");

            this.controlador = controlador;

            this.factura = factura;
            anyadirProductoFactura = true;
            bModificar.Content = "Seleccionar";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tableProducts = controlador.GetDataTable("products");
            CargarListaProductos();
            //GridProduct.DataContext = tableProducts.DefaultView; // Esto lo hacía cuando utilizaba los filtros antiguos
            //MiVista.Source = tableProducts.DefaultView; //Esto peta cuando intenta filtrar
            MiVista.Source = ListaProductos;

            cbCategorias.ItemsSource = controlador.GetCategoriasProductos(); //Cargamos el comboBox de categorías, traemos una ObservableCollection tras hacer
            //QuitarFiltros();
            tbStatusInfo.Text = "Componentes cargados correctamente.";
        }
        private void CargarListaProductos()
        {
            foreach(DataRow row in tableProducts.Rows)
            {
                ListaProductos.Add(new products(row));
            }
        }
        
        private void FiltrarProductos(object sender, FilterEventArgs e)
        {
            products elemento = (products)e.Item;
            if (elemento != null)
            {
                int category = cbCategorias.SelectedItem != null ? (int)cbCategorias.SelectedItem : -1;
                bool falsacionador = true;

                if (tbBuscar.Text != "")
                    if (!elemento.Title.ToUpper().Contains(tbBuscar.Text.ToUpper()))
                        falsacionador = false;

                if (category != -1)
                    if (elemento.Category != category)
                        falsacionador = false;

                e.Accepted = falsacionador;
            }
        }
        /// <summary>
        /// Aplica el filtro
        /// Antes de aplicar un filtro, eliminamos filtro. Caso de no haber ningún filtro aplicado no pasa nada, 
        /// pero si ya hay un filtro y no lo eliminamos, se acumulan dos filtros. Cuando pulsemos eliminar filtro
        /// pasaríamos del segundo filtro al primero. Se genera una especie de pila de filtros, que no es que se acumulen, 
        /// sino que se hace una pila de distintos estados de filtrado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bFiltrar_onClick(object sender, RoutedEventArgs e)
        {
            MiVista.Filter -= FiltrarProductos;
            MiVista.Filter += FiltrarProductos;
            tbStatusInfo.Text = "Filtro activo.";
        }
        /// <summary>
        /// Elimina el filtro que se está aplicando en este momento, caso de haberlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bQuitarFiltros_onClick(object sender, RoutedEventArgs e)
        {
            tbBuscar.Text = "";
            cbCategorias.SelectedItem = null;
            MiVista.Filter -= FiltrarProductos;
            tbStatusInfo.Text = "Filtros eliminados.";
        }
       
        private void bModificar_Click(object sender, RoutedEventArgs e)
        {
            
            if(MyListview.SelectedItem != null)
            {
                tbStatusInfo.Text = "Procesando operación...";
                if (anyadirProductoFactura)
                {
                    AnyadirProductoAFactura();
                }
                else
                {
                    products itemSeleccionado = (products)MyListview.SelectedItem;
                    DataRow[] result = tableProducts.Select("prod_id = " + itemSeleccionado.ProdId); //Devuelve un array de coincidencias
                    AltaModificacionProducto ventanaModificar =
                            new AltaModificacionProducto(controlador, result[0]); //result[0] porque hemos buscado por pk, solo habrá una coincidencia
                    ventanaModificar.Show();
                    this.Close();
                }
            }
            tbStatusInfo.Text = "Debes seleccionar un Producto.";
        }
        private DataRow BuscarItemSeleccionadoEnTabla(products itemSeleccionado)
        {
            DataRow[] result = tableProducts.Select("prod_id = " + itemSeleccionado.ProdId);

            return result[0];
        }
        private void AnyadirProductoAFactura()
        {
            products prodAnyadir = (products)MyListview.SelectedItem;
            Orderline nuevaLineaPedido = new Orderline(prodAnyadir, factura.Pedido, factura.ListaLineasPedido);
            factura.ListaLineasPedido.Add(nuevaLineaPedido);
            this.Close();
            
        }
    }
}


//Filtro antiguo
//private void bFiltrar_onClick(object sender, RoutedEventArgs e)
//       {
//           string nombreBuscar = tbBuscar.Text;
//           string cSelect = null;
//           try { cSelect = Convert.ToString((Int32)cbCategorias.SelectedItem); } catch (Exception) { }

//           filtroBuscar = (nombreBuscar != null && nombreBuscar != "") ? true : false;
//           filtroCategoria = (cSelect != null) ? true : false;

//           if (filtroCategoria && !filtroBuscar) // Filtrar solo por categoría
//               tableProducts.DefaultView.RowFilter = "category = '" + cSelect + "'";
//           else if (!filtroCategoria && filtroBuscar) // Filtrar solo por búsqueda de título
//               tableProducts.DefaultView.RowFilter = "title like '*" + nombreBuscar + "*'";
//           else if (filtroCategoria && filtroBuscar) //Filtrar tanto por categoría como por título
//               tableProducts.DefaultView.RowFilter = "title like '*" + nombreBuscar + "*' and category = '" + cSelect + "'";
//       }

// Para quitar los antiguos filtros
//private void bQuitarFiltros_onClick(object sender, RoutedEventArgs e)
//{
//    QuitarFiltros();
//}
//private void QuitarFiltros()
//{
//    tbBuscar.Text = "";
//    filtroBuscar = false;
//    cbCategorias.SelectedItem = null;
//    filtroCategoria = false;

//    tableProducts.DefaultView.RowFilter = "prod_id is not null";
//}

//private void bModificar_Click(object sender, RoutedEventArgs e)
//{
//    if (MyListview.SelectedItem != null)
//    {

//        DataRow itemSeleccionado = ((DataRowView)MyListview.SelectedItem).Row;
//        AltaModificacionProducto ventanaModificar = new AltaModificacionProducto(controlador, itemSeleccionado);
//        ventanaModificar.Show();
//        this.Close();
//    }
//}