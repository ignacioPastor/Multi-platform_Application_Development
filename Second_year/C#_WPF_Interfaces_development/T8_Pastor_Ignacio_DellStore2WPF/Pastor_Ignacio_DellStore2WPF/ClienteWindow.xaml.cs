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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class ClienteWindow : Window
    {

        DataTable tableCustomers;
        public Controlador controlador;
        private CollectionViewSource MiVista;
        private ObservableCollection<Customer> ListaClientes;
        private DataRow rowClienteAltaFactura;
        Customer clienteAltaFactura;
        Factura factura;
        private bool altaFactura;
        public ClienteWindow()
        {
            tbStatusInfo.Text = "Cargando componentes...";
            InitializeComponent();
            ListaClientes = new ObservableCollection<Customer>();
            MiVista = (CollectionViewSource)FindResource("MisClientes");
            altaFactura = false;

        }
        /// <summary>
        /// Constructor que usamos cuando venimos de la ventana principal
        /// </summary>
        /// <param name="controlador"></param>
        public ClienteWindow(Controlador controlador)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";

            ListaClientes = new ObservableCollection<Customer>();
            MiVista = (CollectionViewSource)FindResource("MisClientes");
            this.controlador = controlador;
            altaFactura = false;
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos cuando demos de alta una nueva factura, para seleccionar el cliente.
        /// </summary>
        /// <param name="controlador"></param>
        public ClienteWindow(Controlador controlador, DataRow rowClienteAltaFactura)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";

            ListaClientes = new ObservableCollection<Customer>();
            MiVista = (CollectionViewSource)FindResource("MisClientes");
            this.controlador = controlador;
            this.rowClienteAltaFactura = rowClienteAltaFactura;
            bModificar.Content = "Seleccionar";
            altaFactura = true;
        }
        public ClienteWindow(Controlador controlador, Factura factura)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";

            ListaClientes = new ObservableCollection<Customer>();
            MiVista = (CollectionViewSource)FindResource("MisClientes");
            this.controlador = controlador;
            this.factura = factura;
            bModificar.Content = "Seleccionar";
            altaFactura = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tableCustomers = controlador.GetDataTable("customers");
            //GridCustomer.DataContext = tableCustomers.DefaultView;
            CargarListaClientes();
            MiVista.Source = ListaClientes;
            tbStatusInfo.Text = "Componentes cargados correctamente.";

        }
        private void CargarListaClientes()
        {
            tbStatusInfo.Text = "Cargando datos...";

            foreach (DataRow row in tableCustomers.Rows)
            {
                ListaClientes.Add(new Customer(row));
            }
            tbStatusInfo.Text = "Cargando componentes...";

        }
        private void FiltrarClientes(object sender, FilterEventArgs e)
        {

            Customer elemento = (Customer)e.Item;
            bool falsacionador = true;

            if (tbNombre.Text != "")
                if (!elemento.FirstName.ToUpper().Contains(tbNombre.Text.ToUpper()))
                    falsacionador = false;
            if(tbApellidos.Text != "")
                if (!elemento.LastName.ToUpper().Contains(tbApellidos.Text.ToUpper()))
                    falsacionador = false;
            if (tbCiudad.Text != "")
                if (!elemento.City.ToUpper().Contains(tbCiudad.Text.ToUpper()))
                    falsacionador = false;
            if (tbPais.Text != "")
                if (!elemento.Country.ToUpper().Contains(tbPais.Text.ToUpper()))
                    falsacionador = false;

            e.Accepted = falsacionador;
        }
        private void bFiltrar_Click(object sender, RoutedEventArgs e)
        {
            tbStatusInfo.Text = "Filtrando clientes...";

            MiVista.Filter -= FiltrarClientes;
            MiVista.Filter += FiltrarClientes;
            tbStatusInfo.Text = "Filtrado finalizado.";

        }

        private void bquitarFiltros_Click(object sender, RoutedEventArgs e)
        {
            tbStatusInfo.Text = "Eliminando filtros...";

            tbNombre.Text = tbApellidos.Text = tbCiudad.Text = tbPais.Text = "";
            MiVista.Filter -= FiltrarClientes;
            tbStatusInfo.Text = "Filtros eliminados.";

        }

        private void bModificar_Click(object sender, RoutedEventArgs e)
        {
            
            if (MyListview.SelectedItem != null)
            {
                tbStatusInfo.Text = "Procesando operación...";

                if (altaFactura)
                {
                    //Customer itemSeleccionado = (Customer)MyListview.SelectedItem;
                    clienteAltaFactura = (Customer)MyListview.SelectedItem;
                    factura.Cliente = clienteAltaFactura;
                    //DataRow[] result = tableCustomers.Select("customerid = " + itemSeleccionado.CustomerId);
                    //rowClienteAltaFactura = result[0];
                    this.Close();

                }
                else
                {
                    Customer itemSeleccionado = (Customer)MyListview.SelectedItem;
                    DataRow[] result = tableCustomers.Select("customerid = " + itemSeleccionado.CustomerId); //Devuelve un array de coincidencias
                    AltaModificacionCliente ventanaModificar = new AltaModificacionCliente(controlador, result[0]);
                    ventanaModificar.Show();
                    this.Close();
                }
                
            }
            tbStatusInfo.Text = "Ningún cliente seleccionado.";

        }

    }
}


//Filtros antiguos
//private void bFiltrar_Click(object sender, RoutedEventArgs e)
//{
//    string nombreBuscar = tbNombre.Text;
//    string apellidosBuscar = tbApellidos.Text;
//    string ciudadBuscar = tbCiudad.Text;
//    string paisBuscar = tbPais.Text;

//    string cSelect = "";
//    cSelect += (nombreBuscar != null && nombreBuscar != "") ? "firstname like '*" + nombreBuscar + "*'" : "";
//    cSelect += (cSelect.Length > 4) ? " and " : "";
//    cSelect += (apellidosBuscar != null && apellidosBuscar != "") ? "lastname like '*" + apellidosBuscar + "*'" : "";
//    cSelect += (cSelect.Length > 4) ? ((cSelect.Substring(cSelect.Length - 4, 4) == "and ") ? "" : " and ") : "";
//    cSelect += (ciudadBuscar != null && ciudadBuscar != "") ? "city like '*" + ciudadBuscar + "*'" : "";
//    cSelect += (cSelect.Length > 4) ? ((cSelect.Substring(cSelect.Length - 4, 4) == "and ") ? "" : " and ") : "";
//    cSelect += (paisBuscar != null && paisBuscar != "") ? "city like '*" + paisBuscar + "*'" : "";
//    cSelect = (cSelect.Length > 4) ? ((cSelect.Substring(cSelect.Length - 4, 4) == "and ") ? cSelect.Substring(0, cSelect.Length - 5) : cSelect) : cSelect;

//    tableCustomers.DefaultView.RowFilter = cSelect;
//}

//private void bquitarFiltros_Click(object sender, RoutedEventArgs e)
//{
//    tbNombre.Text = tbApellidos.Text = tbCiudad.Text = tbPais.Text = "";
//    tableCustomers.DefaultView.RowFilter = "customerid is not null";
//}