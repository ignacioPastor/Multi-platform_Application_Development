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
    /// Lógica de interacción para ListarModificarUsuario.xaml
    /// </summary>
    public partial class ListarModificarUsuario : Window
    {
        private CollectionViewSource MiVista;
        private ObservableCollection<Usuario> ListaUsuarios;
        private Controlador controlador;
        private Tarea tarea;
        private bool insertarTarea;
        Usuario usuarioInforme;
        private bool informe;
        /// <summary>
        /// Controlador vacío
        /// </summary>
        public ListarModificarUsuario()
        {
            InitializeComponent();
            ListaUsuarios = new ObservableCollection<Usuario>();
            MiVista = (CollectionViewSource)FindResource("MisUsuarios");
            insertarTarea = false;
            informe = false;
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos cuando vengamos de la ventana principal (para ver o modificar un usuario)
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        public ListarModificarUsuario(Controlador controlador)
        {
            InitializeComponent();
            ListaUsuarios = new ObservableCollection<Usuario>();
            MiVista = (CollectionViewSource)FindResource("MisUsuarios");
            this.controlador = controlador;
            insertarTarea = false;
            informe = false;
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos cuando vengamos de la ventana de Insertar Tarea.
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        /// <param name="tarea">Tarea a la que queremos añadirle un usuario que vamos a seleccionar</param>
        public ListarModificarUsuario(Controlador controlador, Tarea tarea)
        {
            InitializeComponent();
            ListaUsuarios = new ObservableCollection<Usuario>();
            MiVista = (CollectionViewSource)FindResource("MisUsuarios");
            this.controlador = controlador;
            this.tarea = tarea;
            insertarTarea = true;
            informe = false;
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos cuando vengamos de la ventana de "Informe Mensual".
        /// 
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        /// <param name="usuarioInforme">Usuario cuyas tareas vamos a mostrar en el informe, ahora deberemos seleccionarlo</param>
        public ListarModificarUsuario(Controlador controlador, Usuario usuarioInforme)
        {
            InitializeComponent();
            ListaUsuarios = new ObservableCollection<Usuario>();
            MiVista = (CollectionViewSource)FindResource("MisUsuarios");
            this.controlador = controlador;
            this.usuarioInforme = usuarioInforme;
            insertarTarea = false;
            informe = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            controlador.CargarUsuarios();
            ListaUsuarios = controlador.GetUsuarios();
            MiVista.Source = ListaUsuarios;
        }
        /// <summary>
        /// Filtro que aplicamos a nuestra vista.
        /// Rechaza los usuarios cuando no cumplen con alguno de los requisitos indicados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiltrarUsuarios(object sender, FilterEventArgs e)
        {
            Usuario elemento = (Usuario)e.Item;
            if (elemento != null)
            {
                bool falsacionador = true;
                if (tbIdUsuario.Text != "")
                    if (!elemento.IdUsuario.ToString().Contains(tbIdUsuario.Text))
                        falsacionador = false;
                if (tbUsuario.Text != "")
                    if (!elemento.User.ToUpper().Contains(tbUsuario.Text.ToUpper()))
                        falsacionador = false;
                if (tbNombre.Text != "")
                    if (!elemento.Nombre.ToUpper().Contains(tbNombre.Text.ToUpper()))
                        falsacionador = false;
                if (tbApellidos.Text != "")
                    if (!elemento.Apellidos.ToUpper().Contains(tbApellidos.Text.ToUpper()))
                        falsacionador = false;
                e.Accepted = falsacionador;
            }
        }
        /// <summary>
        /// Quita el filtro previo y aplica el nuevo
        /// </summary>
        private void Filtrar()
        {
            MiVista.Filter -= FiltrarUsuarios;
            MiVista.Filter += FiltrarUsuarios;
        }
        /// <summary>
        /// Manejador del evento TextChanged, en el textBox IdUsuario para filtrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbIdUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrar();
        }
        /// <summary>
        /// Manejador del evento TextChanged, en el textBox Usuario para filtrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrar();
        }
        /// <summary>
        /// Manejador del evento TextChanged, en el textBox Nombre para filtrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrar();
        }
        /// <summary>
        /// Manejador del evento TextChanged, en el textBox Apellidos para filtrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbApellidos_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrar();
        }

        private void bModificar_Click(object sender, RoutedEventArgs e)
        {
            if (MyListview.SelectedItem != null)
            {
                Usuario itemSeleccionado = (Usuario)MyListview.SelectedItem;
                if (insertarTarea)
                        tarea.MyUsuario = itemSeleccionado;
                else if(informe)
                    controlador.SetUsuarioInforme(itemSeleccionado);
                else
                {
                    InsertarUsuario vInsertarUser = new InsertarUsuario(controlador, itemSeleccionado);
                    vInsertarUser.Show();
                }
                this.Close();
            }
        }
    }
}
