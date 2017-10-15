using CapaModelo;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para InsertarUsuario.xaml
    /// </summary>
    public partial class InsertarUsuario : Window
    {
        bool modificar;
        Usuario usuario;
        Controlador controlador;
        Brush myBorderColorDefault;
        bool bNombre, bMail, bApellidos, bUsuario, bPass, bTelefono,
            bDepartamento, bTipoUsuario, bGenero, bFechaNac;
        public InsertarUsuario()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos cuando vegamos de la ventana principal, para insertar un nuevo usuario.
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        public InsertarUsuario(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            bNombre = bApellidos = bMail = bUsuario = bPass = bTelefono
                = bDepartamento = bGenero = bTipoUsuario = bFechaNac = false;
            modificar = false;
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Lo utilizaremos cuando vengamos a modificar un usuario existente.
        /// </summary>
        /// <param name="controlador">Controlador de nuestro programa</param>
        /// <param name="usuario">Usuario a modificar</param>
        public InsertarUsuario(Controlador controlador, Usuario usuario)
        {
            InitializeComponent();
            this.controlador = controlador;
            this.usuario = usuario;
            modificar = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBorderColorDefault = tbNombre.BorderBrush;
            cbTipoUsuario.ItemsSource = controlador.GetTiposUsuario();
            cbGenero.ItemsSource = new string[2] { "M", "V" };
            cbDepartamento.ItemsSource = controlador.GetDepartamentos();
            if (modificar)
            {
                usuario.Contrasenya = "";
                myGrid.DataContext = usuario;
                
            }
        }
        /// <summary>
        /// Evento Click sobre el botón enviar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEnviar_Click(object sender, RoutedEventArgs e)
        {
            ValidarTodosLosCampos();
            MarcarCamposErroneosObligatorios();
            if (bUsuario && bPass && bTipoUsuario && bMail && bNombre && bApellidos && bDepartamento) //Si los campos obligatoris están bien...
            {
                string mensajeOk, result;
                if (modificar)
                {
                    result = controlador.ActualizarUsuario(usuario);
                    mensajeOk = "Usuario actualizado correctamente";
                }
                else
                {
                    result = controlador.InsertarNuevoUsuario(tbUsuario.Text, tbPassword.Text,
                    (string)cbTipoUsuario.SelectedItem, tbMail.Text, tbNombre.Text, tbApellidos.Text,
                    bFechaNac ? dpFechaNac.SelectedDate : null,
                    bGenero ? (string)cbGenero.SelectedItem : null,
                    bTelefono ? tbTelefono.Text : null,
                    (string)cbDepartamento.SelectedItem);
                    mensajeOk = "Usuario insertado correctamente.";
                }

                VentanaInformativa vInfo;
                if (result == "")
                {
                    vInfo = new VentanaInformativa(mensajeOk);
                    vInfo.ShowDialog();
                    controlador.CargarUsuarios();
                    this.Close();
                }
                else
                {
                    vInfo = new VentanaInformativa(result);
                    vInfo.ShowDialog();
                }
            }
            else    //Si había campos obligatorios no validados...
            {
                MarcarCamposErroneosObligatorios(); //Volvemos a validar los campos para que así queden marcados
                VentanaInformativa vInfo = new VentanaInformativa(GetInformeErrores(), true); //Informamos de los errores detalladamente
                vInfo.ShowDialog();
            }
        }
        private void ValidarTodosLosCampos()
        {
            tbTelefono_LostFocus(this, new RoutedEventArgs());
            tbPassword_LostFocus(this, new RoutedEventArgs());
            tbUsuario_LostFocus(this, new RoutedEventArgs());
            tbNombre_LostFocus(this, new RoutedEventArgs());
            tbMail_LostFocus(this, new RoutedEventArgs());
            ValidarGenero();
            ValidarFechaNac();
            ValidarTipoUsuario();
            ValidarDepartamento();
        }
        private void tbTelefono_LostFocus(object sender, RoutedEventArgs e)
        {
            int resultado = ValidarString(tbTelefono.Text, 15, true);
            if (bTelefono = (resultado == 0))
            {
                tbPassword.BorderBrush = myBorderColorDefault;
                tbPassword.ToolTip = null;
            }
            else
            {
                tbPassword.BorderBrush = Brushes.Red;
                tbPassword.ToolTip = "El límite son 32 caracteres";
            }
        }

        private void tbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            int resultado = ValidarString(tbPassword.Text, 60, false);
            if (bPass = (resultado == 0))
            {
                tbPassword.BorderBrush = myBorderColorDefault;
                tbPassword.ToolTip = null;
            }
            else if (resultado == 1)
            {
                tbPassword.BorderBrush = Brushes.Red;
                tbPassword.ToolTip = "El límite son 32 caracteres";
            }
            else if (resultado == 2)
            {
                tbPassword.BorderBrush = Brushes.Red;
                tbPassword.ToolTip = "El campo no puede quedar vacío";
            }
            
        }

        private void tbUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            int resultado = ValidarString(tbUsuario.Text, 60, false);
            if (bUsuario = (resultado == 0))
            {
                tbUsuario.BorderBrush = myBorderColorDefault;
                tbUsuario.ToolTip = null;
            }
            else if (resultado == 1)
            {
                tbUsuario.BorderBrush = Brushes.Red;
                tbUsuario.ToolTip = "El límite son 60 caracteres";
            }
            else if (resultado == 2)
            {
                tbUsuario.BorderBrush = Brushes.Red;
                tbUsuario.ToolTip = "El campo no puede quedar vacío";
            }
        }

        private void dpFechaNac_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidarFechaNac();
        }
        private void ValidarFechaNac()
        {
            bFechaNac = dpFechaNac.SelectedDate != null;
        }

        private void cbGenero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidarGenero();
        }
        private void ValidarGenero()
        {
            bGenero = (cbGenero.SelectedItem != null);
        }

        private void cbTipoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidarTipoUsuario();
        }
        private void ValidarTipoUsuario()
        {
            if (bTipoUsuario = (cbTipoUsuario.SelectedItem != null))
            {
                cbTipoUsuario.BorderBrush = Brushes.Red;
                cbTipoUsuario.ToolTip = "El campo no puede quedar vacío";
            }
            else
            {
                cbTipoUsuario.BorderBrush = myBorderColorDefault;
                cbTipoUsuario.ToolTip = null;
            }
        }

        private void cbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidarDepartamento();
        }
        private void ValidarDepartamento()
        {
            if (bDepartamento = (cbDepartamento.SelectedItem != null))
            {
                cbDepartamento.BorderBrush = Brushes.Red;
                cbDepartamento.ToolTip = "El campo no puede quedar vacío";
            }
            else
            {
                cbDepartamento.BorderBrush = myBorderColorDefault;
                cbDepartamento.ToolTip = null;
            }
        }

        private void tbNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            int resultado = ValidarString(tbNombre.Text, 100, false);
            if(bNombre = (resultado == 0))
            {
                tbNombre.BorderBrush = myBorderColorDefault;
                tbNombre.ToolTip = null;
            }else if(resultado == 1)
            {
                tbNombre.BorderBrush = Brushes.Red;
                tbNombre.ToolTip = "El límite son 100 caracteres";
            }else if(resultado == 2)
            {
                tbNombre.BorderBrush = Brushes.Red;
                tbNombre.ToolTip = "El campo no puede quedar vacío";
            }
        }

        private void tbApellidos_LostFocus(object sender, RoutedEventArgs e)
        {
            int resultado = ValidarString(tbApellidos.Text, 255, false);
            if (bApellidos = (resultado == 0))
            {
                tbApellidos.BorderBrush = myBorderColorDefault;
                tbApellidos.ToolTip = null;
            }
            else if (resultado == 1)
            {
                tbApellidos.BorderBrush = Brushes.Red;
                tbApellidos.ToolTip = "El límite son 255 caracteres";
            }
            else if (resultado == 2)
            {
                tbApellidos.BorderBrush = Brushes.Red;
                tbApellidos.ToolTip = "El campo no puede quedar vacío";
            }
            
        }

        private void tbMail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (bMail = ValidarCorreo(tbMail.Text))
            {
                tbMail.BorderBrush = myBorderColorDefault;
                tbApellidos.ToolTip = null;
            }
            else
            {
                tbMail.BorderBrush = Brushes.Red;
                tbMail.ToolTip = "No es un correo válido";
            }
        }
        /// <summary>
        /// Valida cadenas de texto, en funcion de que no superen una longitud maxima, o no sean null
        /// </summary>
        /// <param name="cadena">cadena de texto</param>
        /// <param name="longitudMaxima">longitud maxima permitida</param>
        /// <param name="nulo">false si null debe no validar</param>
        /// <returns>true si valida</returns>
        private int ValidarString(string cadena, int longitudMaxima, bool nulo)
        {
            int codigoError = 0;

            if (cadena.Length > longitudMaxima) codigoError = 1;
            if (cadena.Length < 1 && !nulo) codigoError = 2;

            return codigoError;
        }
        /// <summary>
        /// Valida el correo mediante expresiones regulares.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private bool ValidarCorreo(string cadena)
        {
            Regex r1 = new Regex(@"[a-zA-Z0-9]+@{1}[a-zA-Z0-9]+\.{1}[a-zA-Z0-9]+"); // Estructura general
            Regex r2 = new Regex(@"[\s]"); // Para asegurarnnos de que no contengas espacios

            return r1.IsMatch(cadena) && !r2.IsMatch(cadena);
        }
        /// <summary>
        /// Configura un mensaje de error detallado cuando se ha intentado enviar el formulario
        /// con campos obligatorios no validados.
        /// </summary>
        /// <returns>mensaje de error detallado</returns>
        private string GetInformeErrores()
        {
            string mensajeError = "Campos obligatorios no validados: \n \n";

            mensajeError += bUsuario ? "" : "El usuario no es válido\n";
            mensajeError += bPass ? "" : "El password no es válido\n";
            mensajeError += bTipoUsuario ? "" : "El tipo de usuario no ha sido seleccionado\n";
            mensajeError += bMail ? "" : "El mail no es válido\n";
            mensajeError += bNombre ? "" : "El nombre no es válido\n";
            mensajeError += bApellidos ? "" : "Los apellidos no son válidos\n";
            mensajeError += bDepartamento ? "" : "El departamento no ha sido seleccionado\n";

            return mensajeError;
        }
        /// <summary>
        /// Ejecuta las validaciones sobre los campos obligatorios.
        /// Lo utilizaremos para marcar los campos erróneos cuando el usuario ha intentado
        /// enviar el formulario teniendo todavía campos obligatorios no validados
        /// </summary>
        private void MarcarCamposErroneosObligatorios()
        {
            tbUsuario_LostFocus(null, null);
            tbPassword_LostFocus(null, null);
            cbTipoUsuario_SelectionChanged(null, null);
            tbMail_LostFocus(null, null);
            tbNombre_LostFocus(null, null);
            tbApellidos_LostFocus(null, null);
            cbDepartamento_SelectionChanged(null, null);
        }
        /// <summary>
        /// Intento de que el borde de color rojo no se vuelva a su color normal cuando se pasa el ratón por encima.
        /// No funciona. (Ahora solo está asignado al TextBox  del Nombre)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void MouseEnter(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if(tb.ToolTip != null)
            {
                tb.BorderBrush = Brushes.Red;
            }
        }
    }
}
