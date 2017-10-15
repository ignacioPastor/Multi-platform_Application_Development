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
    /// Lógica de interacción para RecabarDatosInforme.xaml
    /// </summary>
    public partial class RecabarDatosInforme : Window
    {
        Controlador controlador;
        Usuario usuarioInforme;
        int mes;
        int anyo;
        Dictionary<TextBlock, Tarea> dictionaryRegisto;
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public RecabarDatosInforme()
        {
            InitializeComponent();
            mes = -1;
            anyo = 0;
            dictionaryRegisto = new Dictionary<TextBlock, Tarea>();
            usuarioInforme = new Usuario();
            controlador = new Controlador();
        }
        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        public RecabarDatosInforme(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            mes = -1;
        }
        /// <summary>
        /// Controlador del evento ventana cargada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbMeses.ItemsSource = new ObservableCollection<string>() { "Enero", "Febrero", "Marzo",
                "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            cbAnyo.ItemsSource = new ObservableCollection<int>() { DateTime.Now.Year - 2, DateTime.Now.Year - 1,
                DateTime.Now.Year, DateTime.Now.Year + 1, DateTime.Now.Year + 2 };
            cbAnyo.SelectedIndex = 2;
            //usuarioInforme = new Usuario();
        }
        /// <summary>
        /// Controlador del evento Click del Button "Seleccionar Usuario"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bUsuario_Click(object sender, RoutedEventArgs e)
        {
            ListarModificarUsuario vSeleccionarUsuario = new ListarModificarUsuario(controlador, usuarioInforme);
            vSeleccionarUsuario.ShowDialog();
            usuarioInforme = controlador.GetUsuarioInforme();
            tbIdUsuario.Text = usuarioInforme.IdUsuario.ToString();
            tbNombre.Text = usuarioInforme.Nombre;
            ComprobarMostrar();
        }
        /// <summary>
        /// Comprueba que haya un mes seleccionado y un usuario seleccionado.
        /// Si es así, inicia la visualización del informe
        /// </summary>
        private void ComprobarMostrar()
        {
            if(usuarioInforme != null && mes != -1)
                LanzarVisualizacion();
        }
        /// <summary>
        /// Controlador del evento SelectionChanged del combobox de elegir Mes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMeses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mes = cbMeses.SelectedIndex + 1;
            ComprobarMostrar();
        }
        /// <summary>
        /// Gestiona toda la lógica para generar y mostrar el informe.
        /// Hay un grid de 7x5, según el mes y año escogido, colocaremos un ListView en cada casilla que corresponda a un día.
        /// En el ListView cargaremos textBlocks con la información, en todos con la fecha de ese día, y en los que tengan tareas, 
        /// tantos textBlock como tareas tengan.
        /// </summary>
        private void LanzarVisualizacion()
        {
            gridCalendario.Children.Clear();        //Borramos los hijos del grid, por si hay un informe previo, limpiarlo.
            List<Tarea> listaTareasDia;
            ObservableCollection<TextBlock> obColeccion;    //El listView lo poblaremos con una ObservableCollection de TextBlock
            TextBlock tb;
            ListView lv;
            DateTime d;
            int dia_sem;
            int dias_mes = DateTime.DaysInMonth(anyo, mes); // Obtiene el número de días que tiene un mes dado el mes y el año
            d = new DateTime((int)cbAnyo.SelectedValue, mes, 1);
            int row = 0;
            dictionaryRegisto = new Dictionary<TextBlock, Tarea>(); //Guardaremos el textBlock que muestra la info de la tarea junto a la Tarea
                                                                    // para así poder acceder a la tarea cuando se pinch el textBlock
            for (int i = 0; i < dias_mes; i++)  //Recorremos todos los días del mes
            {
                if (i != 0)     //A cada iteración, salvo en la primera, aumentaremos un día la fecha
                 d = d.AddDays(1);
                //Obtenemos el número de día de la semana que es el día de esta iteración
                dia_sem = (int)d.DayOfWeek; //El lunes es el 1 (toca corregir porque en el grid el Lunes es el 0)
                lv = new ListView();
                gridCalendario.Children.Add(lv);   //Añadimos el ListView como hijo del GridCalendario, y después lo ubicamos en Column y Row
                lv.SetValue(Grid.RowProperty, row);    //Ubicamos el ListView en el Row correspondiente
                lv.SetValue(Grid.ColumnProperty, dia_sem == 0 ? 6 : dia_sem - 1); //Lunes = 1, pero van en el colum = 0, y Dom = 0 pero van en el colum = 6
                row += dia_sem == 0 ? 1 : 0; // Si llegamos al domingo, bajamos al row siguiente (cara a la siguiente iteración)
                
                listaTareasDia = controlador.GetTareasEnDia(usuarioInforme, d); // Consultamos la BD y nos traemos una lista con las tareas
                                                                            // que tiene el usuario seleccionado para este día
                tb = new TextBlock();
                tb.Text = "     " + d.ToShortDateString() + "     "; // Primero introducimos la fecha del día en cada ListView
                tb.Background = Brushes.CadetBlue;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                obColeccion = new ObservableCollection<TextBlock>() { tb };  //Añadimos la fecha al ListView

                lv.ItemsSource = obColeccion;   //Asignamos la colección que poblará el ListView
                lv.MouseDoubleClick += new MouseButtonEventHandler(Tarea_DobleClick);   //Creamos un manejador del evento DobleClick
                if (listaTareasDia.Count > 0)   //Si este día el usuario tiene tareas...
                {
                    foreach (Tarea t in listaTareasDia)     
                    {
                        tb = new TextBlock();
                        tb.Text = t.Nombre + " - " + t.FechaAlta.Value.ToString("hh:mm");   //Para cada tarea extraemos su nombre, y hora.
                        if (t.Urgente)      //Si la tarea es urgente coloreamos de rojo el text block que muestra su información
                        {
                            tb.Foreground = Brushes.Red;
                        }//End if tarea es urgente
                        dictionaryRegisto.Add(tb, t);   //Almacenamos en un dictionary el textBlock con la información de la tarea y la Tarea
                        obColeccion.Add(tb);    //Añadimos el textBlock a la colección que puebla el ListView
                    }
                }//End if usuario tiene tareas ese día
            }//End for cada día del mes

            //Mostramos el nombre de cada día de la semana en la parte superior del Grid
            tbLunes.Text =     "          LUNES           ";
            tbMartes.Text =    "          MARTES        ";
            tbMiercoles.Text = "      MIERCOLES       ";
            tbJueves.Text =    "         JUEVES         ";
            tbViernes.Text =   "        VIERNES         ";
            tbSabado.Text =    "         SABADO        ";
            tbDomingo.Text =   "      DOMINGO       ";
            
            tbLunes.Background  = tbMartes.Background = tbMiercoles.Background = tbJueves.Background = tbViernes.Background =
                 tbSabado.Background = tbDomingo.Background = Brushes.BurlyWood;
        }//End funcion
        /// <summary>
        /// Maneja el evento dobleClick sobre el ListView de cada día del informe.
        /// Accede al item seleccionado en el ListView, que es un textBlock.
        /// Busca en el dictionary el valor (Tarea) asociada a ese TextBlock, y recupera la tarea.
        /// Mostramos esa tarea.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Tarea_DobleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Tarea t = dictionaryRegisto[(TextBlock)((ListView)sender).SelectedItem];
                InsertarTarea vMostrarTarea = new InsertarTarea(controlador, t);
                vMostrarTarea.ShowDialog();
            }
            catch (Exception) { }//Caso de que se haga doble click sobre el textBlock que contiene la fecha, lanza una excepción. Lo ignoramos
        }
        /// <summary>
        /// Manejador del evento selectionChanged para el combobox del año.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAnyo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAnyo.SelectedIndex != -1)
                anyo = (int)cbAnyo.SelectedValue;
        }
    }
}
