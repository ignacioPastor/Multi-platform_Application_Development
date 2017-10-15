using CapaModelo;
using CapaNegocio;
using CapaVista;
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
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace TareasWPF
{
    /// <summary>
    /// Lógica de interacción para InsertarTarea.xaml
    /// </summary>
    public partial class InsertarTarea : Window
    {
        bool primera = true;
        bool usuarioSeleccionado;
        bool proyectoSeleccionado;
        private int _noOfErrorsOnScreen = 0;
        Controlador controlador;
        Tarea tarea;
        bool alta;
        DataTable tableTarea;

        /// <summary>
        /// Constructor vacío
        /// </summary>
        public InsertarTarea()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos cuando vengamos desde la ventana principal (Alta tarea)
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        public InsertarTarea(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            tarea = new Tarea();
            alta = true;
        }
        /// <summary>
        /// Constructor sobrecargado
        /// Lo utilizaremos cuando vengamos de listar tareas, para modificar la seleccionada.
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        /// <param name="tareaModificar">Tarea a modificar</param>
        public InsertarTarea(Controlador controlador, Tarea tarea)
        {
            InitializeComponent();
            this.controlador = controlador;
            this.tarea = tarea;
            alta = false;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            controlador.CargarDatosDataset();
            cbTipoTarea.ItemsSource = controlador.GetTiposTarea(); //Cargamos el combobox con una select ;)
            cbTipoTarea.SelectedIndex = 0;

            tbErrorUsuario.Foreground = tbErrorProyecto.Foreground = tbErrorComboTipo.Foreground = Brushes.Red;
            tbErrorUsuario.FontSize = tbErrorProyecto.FontSize = tbErrorComboTipo.FontSize = 20;
            tbErrorUsuario.FontWeight = tbErrorProyecto.FontWeight = tbErrorComboTipo.FontWeight = FontWeights.ExtraBold;
            
            MyGridTareas.DataContext = tarea;
            GestionarHabilitadoAviso();
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //Los campos obligatorios y más delicados los validaremos también mediante la clase Validator para validar el formulario
            // cuando se carga, antes de que el usuario modifique los campos (LostFocus)
            Validator.IsValid(tbDescripcion);
            Validator.IsValid(tbDuracionReal);
            Validator.IsValid(tbComentarios);
            //Tengo que evitar la validación primera porque lanza una excepción de que tbErrorUsuario y tbErrorProyecto son Nullreference
            if (primera)
                e.Handled = primera = false;
            else
            {
                Validator.IsValid(cbTipoTarea); //Se producía una validación errónea para estos campos en la primera validación, así que la evitamos
                Validator.IsValid(tbNombreTarea);
                //En esta parte validamos que se haya seleccionado un usuario y un proyecto para la tarea, y la lógica de informe de dicho error
                if (tbNombreUsuario == null || tbNombreUsuario.Text == "" || tbNombreProyecto == null || tbNombreProyecto.Text == "")
                {
                    if (tbNombreUsuario == null || tbNombreUsuario.Text == "")
                        IndicarErrorUsuario();
                    else
                        EliminarErrorUsuario();
                    if (tbNombreProyecto == null || tbNombreProyecto.Text == "")
                        IndicarErrorProyecto();
                    else
                        EliminarErrorProyecto();
                    e.Handled = usuarioSeleccionado && proyectoSeleccionado;
                }
                else
                {
                    EliminarErrorProyecto();
                    EliminarErrorUsuario();
                    e.CanExecute = _noOfErrorsOnScreen == 0;
                    e.Handled = true;
                }
                if (!Validator.IsValid(cbTipoTarea))
                {
                    cbTipoTarea.ToolTip = tbErrorComboTipo.ToolTip = "Debe seleccionar una de las opciones";
                    tbErrorComboTipo.Visibility = Visibility.Visible;
                }
                else
                {
                    cbTipoTarea.ToolTip = tbErrorComboTipo.ToolTip = null;
                    tbErrorComboTipo.Visibility = Visibility.Hidden;
                }
            }
        }
        private void IndicarErrorUsuario()
        {
            bUsuario.ToolTip = tbDatosUsuario.ToolTip = tbErrorUsuario.ToolTip = "Debes seleccionar un Usuario.";
            tbErrorUsuario.Text = "!";
            tbDatosUsuario.Foreground = bUsuario.BorderBrush = Brushes.Red;
            usuarioSeleccionado = false;
        }
        private void IndicarErrorProyecto()
        {
            bProyecto.ToolTip = tbDatosProyecto.ToolTip = tbErrorProyecto.ToolTip = "Debes seleccionar un Proyecto.";
            proyectoSeleccionado = false;
            tbErrorProyecto.Text = "!";
            tbDatosProyecto.Foreground = bProyecto.BorderBrush = Brushes.Red;
        }
        private void EliminarErrorUsuario()
        {
            bUsuario.ToolTip = tbDatosUsuario.ToolTip = tbErrorUsuario.ToolTip = null;
            tbDatosUsuario.Background = Brushes.White;
            tbErrorUsuario.Text = "";
            usuarioSeleccionado = true;
            tbDatosUsuario.Foreground = bUsuario.BorderBrush = Brushes.Black;
        }
        private void EliminarErrorProyecto()
        {
            bProyecto.ToolTip = tbDatosProyecto.ToolTip = tbErrorProyecto.ToolTip = null;
            tbDatosProyecto.Background = Brushes.White;
            proyectoSeleccionado = true;
            tbErrorProyecto.Text = "";
            tbDatosProyecto.Foreground = bProyecto.BorderBrush = Brushes.Black;
        }
        /// <summary>
        /// Evento que se genera cuando pulsamos el botón de enviar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataRow tareaRow;
            controlador.CargarDatosDataset();
            tareaRow = controlador.GetDataTable("tareas").NewRow();
            tableTarea = controlador.GetDataTable("tareas");
            
            tarea = MyGridTareas.DataContext as Tarea; //Esto no sé si hace falta :s

            if(alta)    //Si estamos insertando una nueva tarea la añadimos al dataSet
            {
                tableTarea.Rows.Add(tareaRow); //Añadimos un DataRow nuevo al dataset
                AsignarValoresTarea(tareaRow); //Poblamos ese dataRow con los datos de la tarea a insertar
            }
            else    //Si estamos modificando una tarea, la identificamos en el DataSet, y le damos los nuevos valores (a la del dataset)
            {
                DataRow[] result = controlador.GetDataTable("tareas").Select("id_tarea = " + tarea.IdTarea); //Buscamos la tarea que estamos modificando
                tareaRow = result[0]; 
                AsignarValoresTarea(tareaRow);
            }
            string mensaje = "";
            try
            {
                mensaje = controlador.GuardarDatosEnBD("tareas");
            }catch(Exception ex) { mensaje = ex.Message; }
            controlador.CargarDatosDataset(); //Cargamos de nuevo el DataSet para mantener la consistencia entre el dataSet y la BD
                                            // nos permite además tener el Id_Tarea de la tarea insertada, ya que se asigna en la BD
            LanzarVentanaInformativa(mensaje);
            this.Close();
        }
        /// <summary>
        /// Copia los datos del objeto Tarea con el que estamos trabajando en un DataRow
        /// </summary>
        /// <param name="tareaRow">DataRow que contrendrá la información de nuestra tarea. Será lo que insertemos en el dataSet</param>
        private void AsignarValoresTarea(DataRow tareaRow)
        {
            
            tareaRow["id_tarea"] = 0;

            tareaRow["nombre"] = tarea.Nombre;
            tareaRow["descripcion"] = tarea.Descripcion;
            tareaRow["fecha_alta"] = tarea.FechaAlta;
            tareaRow["duracion"] = tarea.DuracionEstimada;
            tareaRow["cod_tarea"] = tarea.Tipo;
            tareaRow["urgente"] = tarea.Urgente;
            tareaRow["id_usuario"] = tarea.MyUsuario.IdUsuario;
            tareaRow["id_proyecto"] = tarea.MyProyecto.IdProyecto;
            tareaRow["duracion_real"] = tarea.DuracionReal;
            tareaRow["aviso"] = tarea.Aviso;

            if (tarea.CuandoAvisar == null)
            {
                tareaRow["cuando_avisar"] = DBNull.Value;
            }
            else
                tareaRow["cuando_avisar"] = tarea.CuandoAvisar.Value;

            tareaRow["terminada"] = tarea.Terminada;
            tareaRow["comentarios"] = tarea.Comentarios;
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        private void bSeleccionarUsuario_Click(object sender, RoutedEventArgs e)
        {
            ListarModificarUsuario vSeleccionarUsuario = new ListarModificarUsuario(controlador, tarea);
            vSeleccionarUsuario.ShowDialog();
            MyGridTareas.DataContext = null;
            MyGridTareas.DataContext = tarea;
        }

        private void bSeleccionarProyecto_Click(object sender, RoutedEventArgs e)
        {
            ListarProyectos vSeleccionarProyecto = new ListarProyectos(controlador, tarea);
            vSeleccionarProyecto.ShowDialog();
            MyGridTareas.DataContext = null;
            MyGridTareas.DataContext = tarea;
        }
        private void LanzarVentanaInformativa(string message)
        {
            VentanaInformativa myVentanaInformativa = new VentanaInformativa(message);
            myVentanaInformativa.Owner = this;
            myVentanaInformativa.ShowDialog();
        }

        private void chbAviso_Click(object sender, RoutedEventArgs e)
        {
            GestionarHabilitadoAviso();
        }
        private void GestionarHabilitadoAviso()
        {
            if (tarea.Aviso == true)
                dpCUandoAvisar.IsEnabled = true;
            else
            {
                dpCUandoAvisar.Value = null;
                tarea.CuandoAvisar = null;
                dpCUandoAvisar.IsEnabled = false;
            }
        }
    }
}
