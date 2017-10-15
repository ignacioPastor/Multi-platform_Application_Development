using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apellidos_Nombre_Validar
{
    public partial class    Form1 : Form
    {
        private bool nombreValido;
        private bool apellidosValido;
        private bool telefonoValido;
        private bool nickValido;
        private bool contrasenyaValida;
        private bool confirmarContrasenyaValido;
        private bool titularValido;
        private bool correoValido;
        private bool nifValido;
        private bool ibanValido;
        private bool entidadValida;
        private bool oficinaValida;
        private bool dcValido;
        private bool cuentaValida;
        private bool tarjetaValida;
        private bool conformidadActivada;
        private bool diaNacimiento;
        private bool mesNacimiento;
        private bool anyoNacimiento;
        private bool fechaValida;
        private bool nacionalidadCompletada;
        
        public Form1()
        {
            InitializeComponent();
            nombreValido = false;
            apellidosValido = false;
            telefonoValido = false;
            nickValido = false;
            contrasenyaValida = false;
            confirmarContrasenyaValido = false;
            titularValido = false;
            correoValido = false;
            nifValido = false;
            ibanValido = false;
            entidadValida = false;
            oficinaValida = false;
            dcValido = false;
            cuentaValida = false;
            tarjetaValida = false;
            conformidadActivada = false;
            diaNacimiento = false;
            mesNacimiento = false;
            anyoNacimiento = false;
            fechaValida = false;
            nacionalidadCompletada = false;
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
        /// Valida numeros de telefono
        /// </summary>
        /// <param name="n"> cadena con el numero de telefono</param>
        /// <returns>true si es del tipo +NN-NNNNNNNNN</returns>
        private bool ValidarTelefono(string n)
        {
            Regex reg = new Regex(@"\A\+\d{2}\-\d{9}\z");
            if (reg.IsMatch(n))
                return true;
            return false;
        }
        /// <summary>
        /// Gestiona la notificación de error sobre un apartado que no cumple los requisitos de validación
        /// </summary>
        /// <param name="pControl">control sobre el que estamos trabajando</param>
        /// <param name="cadenaErrores">cadena de texto con el mensaje a mostrar</param>
        private void IndicarError(Control pControl, String cadenaErrores)
        {
            ToolTip TTIP = new ToolTip();
            pControl.BackColor = Color.LightCoral;
            TTIP.Active = true;
            TTIP.SetToolTip(pControl, cadenaErrores);
        }
        /// <summary>
        /// Gestiona la comunicación de que un apartado ha sido validado correctamente
        /// </summary>
        /// <param name="pControl"> control que estamos trabajado</param>
        private void IndicarOK(Control pControl)
        {
            ToolTip TTIP = new ToolTip();
            pControl.BackColor = Color.LightGreen;
            TTIP.SetToolTip(pControl, "");
            TTIP.Active = false;
        }
        /// <summary>
        /// Manejador del evento Leave sobre el campo tbNombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbNombre_Leave(object sender, EventArgs e)
        {
            String cadenaErrores = "";
            int resultado = 0;
            resultado = ValidarString(tbNombre.Text, 100, false);
            if (resultado > 0)
            {
                switch (resultado)
                {
                    case 1:
                        cadenaErrores = "El campo Nombre no permite más de 100 carácteres" + Environment.NewLine;
                        break;
                    case 2:
                        cadenaErrores = "El campo Nombre no puede estar vacío" + Environment.NewLine;
                        break;
                }
                IndicarError(tbNombre, cadenaErrores);
                nombreValido = false;
            }
            else
            {
                IndicarOK(tbNombre);
                nombreValido = true;
            }
        }
        private void tbApellidos_Leave(object sender, EventArgs e)
        {
            String cadenaErrores = "";
            int resultado = 0;
            cadenaErrores = "";
            resultado = 0;
            resultado = ValidarString(tbApellidos.Text, 255, true);
            if (resultado > 0)
            {
                switch (resultado)
                {
                    case 1:
                        cadenaErrores = "El campo Apellidos no permite más de 255 carácteres" + Environment.NewLine;
                        break;
                    case 2:
                        cadenaErrores = "El campo Apellidos no puede estar vacío" + Environment.NewLine;
                        break;
                }
                IndicarError(tbApellidos, cadenaErrores);
                apellidosValido = false;
            }
            else
            {
                IndicarOK(tbApellidos);
                apellidosValido = true;
            }
        }
        private void tbTelefono_Leave(object sender, EventArgs e)
        {
            telefonoValido = ValidarTelefono(tbTelefono.Text);
            if(telefonoValido)
                IndicarOK(tbTelefono);
            else
                IndicarError(tbTelefono, "El formato debe ser \"+NN-NNNNNNNNN\" ");
        }
        private void tbNick_Leave(object sender, EventArgs e)
        {
            string cadenaErrores = "";
            int resultado = 0;
            resultado = ValidarString(tbNick.Text, 25, false);
            if (resultado > 0)
            {
                switch (resultado)
                {
                    case 1:
                        cadenaErrores = "El campo Nick no permite más de 25 carácteres" + Environment.NewLine;
                        break;
                    case 2:
                        cadenaErrores = "El campo Nick no puede estar vacío" + Environment.NewLine;
                        break;
                }
                IndicarError(tbNick, cadenaErrores);
                nickValido = false;
            }
            else
            {
                IndicarOK(tbNick);
                nickValido = true;
            }
        }
        private void tbPassword_Leave(object sender, EventArgs e)
        {
            string resultado = ValidarContrasenya(tbPassword.Text);
            if(resultado == "ok")
            {
                IndicarOK(tbPassword);
                contrasenyaValida = true;
            }
            else
            {
                IndicarError(tbPassword, resultado);
                contrasenyaValida = false;
            }
        }
        private void tbConfirmarPassword_Leave(object sender, EventArgs e)
        {
            if (TextosIguales())
            {
                IndicarOK(tbConfirmarPassword);
                confirmarContrasenyaValido = true;
            }
            else
            {
                confirmarContrasenyaValido = false;
                IndicarError(tbConfirmarPassword, "La contraseña y la confirmación de la contraseña no coinciden");
            }
        }

        public bool TextosIguales()
        {
            try
            {
                if (tbConfirmarPassword.Text == tbPassword.Text)
                    return true;
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Gestiona la validación de la contraseña
        /// Lo hace en tres pasos distintos para poder enviar un mensaje de error específico en caso
        /// de que se cumplan los requisitos de validación.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private string ValidarContrasenya(string cadena)
        {
            //Iremos construyendo el mensaje de error a lo largo del método, según proceda informar
            string indicaciones = "La contraseña debe contener al menos ";
            int contador = 0;
            Regex r1 = new Regex("[a-z]+"); // Que tenga una minúscula
            Regex r2 = new Regex("[A-Z]+"); // Que tenga una mayúscula
            Regex r3 = new Regex("[0-9]+"); // Que tenga un número

            if (!r1.IsMatch(cadena)) 
            {
                indicaciones += " una minúscula";
                contador++;
            }
            if (!r2.IsMatch(cadena))
            {
                if (contador != 0)
                    indicaciones += ", ";
                indicaciones += " una mayúscula";
                contador++;
            }
            if(!r3.IsMatch(cadena))
            {
                if (contador != 0)
                    indicaciones += ", ";
                indicaciones += " un número";
            }
            if (contador == 0)
                indicaciones = "ok";
            if(contador > 1)
            {
                // Pulimos la construcción del mensaje de error asegurando que en la enumeración de los errores
                // la última enumeración va antecedida por una "y" y no por una coma
                int posUltimaComa = indicaciones.LastIndexOf(",");
                indicaciones = indicaciones.Remove(posUltimaComa, 1);
                indicaciones = indicaciones.Insert(posUltimaComa, " y");
            }
            return indicaciones;
        }
        
        private void tbTitular_Leave(object sender, EventArgs e)
        {
            if(ValidarString(tbTitular.Text, 255, false) == 0 && ValidarMayusculas(tbTitular.Text))
            {
                IndicarOK(tbTitular);
                titularValido = true;
            }
            else
            {
                IndicarError(tbTitular, "El titular debe intoducirse en mayúsculas");
                titularValido = false;
            }
        }
        private bool ValidarMayusculas(string cadena)
        {
            return cadena == cadena.ToUpper();
        }

        private void tbCorreo_Leave(object sender, EventArgs e)
        {
            if(ValidarCorreo(tbCorreo.Text))
            {
                IndicarOK(tbCorreo);
                correoValido = true;
            }
            else
            {
                IndicarError(tbCorreo, "No es un correo válido");
                correoValido = false;
            }
        }
        /// <summary>
        /// Valida el correo mediante expresiones regulares.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private bool ValidarCorreo(string cadena)
        {
            Regex r1 = new Regex(@"[a-zA-Z0-9]+@{1}[a-z]+\.{1}[a-z]+"); // Estructura general
            Regex r2 = new Regex(@"[\s]"); // Para asegurarnnos de que no contengas espacios

            return r1.IsMatch(cadena) && !r2.IsMatch(cadena);
        }
        private void tbNif_Leave(object sender, EventArgs e)
        {
            int resultado = ValidarNif(tbNif.Text);
            if(resultado == 0)
            {
                IndicarOK(tbNif);
                nifValido = true;
            }
            else
            {
                string cadenaError = "";
                switch(resultado)
                {
                    case 1: cadenaError = "El NIF debe componerse de 9 caracteres"; break;
                    case 2: cadenaError = "Los caracteres del NIF deben estar en mayúsculas"; break;
                    case 3: cadenaError = "El dígito de control no corresponde con el número"; break;
                    default: cadenaError = "NIF no válido"; break;
                }
                IndicarError(tbNif, cadenaError);
                nifValido = false;
            }
        }
        /// <summary>
        /// Primera función específica de la validación del dni.
        /// Comprueba que la extensión sea correcta, que las letras estén en mayúsculas
        /// y mira si el primer carácter es número o letra, para distinguir entre nifNacional y extranjero
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private int ValidarNif(string cadena)
        {
            if (cadena.Length != 9)
                return 1;
            if (cadena != cadena.ToUpper())
                return 2;
            if (EsNumero(cadena[0].ToString()))
                return ValidarNifNacional(cadena);
            else
                return ValidarNifExtranjero(cadena);
        }
        private int ValidarNifNacional(string cadena)
        {
            string letra = cadena.Substring(8);
            int numero = Convert.ToInt32(cadena.Remove(8));
            int resto = numero % 23;
            string[] tabla = new string[23] {"T","R","W","A","G","M","Y","F","P","D","X","B",
                                                "N","J","Z","S","Q","V","H","L","C","K","E"};
            if (cadena[8].ToString() == tabla[resto])
                return 0;
            else
                return 3;
        }
        private int ValidarNifExtranjero(string cadena)
        {
            switch (cadena[0].ToString())
            {
                case "X":
                    cadena = cadena.Remove(0, 1);
                    cadena = "0" + cadena;
                    break;
                case "Y":
                    cadena = cadena.Remove(0, 1);
                    cadena = "1" + cadena;
                    break;
                case "Z":
                    cadena = cadena.Remove(0, 1);
                    cadena = "2" + cadena;
                    break;
                default:
                    break;
            }
            return ValidarNifNacional(cadena);
        }
        private bool EsNumero(string cadena)
        {
            Regex r = new Regex("[^0-9]");
            return !r.IsMatch(cadena);
        }
        /// <summary>
        /// Valida el Iban.
        /// Para los datos bancarios, al final siempre comprobaremos si el resto de datos que no son el DC se han validado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbIban_Leave(object sender, EventArgs e)
        {
            string resultado = ValidarIban(tbIban.Text);
            if(resultado == "ok")
            {
                IndicarOK(tbIban);
                ibanValido = true;
            }
            else
            {
                IndicarError(tbIban, resultado);
                ibanValido = false;
            }
            ComprobarDatosBancariosCompletados();
        }
        private string ValidarIban(string cadena)
        {
            if (cadena.Length != 4)
                return "El IBAN debe componerse de 4 caracteres";
            if (!EsLetra(cadena.Substring(0, 2)))
                return "Los dos primeros caracteres del IBAN deben ser letras";
            if (cadena.Substring(0, 2) != cadena.Substring(0, 2).ToUpper())
                return "Las letras deben introducirse en mayúsculas";
            if (!EsNumero(cadena.Substring(2, 1)) || !EsNumero(cadena.Substring(2, 1)))
                return "Los dos últimos caracteres deben ser números";
            return "ok";
        }
        private bool EsLetra(String cadena)
        {
            Regex r = new Regex("[^a-zA-Z]");
            return !r.IsMatch(cadena);
        }

        private void tbEntidad_Leave(object sender, EventArgs e)
        {
            if(EsNumero(tbEntidad.Text) && tbEntidad.Text.Length == 4)
            {
                IndicarOK(tbEntidad);
                entidadValida = true;
            }
            else
            {
                IndicarError(tbEntidad, "La entidad debe componerse de cuatro números");
                entidadValida = false;
            }
            ComprobarDatosBancariosCompletados();
        }

        private void tbOficina_Leave(object sender, EventArgs e)
        {
            if (EsNumero(tbOficina.Text) && tbOficina.Text.Length == 4)
            {
                IndicarOK(tbOficina);
                oficinaValida = true;
            }
            else
            {
                IndicarError(tbOficina, "La oficina debe componerse por cuatro números");
                oficinaValida = false;
            }
            ComprobarDatosBancariosCompletados();
        }

        private void tbDC_Leave(object sender, EventArgs e)
        {
            if (EsNumero(tbDC.Text) && tbDC.Text.Length == 2)
            {
                ComprobarDatosBancariosCompletados();
                tbDC.BackColor = Color.Empty;
            }
            else
            {
                IndicarError(tbDC, "El Dígito de Control debe componerse por 2 números");
                dcValido = false;
            }
        }
        /// <summary>
        /// Gestiona el cálculo del DC, comprobando que el resto de datos son correctos, 
        /// y que los dos DC son correctos
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private string CalcularDC(string cadena)
        {
            if (ibanValido && entidadValida && oficinaValida && cuentaValida)
            {
                if (CalculoPrimerDC(cadena) && CalculoSegundoDC(cadena))
                    return "ok";
                else
                    return "DC no concuerda con el algoritmo de validación, compruebe que lo ha introducido correctamente";
            }
            else
                return "Debe rellenar todo los campos correctamente para poder comprobar la validez del DC";
        }
        private bool CalculoPrimerDC(string cadena)
        {
            int resto = (Convert.ToInt32(tbEntidad.Text[0].ToString()) * 4
                + Convert.ToInt32(tbEntidad.Text[1].ToString()) * 8
                + Convert.ToInt32(tbEntidad.Text[2].ToString()) * 5
                + Convert.ToInt32(tbEntidad.Text[3].ToString()) * 10
                + Convert.ToInt32(tbOficina.Text[0].ToString()) * 9
                + Convert.ToInt32(tbOficina.Text[1].ToString()) * 7
                + Convert.ToInt32(tbOficina.Text[2].ToString()) * 3
                + Convert.ToInt32(tbOficina.Text[3].ToString()) * 6) % 11;
            int dc = 11 - resto;
            if (dc == 10)
                dc = 1;
            int n = Convert.ToInt32(cadena[0].ToString());
            return  n == dc;
        }
        private bool CalculoSegundoDC(string cadena)
        {
            int resto = (Convert.ToInt32(tbCuenta.Text[0].ToString()) * 1
                + Convert.ToInt32(tbCuenta.Text[1].ToString()) * 2
                + Convert.ToInt32(tbCuenta.Text[2].ToString()) * 4
                + Convert.ToInt32(tbCuenta.Text[3].ToString()) * 8
                + Convert.ToInt32(tbCuenta.Text[4].ToString()) * 5
                + Convert.ToInt32(tbCuenta.Text[5].ToString()) * 10
                + Convert.ToInt32(tbCuenta.Text[6].ToString()) * 9
                + Convert.ToInt32(tbCuenta.Text[7].ToString()) * 7
                + Convert.ToInt32(tbCuenta.Text[8].ToString()) * 3
                + Convert.ToInt32(tbCuenta.Text[9].ToString()) * 6) % 11;
            int dc = 11 - resto;
            if (dc == 10)
                dc = 1;
            return Convert.ToInt32(cadena[1].ToString()) == dc;
        }

        private void tbCuenta_Leave(object sender, EventArgs e)
        {
            if (EsNumero(tbCuenta.Text) && tbCuenta.Text.Length == 10)
            {
                IndicarOK(tbCuenta);
                cuentaValida = true;
            }
            else
            {
                IndicarError(tbCuenta, "La cuenta debe componerse por diez números");
                cuentaValida = false;
            }
            ComprobarDatosBancariosCompletados();
        }
        /// <summary>
        /// El primer paso de validación del DC es comprobar que el resto de campos del IBAN
        /// se han rellenado  y validado correctamente.
        /// Después calculamos el DC y comprobamos si coincide con el que nos introduce el usuario
        /// </summary>
        private void ComprobarDatosBancariosCompletados()
        {
            if(ibanValido && entidadValida && oficinaValida && cuentaValida)
            {
                if (EsNumero(tbDC.Text) && tbDC.Text.Length == 2)
                {
                    string resultado = CalcularDC(tbDC.Text);
                    if (resultado == "ok")
                    {
                        IndicarOK(tbDC);
                        dcValido = true;
                    }
                    else
                    {
                        IndicarError(tbDC, resultado);
                        dcValido = false;
                    }
                }
            }
        }
        private void mtbTarjeta_Leave(object sender, EventArgs e)
        {
            if(mtbTarjeta.Text.Length >= 10)
            {
                tarjetaValida = true;
                IndicarOK(mtbTarjeta);
            }
            else
            {
                tarjetaValida = false;
                IndicarError(mtbTarjeta, "Formato incorrecto, debe ser LLNNNNNLLL +2 letras opcionalmente");
            }
        }

        private void cbConformidad_Change(object sender, EventArgs e)
        {
            if(cbConformidad.Checked)
                conformidadActivada = true;
            else
                conformidadActivada = false;
        }
        /// <summary>
        /// Pone a true la variable diaNacimiento, y false si no se selecciona ningún item
        /// Al final comprueba si el resto de datos de la fecha de nacimiento se han completado correctamente
        /// para así iniciar la validación del conjunto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDiaNacimiento_Change(object sender, EventArgs e)
        {
            if (cbDiaNacimiento.SelectedIndex != -1)
                diaNacimiento = true;
            else
                diaNacimiento = false;
            ComprobarFechaCompleta();
        }
        private void cbMesNacimiento_Change(object sender, EventArgs e)
        {
            if (cbMesNacimiento.SelectedIndex != -1)
                mesNacimiento = true;
            else
                mesNacimiento = false;
            ComprobarFechaCompleta();
        }
        private void cbAnyoNacimiento_Change(object sender, EventArgs e)
        {
            if (cbAnyoNacimiento.SelectedIndex != -1)
                anyoNacimiento = true;
            else
                anyoNacimiento = false;
            ComprobarFechaCompleta();
        }
        /// <summary>
        /// Comprueba que todos los campos de fechaNacimiento han sido validados
        /// antes de mandar a comprobar si la fecha introducida es anterior a la de hoy
        /// </summary>
        private void ComprobarFechaCompleta()
        {
            if(diaNacimiento && mesNacimiento && anyoNacimiento)
            {
                ComprobarFechaValida();
            }
        }
        /// <summary>
        /// Comprueba que la fecha intoducida es válida.
        /// Creamos un DateTime con los datos que ha marcado el usuario y compramos con Now
        /// </summary>
        private void ComprobarFechaValida()
        {
            if (!(new DateTime(Convert.ToInt32(cbAnyoNacimiento.SelectedItem),
                Convert.ToInt32((cbMesNacimiento.SelectedIndex + 1)),
                Convert.ToInt32(cbDiaNacimiento.SelectedItem)).CompareTo(DateTime.Now) > 0))
            {
                fechaValida = true;
            }
            else
            {
                fechaValida = false;
                errorProviderFecha.SetError(cbAnyoNacimiento, "La fecha de nacimiento no puede ser mayor a la actual");
            }
        }
       /// <summary>
       /// Aquí gestionaríamos lo que quisiéramos hacer con los datos
       /// </summary>
        private void GuardarDatosValidos()
        {
            //Aquí le daríamos el tratamiento deseado a los datos validados, tanto los obligatorios,
            //como los opcionales que han sido rellenados y validados.
        }

        private void cbNacionalidad_Change(object sender, EventArgs e)
        {
            if (cbNacionalidad.SelectedIndex != -1)
                nacionalidadCompletada = true;
            else
                nacionalidadCompletada = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if ((conformidadActivada && nombreValido && nacionalidadCompletada && correoValido && nickValido
                                && contrasenyaValida && confirmarContrasenyaValido && dcValido && titularValido && nifValido)
                            || (!conformidadActivada && nombreValido && nacionalidadCompletada && correoValido
                                && nickValido && contrasenyaValida && confirmarContrasenyaValido))
            {
                GuardarDatosValidos(); 
                MessageBox.Show("Registro insertado correctamente.");
                Application.Exit();
            }
            else
                MessageBox.Show("El formulario contiene campos obligatorios\nsin completar o sin validar"
                                    + ", por favor revíselo.");
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
