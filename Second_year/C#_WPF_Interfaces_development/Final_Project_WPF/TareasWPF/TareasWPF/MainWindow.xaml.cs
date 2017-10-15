using CapaNegocio;
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
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace TareasWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controlador controlador;
        /// <summary>
        /// Constructor vacío.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            tbInfo.Text = "";
        }
        /// <summary>
        /// Consturctor sobrecargado.
        /// Se utilizará cuando venimos de la ventana de Login
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        public MainWindow(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            
        }
        /// <summary>
        /// Método que controla el evento Loaded de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbInfo.Text = "Componentes cargados correctamente.";
            tbUserLoged.Text = "Usuario Logeado: " + controlador.GetUsuarioLogin().User
                + " (" + controlador.GetUsuarioLogin().TipoUsuario + ")";
        }

        private void Archivo_ExportarTareas_Click(object sender, RoutedEventArgs e)
        {
            VentanaInformativa vInfo = new VentanaInformativa("(No implementada)");
            vInfo.ShowDialog();
        }

        private void Archivo_Salir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show("Quieres salir del programa?", "Warning!", btnMessageBox, icnMessageBox);
            if(rsltMessageBox == MessageBoxResult.Yes)
                this.Close();
        }
        private void Usuario_Insertar_Click(object sender, RoutedEventArgs e)
        {
            InsertarUsuario vInsertarUser = new InsertarUsuario(controlador);
            vInsertarUser.ShowDialog();
        }
        private void Usuario_BuscarModificar_Click(object sender, RoutedEventArgs e)
        {
            
            ListarModificarUsuario listModUser = new ListarModificarUsuario(controlador);
            listModUser.ShowDialog();
        }

        private void Tarea_Buscar_y_Modificar(object sender, RoutedEventArgs e)
        {
            BuscarModificarTarea vBuscarTarea = new BuscarModificarTarea(controlador);
            vBuscarTarea.ShowDialog();
        }
        private void Tarea_Insertar(object sender, RoutedEventArgs e)
        {
            InsertarTarea vInsertarTarea = new InsertarTarea(controlador);
            vInsertarTarea.ShowDialog();
        }

        private void InformeMensual_Click(object sender, RoutedEventArgs e)
        {
            //RecabarDatosInforme es la ventana "Informe Mensual", que le he cambiado el nombre y no se ha reflejado aquí.
            RecabarDatosInforme vInforme = new RecabarDatosInforme(controlador);
            vInforme.ShowDialog();
        }
    }
}
