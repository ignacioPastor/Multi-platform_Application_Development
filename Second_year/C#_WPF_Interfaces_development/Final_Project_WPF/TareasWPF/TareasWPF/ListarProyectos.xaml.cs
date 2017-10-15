using CapaModelo;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para ListarProyectos.xaml
    /// </summary>
    public partial class ListarProyectos : Window
    {
        Tarea tarea;
        Controlador controlador;
        private CollectionViewSource MiVista;
        private ObservableCollection<Proyecto> ListaProyectos;
        bool insertarTarea;
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public ListarProyectos()
        {
            InitializeComponent();
            insertarTarea = false;
            ListaProyectos = new ObservableCollection<Proyecto>();
            MiVista = (CollectionViewSource)FindResource("MisProyectos");
            tarea = new Tarea();
            controlador = new Controlador();
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos para seleccionar un proyecto que queramos asignar a una tarea.
        /// </summary>
        /// <param name="controlador">controlador de nuestro programa</param>
        /// <param name="tarea">tarea que estamos insertando o modificando, a la que queremos asignar un proyecto</param>
        public ListarProyectos(Controlador controlador, Tarea tarea)
        {
            InitializeComponent();
            this.controlador = controlador;
            this.tarea = tarea;
            ListaProyectos = new ObservableCollection<Proyecto>();
            MiVista = (CollectionViewSource)FindResource("MisProyectos");
            insertarTarea = true;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            controlador.CargarProyectos();
            ListaProyectos = controlador.GetProyectos();
            MiVista.Source = ListaProyectos;
        }
        /// <summary>
        /// Aplica el filtro según los caracteres especificados por el usuario.
        /// Si no cumple con alguno de los requisitos, el proyecto es descartado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiltrarProyectos(object sender, FilterEventArgs e)
        {
            Proyecto elemento = (Proyecto)e.Item;
            if (elemento != null)
            {
                bool falsacionador = true;
                if (tbIdProyecto.Text != "")
                    if (!elemento.IdProyecto.ToString().Contains(tbIdProyecto.Text))
                        falsacionador = false;
                if (tbNombre.Text != "")
                    if (!elemento.Nombre.ToUpper().Contains(tbNombre.Text.ToUpper()))
                        falsacionador = false;
                e.Accepted = falsacionador;
            }
        }
        /// <summary>
        /// Quita el filtro previo y aplica el nuevo
        /// </summary>
        private void Filtrar()
        {
            MiVista.Filter -= FiltrarProyectos;
            MiVista.Filter += FiltrarProyectos;
        }
        private void tbIdProyecto_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrar();
        }

        private void tbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrar();
        }

        private void bSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (MyListview.SelectedItem != null)
            {
                Proyecto itemSeleccionado = (Proyecto)MyListview.SelectedItem;
                if (insertarTarea)
                {
                    tarea.MyProyecto = itemSeleccionado;
                }
                this.Close();
            }
        }
    }
}
