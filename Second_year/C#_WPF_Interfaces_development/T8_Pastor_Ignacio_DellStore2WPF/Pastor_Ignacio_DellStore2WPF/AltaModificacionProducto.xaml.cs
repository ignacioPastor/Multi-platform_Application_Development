using CapaModelo;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Pastor_Ignacio_DellStore2WPF
{
    /// <summary>
    /// Lógica de interacción para AltaModificacionProducto.xaml
    /// </summary>
    public partial class AltaModificacionProducto : Window
    {
        private int _noOfErrorsOnScreen = 0;
        CapaControlador.Controlador controlador;
        DataTable tableProducts;
        DataRow producto;
        products myObjetoProducto;
        static DataTable tableProductsCopy;
        bool alta;

        /// <summary>
        /// Constructor vacío.
        /// En principio no se utiliza
        /// </summary>
        public AltaModificacionProducto()
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            controlador = new CapaControlador.Controlador();
            tableProducts = controlador.GetDataTable("products");
            producto = tableProducts.NewRow();
            myObjetoProducto = new products();
            alta = false;
        }
        /// <summary>
        /// Constructor sobrecargado con un controlador.
        /// Utilizado para el acceso a esta ventana desde la ventana principal del programa
        /// </summary>
        /// <param name="controlador"> controlador de nuestro programa </param>
        public AltaModificacionProducto(CapaControlador.Controlador controlador)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            this.controlador = controlador;
            tableProducts = controlador.GetDataTable("products");
            producto = tableProducts.NewRow();
            
            myObjetoProducto = new products();
            myObjetoProducto.Title = "Introduza el título.";
            myObjetoProducto.Actor = "Introduza el actor.";
            tbProdId.Visibility = Visibility.Hidden;
            alta = true;
            tableProductsCopy = tableProducts;
            tbInfoAuto.Text = "(Auto)";
           
        }
        
        /// <summary>
        /// Constructor sobrecargado
        /// Lo utilizaremos desde la ventana de listar los productos para verlos / modificar alguno
        /// </summary>
        /// <param name="controlador"> controlador de nuestro programa</param>
        /// <param name="productModificar"> Producto existente que se quiere modificar</param>
        public AltaModificacionProducto(CapaControlador.Controlador controlador, DataRow producto)
        {
            InitializeComponent();
            tbStatusInfo.Text = "Cargando componentes...";
            this.controlador = controlador;
            this.producto = producto;
            myObjetoProducto = new products(producto);
            tableProducts = controlador.GetDataTable("products");
            tbProdId.Visibility = Visibility.Visible;
            alta = false;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myGridProduct.DataContext = myObjetoProducto;
            tbStatusInfo.Text = "Componentes cargados correctamente.";
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            tbStatusInfo.Text = "Procesando operación...";
            myObjetoProducto = myGridProduct.DataContext as products; 
            AsignarValoresProducto();
            if(alta)
                tableProducts.Rows.Add(producto);
            string message = "";
            try { message = controlador.GuardarDatosEnBD("products"); } catch (Exception ex) { message = tbStatusInfo.Text = "Error: " + ex.Message; }
            controlador.CargarDatosDataset();
            tbStatusInfo.Text = "Datos guardados corerctamente.";
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
            producto["prod_id"] = 0;

            producto["category"] = myObjetoProducto.Category;
            producto["title"] = myObjetoProducto.Title;
            producto["actor"] = myObjetoProducto.Actor;
            producto["price"] = myObjetoProducto.Price;
            producto["special"] = myObjetoProducto.Special;
            producto["common_prod_id"] = myObjetoProducto.CommonProdId;
        }
        private void LanzarVentanaInformativa(string message)
        {
            VentanaInformativa myVentanaInformativa = new VentanaInformativa(message);
            myVentanaInformativa.Owner = this;
            myVentanaInformativa.ShowDialog();
        }

        //private void bFinalizar_Click(object sender, RoutedEventArgs e)
        //{
        //    DataRow item = producto;
        //    //    this.Close();
        //}

    }
}
