using System;
using System.Data;
using System.Diagnostics;
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace CapaModelo
{
    public class Usuario
    {
        public int IdUsuario { get; }
        public string User { get; set; }
        public string Contrasenya { get; set; }
        public string TipoUsuario { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string TelefonoTrabajo { get; set; }
        public string Departamento { get; set; }
        public Byte Imagen { get; set; } //No implementaremos el uso de la imagen.

        /// <summary>
        /// Constructor vacío
        /// </summary>
        public Usuario()
        {
            this.IdUsuario = 0;
            User = "";
            Contrasenya = "";
            TipoUsuario = "";
            Email = "";
            Nombre = "";
            Apellidos = "";
            FechaNacimiento = null;
            Genero = "";
            TelefonoTrabajo = "";
            Departamento = "";
        }

        /// <summary>
        /// Constructor sobrecargado, no incluye la clave unívoca que será generada por la BD
        /// Lo utilizaremos cuando sea el usuario el que inserte un nuevo usario, una vez almacenado
        /// en la BD, se le asignará una clave
        /// </summary>
        /// <param name="usuario">nombre de usuario de aplicación del Usuario</param>
        /// <param name="contrasenya">password del usuario</param>
        /// <param name="tipoUsuario">tipo de usuario (Jefe de Departamento, Usuario, Administrador</param>
        /// <param name="email">email del usuario</param>
        /// <param name="nombre">nombre del usuario</param>
        /// <param name="apellidos">apellidos del usuario</param>
        /// <param name="fechaNacimiento">fecha de nacimiento del usuario</param>
        /// <param name="genero">género del usuario, V si es Varón, M si es Mujer</param>
        /// <param name="telefonoTrabajo">teléfono de trabajo</param>
        /// <param name="departamento">Departamento al que está asignado</param>
        public Usuario(string usuario, string contrasenya, string tipoUsuario, string email, string nombre,
            string apellidos, DateTime? fechaNacimiento, string genero, string telefonoTrabajo, string departamento)
        {
            User = usuario;
            Contrasenya = contrasenya;
            TipoUsuario = tipoUsuario;
            Email = email;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Genero = genero;
            TelefonoTrabajo = telefonoTrabajo;
            Departamento = departamento;
        }
        //Constructor para cuando leemos de la BD
        /// <summary>
        /// Constructor sobrecargado, incluye la clave unívoca
        /// Utilizaremos este constructor cuando carguemos los datos de la BD
        /// </summary>
        /// <param name="idUsuario">clave unívoca que identifica al usuario</param>
        /// <param name="usuario">nombre de usuario de aplicación del Usuario</param>
        /// <param name="contrasenya">password del usuario</param>
        /// <param name="tipoUsuario">tipo de usuario (Jefe de Departamento, Usuario, Administrador</param>
        /// <param name="email">email del usuario</param>
        /// <param name="nombre">nombre del usuario</param>
        /// <param name="apellidos">apellidos del usuario</param>
        /// <param name="fechaNacimiento">fecha de nacimiento del usuario</param>
        /// <param name="genero">género del usuario, V si es Varón, M si es Mujer</param>
        /// <param name="telefonoTrabajo">teléfono de trabajo</param>
        /// <param name="departamento">Departamento al que está asignado</param>
        public Usuario(int idUsuario, string usuario, string contrasenya, string tipoUsuario, string email, string nombre,
            string apellidos, DateTime? fechaNacimiento, string genero, string telefonoTrabajo, string departamento)
        {
            this.IdUsuario = idUsuario;
            User = usuario;
            Contrasenya = contrasenya;
            TipoUsuario = tipoUsuario;
            Email = email;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Genero = genero;
            TelefonoTrabajo = telefonoTrabajo;
            Departamento = departamento;
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Instancia un Usuario dado un DataRow con los campos e información del usuario
        /// </summary>
        /// <param name="row">DataRow con la información y campos del usuario</param>
        public Usuario(DataRow row)
        {
            this.IdUsuario = Convert.ToInt32(row["id_usuario"]);
            User = Convert.ToString(row["usuario"]);
            Contrasenya = Convert.ToString(row["pass"]);
            TipoUsuario = Convert.ToString(row["cod_usuario"]);
            Email = Convert.ToString(row["email"]);
            Nombre = Convert.ToString(row["nombre"]);
            Apellidos = Convert.ToString(row["apellidos"]);
            FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]);
            Genero = Convert.ToString(row["genero"]);
            TelefonoTrabajo = Convert.ToString(row["telefono"]);
            Departamento = Convert.ToString(row["departamento"]);
        }
        /// <summary>
        /// Muestra la información del usuario
        /// </summary>
        public void ImprimirUsuario()
        {
            Console.WriteLine(IdUsuario.ToString() + " " + User + " " + Contrasenya + " " +
                TipoUsuario + " " + Email + " " + Nombre + " " + Apellidos + " " +
                FechaNacimiento == null ? "0/0/0" : FechaNacimiento.Value.ToString("yyyy-MM-dd") + " " + Genero + " " + TelefonoTrabajo + " " + Departamento);
        }
    }
}
