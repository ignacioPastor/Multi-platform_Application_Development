using CapaModelo;
using CapaControlador;
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
using System.Threading;

namespace Pastor_Ignacio_DellStore2WPF
{
    /// <summary>
    /// Lógica de interacción para AltaModificacionCliente.xaml
    /// </summary>
    public partial class AltaModificacionCliente : Window
    {

        private int _noOfErrorsOnScreen = 0;
        Controlador controlador;
        DataRow clienteModificar;
        DataTable tableCustomers;
        Customer myObjetoCliente;
        static DataTable tableCustomerCopy;
        bool alta;
        /// <summary>
        /// Constructor vacío, en principio no se usa
        /// </summary>
        public AltaModificacionCliente()
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";

            controlador = new Controlador();
            clienteModificar = null;
            alta = false;
            myObjetoCliente = new Customer();
        }
        /// <summary>
        /// Constructor que se usará cuando vengamos de la ventana principal (Alta cliente)
        /// </summary>
        /// <param name="controlador">controlador de nuestro programa</param>
        public AltaModificacionCliente(Controlador controlador)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";

            this.controlador = controlador;
            tableCustomers = controlador.GetDataTable("customers");
            clienteModificar = tableCustomers.NewRow();
            myObjetoCliente = new Customer();
            tbCustomerid.Visibility = Visibility.Hidden;
            alta = true;

            //myObjetoCliente.CustomerId = controlador.GetProdIdEstimada(); //Esto tarda demasiado, ya veremos si merece la pena (4.9s)
            tableCustomerCopy = tableCustomers;
            //t.Start(); //Lo malo de esto es que se tardan 38s en cargar, bien si realmente se rellenan los campos. Mal si estás probando y vas rápido
            tbInfoAuto.Text = "(Auto)";

        }
        /// <summary>
        /// Constructor que se usará cuando vengamos de la ventana de listar clientes (modificar cliente)
        /// </summary>
        /// <param name="controlador">controlador de nuestro programa</param>
        /// <param name="clienteModificar">cliente cuyos datos queremos modificar</param>
        public AltaModificacionCliente(Controlador controlador, DataRow clienteModificar)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";

            this.controlador = controlador;
            this.clienteModificar = clienteModificar;
            myObjetoCliente = new Customer(clienteModificar);
            tableCustomers = controlador.GetDataTable("customers");
            tbCustomerid.Visibility = Visibility.Visible;
            alta = false;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myGridCustomer.DataContext = myObjetoCliente;
            tbStatusInfo.Text = "Componentes cargados correctamente.";

            //if (!alta)
            //{
            //    tbUsuario.IsReadOnly = true;
            //    tbUsuario.ToolTip = "El nombre de usuario no se puede modificar";
            //}
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(alta)
                Validator.IsValid(tbUsuario);
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
            
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            tbStatusInfo.Text = "Procesando...";

            myObjetoCliente = myGridCustomer.DataContext as Customer;
            AsignarValoresProducto();
            if(alta)
                tableCustomers.Rows.Add(clienteModificar);
            string message = "";
            try { message = controlador.GuardarDatosEnBD("customers"); } catch (Exception ex) { message = tbStatusInfo.Text = "Error: " + ex.Message; }
            controlador.CargarDatosDataset();
            tbStatusInfo.Text = "Base de datos actualizada.";

            LanzarVentanaInformativa(message);
            this.Close();
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }
        private void AsignarValoresProducto()
        {
            
            clienteModificar["customerid"] = 0; //Asignamos cualquiera, pues la BD se la asignará automáticamente, ignorando la nuestra

            clienteModificar["firstname"] = myObjetoCliente.FirstName;
            clienteModificar["lastname"] = myObjetoCliente.LastName;
            clienteModificar["address1"] = myObjetoCliente.Address1;
            clienteModificar["address2"] = myObjetoCliente.Address2;
            clienteModificar["city"] = myObjetoCliente.City;
            clienteModificar["state"] = myObjetoCliente.State;
            clienteModificar["zip"] = myObjetoCliente.Zip;
            clienteModificar["country"] = myObjetoCliente.Country;
            clienteModificar["region"] = myObjetoCliente.Region;
            clienteModificar["email"] = myObjetoCliente.Email;
            clienteModificar["phone"] = myObjetoCliente.Phone;
            clienteModificar["creditcard"] = myObjetoCliente.CreditCard;
            clienteModificar["creditcardtype"] = myObjetoCliente.CreditCardType;
            clienteModificar["creditcardexpiration"] = myObjetoCliente.CreditCardExpiration;
            clienteModificar["username"] = myObjetoCliente.UserName;
            clienteModificar["password"] = myObjetoCliente.Password;
            clienteModificar["age"] = myObjetoCliente.Age;
            clienteModificar["income"] = myObjetoCliente.Income;
            clienteModificar["gender"] = myObjetoCliente.Gender;
        }

        private void LanzarVentanaInformativa(string message)
        {
            VentanaInformativa myVentanaInformativa = new VentanaInformativa(message);
            myVentanaInformativa.Owner = this;
            myVentanaInformativa.ShowDialog();
        }
        
    }
}
