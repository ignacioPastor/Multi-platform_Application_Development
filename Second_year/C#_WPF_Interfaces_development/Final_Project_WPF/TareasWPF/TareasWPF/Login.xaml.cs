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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Controlador controlador;
        int contadorLogin;
        /// <summary>
        /// Constructor vacío. Inicializa la conexión.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            controlador = new Controlador();
            contadorLogin = 0;
        }
        /// <summary>
        /// Control del evento Loaded de la ventana de Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //controlador.InsertarUsuarioPrueba();
        }
        /// <summary>
        /// Controlador del evento Click del botón cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Controlador del evento Click del botón aceptar
        /// Comprueba si el usuario y contraseña existen en la BD.
        /// Mantiene la lógica de que al tercer error se cierra el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAceptar_Click(object sender, RoutedEventArgs e)
        {
            VentanaInformativa vInfo;
            if (controlador.ComprobarLogin(tbUsuario.Text, tbContrasenya.Password))
            {
                MainWindow mWindow = new MainWindow(controlador);
                
                mWindow.Show();
                this.Close();
            }
            else
            {
                if(++contadorLogin >= 3)
                {
                    vInfo = new VentanaInformativa("Has agotado tus intentos.");
                    vInfo.ShowDialog();
                    this.Close();
                }
                else
                {
                    vInfo = new VentanaInformativa("Usuario o password incorrecto \n Te quedan " + (3 - contadorLogin) + " intentos.");
                    vInfo.ShowDialog();
                }
            }
        }
    }
}
