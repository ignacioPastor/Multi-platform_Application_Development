using CapaModelo;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace CapaNegocio
{
    public class Controlador
    {
        ObservableCollection<Usuario> listaUsuarios;
        ObservableCollection<Proyecto> listaProyectos;
        public ConexionBD conexion;
        Usuario usuarioLogeado;
        public DataSet dataSetBD;
        int aaa;
        Usuario usuarioInforme;
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public Controlador()
        {
            conexion = new ConexionBD();
        }
        /// <summary>
        /// Comprueba si el usuario y password existen en la BD.
        /// Lo utilizaremos en la ventana de Login.
        /// </summary>
        /// <param name="usuario">Usuario introducido en la ventana de Login</param>
        /// <param name="password">Password introducido en la ventana de Login</param>
        /// <returns>true si el usuario existe y el password es correcto</returns>
        public bool ComprobarLogin(string usuario, string password)
        {
            conexion.IniciarSesionPostgre();
            string sql = "select * from usuarios where usuario = '" + usuario + "' and pass = '" + EncriptarMd5(password) + "'";
            NpgsqlDataReader lector = conexion.GetGDatos().EjecutarDML(sql);
            if (lector.Read())
            {
                DateTime? tempFechNac = (DateTime?)(lector.IsDBNull(7) ? null : lector.GetValue(7));
                string tmpGenero = (lector.IsDBNull(8) ? null : lector.GetString(8));
                string tmpTelefono = (lector.IsDBNull(9) ? null : lector.GetString(9));

                usuarioLogeado = new Usuario(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), lector.GetString(3),
                    lector.GetString(4), lector.GetString(5), lector.GetString(6), tempFechNac, tmpGenero, tmpTelefono, lector.GetString(10));

                conexion.FinalizarSesion();
                lector.Close();
                return true;
            }
            conexion.FinalizarSesion();
            lector.Close();
            return false;
        }
        /// <summary>
        /// Carga los usuarios de la BD en una lista
        /// </summary>
        public void CargarUsuarios()
        {
            listaUsuarios = new ObservableCollection<Usuario>();
            conexion.IniciarSesionPostgre();
            NpgsqlDataReader lector = conexion.GetGDatos().EjecutarDML("select * from usuarios");

            while (lector.Read())
            {
                DateTime? tempFechNac = (DateTime?)(lector.IsDBNull(7) ? null : lector.GetValue(7));
                string tmpGenero = (lector.IsDBNull(8) ? null : lector.GetString(8));
                string tmpTelefono = (lector.IsDBNull(9) ? null : lector.GetString(9));

                listaUsuarios.Add(new Usuario(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), lector.GetString(3),
                    lector.GetString(4), lector.GetString(5), lector.GetString(6), tempFechNac, tmpGenero, tmpTelefono, lector.GetString(10)));
            }

            conexion.FinalizarSesion();
            lector.Close();
        }
        public ObservableCollection<Usuario> GetUsuarios()
        {
            return listaUsuarios;
        }
        /// <summary>
        /// Método de encriptación en MD5
        /// </summary>
        /// <param name="str">texto a encriptar</param>
        /// <returns>texto encriptado</returns>
        public static string EncriptarMd5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        /// <summary>
        /// Método para insertar usuario controlando los nulos.
        /// Aquí definimos la insert, y en CDatos añadimos los parámetros.
        /// </summary>
        public string InsertarUsuario(Usuario u)
        {
            try
            {
                conexion.IniciarSesionPostgre();
                string sCadena = "insert into usuarios (usuario, pass, cod_usuario, email, nombre, apellidos, fecha_nacimiento, genero, telefono, cod_departamento) "
                    + " values ( @usuario, @pass, @codUsuario, @mail, @nombreUsuario, @apellidosUsuario, @fechaNacimiento, @genero, @telefono, @codDep )";
                conexion.GetGDatos().EjecutarDMLParametersUsuario(sCadena, u);
                conexion.FinalizarSesion();
                return "";
            }
            catch (Exception e) { return "Ha habido un Error: " + e.Message; }
        }
        /// <summary>
        /// Hace una select contra la Base de Datos para obtener los tipos de usuarios que hay (cod_usuario).
        /// Se utilizará para rellenar los combobox de tipos de usuario
        /// </summary>
        /// <returns>Lista con los tipos de usuario que hay (cod_usuario)</returns>
        public List<string> GetTiposUsuario()
        {
            List<string> listTiposUsuario = new List<string>();
            conexion.IniciarSesionPostgre();
            NpgsqlDataReader lector = conexion.GetGDatos().EjecutarDML("select cod_usuario from t_usuario");

            while (lector.Read())
            {
                listTiposUsuario.Add(lector.GetString(0));
            }
            conexion.FinalizarSesion();
            lector.Close();
            return listTiposUsuario;
        }
        /// <summary>
        /// Hace una select contra la BD para obtener los departamentos que hay.
        /// Lo utilizaremos para rellenar los combobox que procedan
        /// </summary>
        /// <returns>Lista con los departamentos que existen</returns>
        public List<string> GetDepartamentos()
        {
            List<string> listDepartamentos = new List<string>();
            conexion.IniciarSesionPostgre();
            NpgsqlDataReader lector = conexion.GetGDatos().EjecutarDML("select cod_departamento from departamentos");

            while (lector.Read())
            {
                listDepartamentos.Add(lector.GetString(0));
            }
            conexion.FinalizarSesion();
            lector.Close();
            return listDepartamentos;
        }
        /// <summary>
        /// Inserta un usuario en la BD.
        /// Encripta el password, y llama a la función para insertar
        /// </summary>
        public string InsertarNuevoUsuario(string usuario, string pass, string tipo, string mail, string nombre,
            string apellidos, DateTime? fechaNac, string genero, string telefono, string departament)
        {
            
            return InsertarUsuario(
                    new Usuario(usuario, EncriptarMd5(pass), tipo, mail, nombre, apellidos,
                        fechaNac, genero, telefono, departament)
                );
        }
        /// <summary>
        /// Actualiza un usuario en la BD
        /// </summary>
        /// <param name="u">Usuario a actualizar</param>
        /// <returns>Devuelve el mensaje de error de la excepción, caso de producirse</returns>
        public string ActualizarUsuario(Usuario u)
        {
            try
            {
                conexion.IniciarSesionPostgre();
                u.Contrasenya = EncriptarMd5(u.Contrasenya);
                string sCadena = "update usuarios set usuario = @usuario, pass =  @pass, cod_usuario = @codUsuario, email = @mail,"
                    + " nombre = @nombreUsuario, apellidos = @apellidosUsuario, fecha_nacimiento = @fechaNacimiento,"
                    + " genero = @genero, telefono = @telefono, cod_departamento = @codDep "
                    + "where id_usuario = " + u.IdUsuario;
                conexion.GetGDatos().EjecutarDMLParametersUsuario(sCadena, u);
                conexion.FinalizarSesion();
                return "";
            }
            catch (Exception e) { return "Ha habido un Error: " + e.Message; }

        }
        /// <summary>
        /// Esta función carga todas las tablas de la BD en el DataSet del Programa
        /// </summary>
        public void CargarDatosDataset()
        {
            //conexion.GetGDatos().InicializarColeccionAdaptadores();
            conexion.IniciarSesionPostgre(); //Conecto con postgre en conexion

            conexion.GetGDatos().CargarDataSet("select * from tareas", "tareas");
            conexion.GetGDatos().CargarDataSet("select * from t_tarea", "t_tarea");
            conexion.GetGDatos().CargarDataSet("select * from proyectos", "proyectos");

            dataSetBD = conexion.GetGDatos().GetDatasetBD();
            conexion.FinalizarSesion();
        }
        public DataTable GetDataTable(string nombreDataTable)
        {
            return dataSetBD.Tables[nombreDataTable];
        }
        /// <summary>
        /// Guarda los datos del dataSet en la Base de Datos
        /// </summary>
        /// <param name="tipo">nombre de la tabla que queremos guardar</param>
        /// <returns>informe del resultado de nuestra operación</returns>
        public string GuardarDatosEnBD(string tipo)
        {
            aaa = conexion.GetGDatos().GetCollectionAdapter().Count;
            if (dataSetBD.HasChanges() && !(dataSetBD.HasErrors))
            {
                aaa = conexion.GetGDatos().GetCollectionAdapter().Count;
                try
                {
                    Dictionary<NpgsqlDataAdapter, string> myCollectionAdapter = conexion.GetGDatos().GetCollectionAdapter();
                    foreach (KeyValuePair<NpgsqlDataAdapter, string> entry in myCollectionAdapter)
                    {
                        if (entry.Value == tipo) //Sin este if no funciona
                        {
                            entry.Key.Update(dataSetBD, entry.Value);
                            dataSetBD.AcceptChanges();
                        }
                    }
                    return "BD actualizada correctamente";
                }
                catch (Exception e)
                {
                    return "Error al intentar actualizar la BD: " + e.Message;
                }
            }
            else
                return "No hay cambios que actualizar";
        }
        /// <summary>
        /// Devuelve el dataSet del Controlador
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSet()
        {
            return dataSetBD;
        }
        /// <summary>
        /// Le pasamos una tarea, y busca en la BD el usuario y proyecto completos a los que está asignada y se los añade
        /// </summary>
        /// <param name="myTarea">Tarea cargada de la BD, a la que queremos añadir la información completa de Usuario y Proyecto</param>
        public void CompletarUsuarioProyectoEnTarea(Tarea myTarea)
        {
            conexion.IniciarSesionPostgre();
            string sql = "select * from usuarios where id_usuario = " + myTarea.UsuarioAsignado + "";
            NpgsqlDataReader lector;
            lector = conexion.GetGDatos().EjecutarDML(sql);
            if (lector.Read())
            {
                DateTime? tempFechNac = (DateTime?)(lector.IsDBNull(7) ? null : lector.GetValue(7));
                string tmpGenero = (lector.IsDBNull(8) ? null : lector.GetString(8));
                string tmpTelefono = (lector.IsDBNull(9) ? null : lector.GetString(9));

                myTarea.MyUsuario =  new Usuario(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), lector.GetString(3),
                    lector.GetString(4), lector.GetString(5), lector.GetString(6), tempFechNac, tmpGenero, tmpTelefono, lector.GetString(10));
                conexion.FinalizarSesion();
            }
            conexion.IniciarSesionPostgre();
            lector = conexion.GetGDatos().EjecutarDML("select * from proyectos where id_proyecto = " + myTarea.ProyectoPertenece);
            if (lector.Read())
            {
                myTarea.MyProyecto = new Proyecto(lector.GetInt32(0), lector.GetString(1), lector.GetString(2));
            }
            conexion.FinalizarSesion();
            lector.Close();
        }
        /// <summary>
        /// Obtiene de la BD los tipos de tarea que hay (cod_tarea)
        /// Lo utilizaremos para rellenar los combobox que procedan
        /// </summary>
        /// <returns>Lista con los distintos tipos de tarea que existen</returns>
        public ObservableCollection<string> GetTiposTarea()
        {
            ObservableCollection<string> tiposTarea = new ObservableCollection<string>();
            var groupbyfilter = (from d in dataSetBD.Tables["tareas"].AsEnumerable() group d by d["cod_tarea"]);
            foreach (IGrouping<object, DataRow> tipo in groupbyfilter)
            {
                try
                {
                    tiposTarea.Add((string)tipo.Key);
                }
                catch (Exception)
                {
                    //Aquí no sé por qué, pero cuando cancelas la ventana de dar de alta , si después abres en modo modificar,
                    // coge un valor vacío y lanza una excepción. Con este catch no metemos ese valor y se soluciona.
                }
            }
            return tiposTarea;
        }
        /// <summary>
        /// Carga en listaProyectos los proyectos que existen en la BD
        /// </summary>
        public void CargarProyectos()
        {
            listaProyectos = new ObservableCollection<Proyecto>();
            conexion.IniciarSesionPostgre();
            NpgsqlDataReader lector = conexion.GetGDatos().EjecutarDML("select * from proyectos");
            while (lector.Read())
            {
                listaProyectos.Add(new Proyecto(lector.GetInt32(0), lector.GetString(1), lector.GetString(2)));
            }
            conexion.FinalizarSesion();
            lector.Close();
        }
        
        /// <summary>
        /// Consulta la BD para mirar las tareas que tiene el usuario para esa fecha
        /// </summary>
        /// <param name="u">Usuario informe semanal estamos configurando</param>
        /// <param name="d">Fecha para la cual vamos a consultar las tareas que aparecen</param>
        /// <returns></returns>
        public List<Tarea> GetTareasEnDia(Usuario u, DateTime d)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            Tarea t;

            conexion.IniciarSesionPostgre();
            string sql = "select * from tareas where id_usuario = " + u.IdUsuario + " and fecha_alta::date = '" + d.ToString("dd-MM-yyyy")+"'";
            NpgsqlDataReader lector;
            lector = conexion.GetGDatos().EjecutarDML(sql);
            while (lector.Read())
            {
                DateTime? tempFechaAlta = (DateTime?)(lector.IsDBNull(3) ? null : lector.GetValue(3));
                DateTime? tempFechaCuandoAvisar = (DateTime?)(lector.IsDBNull(11) ? null : lector.GetValue(11));
                string tempDescripcion = (lector.IsDBNull(2) ? null : lector.GetString(2));
                string tempComentarios = (lector.IsDBNull(13) ? null : lector.GetString(13));

                t = new Tarea(lector.GetInt32(0), lector.GetString(1), tempDescripcion, tempFechaAlta, lector.GetInt32(4), lector.GetString(5),
                    lector.GetBoolean(6), lector.GetInt32(7), lector.GetInt32(8), lector.GetInt32(9), lector.GetBoolean(10),
                    tempFechaCuandoAvisar, lector.GetBoolean(12), tempComentarios);
                CompletarUsuarioProyectoEnTarea(t);
                listaTareas.Add(t);
            }
            conexion.FinalizarSesion();
            lector.Close();

            return listaTareas;
        }
        /// <summary>
        /// Getter para el usuario que se ha logeado
        /// </summary>
        /// <returns>Usuario que se ha logeado en nuestra aplicación</returns>
        public Usuario GetUsuarioLogin()
        {
            return usuarioLogeado;
        }
        /// <summary>
        /// Getter listaProyectos
        /// </summary>
        /// <returns>listaProyectos</returns>
        public ObservableCollection<Proyecto> GetProyectos()
        {
            return listaProyectos;
        }
        /// <summary>
        /// Getter usuarioInforme
        /// </summary>
        /// <returns>usuarioInforme</returns>
        public Usuario GetUsuarioInforme()
        {
            return usuarioInforme;
        }
        /// <summary>
        /// Setter usuarioInforme
        /// </summary>
        /// <param name="usuarioInforme">usuarioInforme</param>
        public void SetUsuarioInforme(Usuario usuarioInforme)
        {
            this.usuarioInforme = usuarioInforme;
        }
        /// <summary>
        /// Método de prueba, se usará puntualmente en la fase inicial del proyecto
        /// </summary>
        public void InsertarUsuarioPrueba()
        {
            conexion.IniciarSesionPostgre();
            var sCadena = new System.Text.StringBuilder("");
            sCadena.Append("insert into usuarios (usuario, pass, cod_usuario, email, nombre, apellidos, cod_departamento) "
               + " values ( '<USUARIO>' , '<PASS>' , '<COD_USUARIO>', '<MAIL>' , '<NOMBRE_USUARIO>', '<APELLIDOS_USUARIO>', '<COD_DEP>' )");
            sCadena.Replace("<USUARIO>", "2");
            sCadena.Replace("<PASS>", EncriptarMd5("2"));
            sCadena.Replace("<COD_USUARIO>", "JEF");
            sCadena.Replace("<MAIL>", "mail2");
            sCadena.Replace("<NOMBRE_USUARIO>", "nombreUsuario2");
            sCadena.Replace("<APELLIDOS_USUARIO>", "apellidosUsuario2");
            sCadena.Replace("<COD_DEP>", "INF");

            conexion.GetGDatos().EjecutarDML(sCadena.ToString());

            conexion.FinalizarSesion();
        }
    }
}
