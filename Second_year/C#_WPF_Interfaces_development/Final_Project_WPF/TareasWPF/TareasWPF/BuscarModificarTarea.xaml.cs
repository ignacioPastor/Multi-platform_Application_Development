using CapaModelo;
using CapaNegocio;
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
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace TareasWPF
{
    /// <summary>
    /// Lógica de interacción para BuscarModificarTarea.xaml
    /// </summary>
    public partial class BuscarModificarTarea : Window
    {
        Controlador controlador;
        private ObservableCollection<Tarea> ListaTareas;
        private CollectionViewSource MiVista;
        DataTable tableTareas;

        /// <summary>
        /// Constructor vacío
        /// </summary>
        public BuscarModificarTarea()
        {
            InitializeComponent();
            tableTareas = new DataTable();
            MiVista = new CollectionViewSource();
            controlador = new Controlador();
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos cuando vengamos desde la ventana principal
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        public BuscarModificarTarea(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            ListaTareas = new ObservableCollection<Tarea>();
            MiVista = (CollectionViewSource)FindResource("MisTareas");
        }
        /// <summary>
        /// Manejador del evento Ventana Cargada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            controlador.CargarDatosDataset();
            tableTareas = controlador.GetDataTable("tareas");
            Tarea t;
            foreach (DataRow row in tableTareas.Rows)
            {
                t = new Tarea(row);
                controlador.CompletarUsuarioProyectoEnTarea(t);
                ListaTareas.Add(t);
            }
            MiVista.Source = ListaTareas;
        }
        /// <summary>
        /// Filtro que aplicamos a nuestra vista.
        /// Rechaza las tareas cuando no cumplen con alguno de los requisitos indicados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiltrarTareas(object sender, FilterEventArgs e)
        {
            Tarea elemento = (Tarea)e.Item;
            if (elemento != null)
            {
                bool falsacionador = true;
                if (tbProyecto.Text != "")
                    if (!elemento.MyProyecto.Nombre.ToString().Contains(tbProyecto.Text.ToUpper()))
                        falsacionador = false;
                if (tbNombreUsuario.Text != "")
                    if (!elemento.MyUsuario.Nombre.ToUpper().Contains(tbNombreUsuario.Text.ToUpper()))
                        falsacionador = false;
                if (tbApellidosUsuario.Text != "")
                    if (!elemento.MyUsuario.Apellidos.ToUpper().Contains(tbApellidosUsuario.Text.ToUpper()))
                        falsacionador = false;
                e.Accepted = falsacionador;
            }
        }
        /// <summary>
        /// Quita el filtro previo y aplica el nuevo
        /// </summary>
        private void Filtrar()
        {
            MiVista.Filter -= FiltrarTareas;
            MiVista.Filter += FiltrarTareas;
        }

        private void tbProyecto_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrar();
        }

        private void tbNombreUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrar();
        }

        private void tbApellidosUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrar();
        }
        /// <summary>
        /// Controlador del eventro Click sobre el botón enviar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (MyListview.SelectedItem != null)
            {
                Tarea itemSeleccionado = (Tarea)MyListview.SelectedItem;
                InsertarTarea vInsertarTarea = new InsertarTarea(controlador, itemSeleccionado);
                vInsertarTarea.Show();
                this.Close();
            }
        }
    }
}
