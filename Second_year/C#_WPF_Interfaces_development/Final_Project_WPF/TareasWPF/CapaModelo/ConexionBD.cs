using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace CapaModelo
{
    /// <summary>
    /// Clase que gestiona la conexión a la base de datos
    /// </summary>
    public class ConexionBD
    {
        private NpgsqlConnection conexionConBD;
        private NpgsqlCommand orden;
        private NpgsqlDataReader lector;
        static string strConexion;
        public CDatos GDatos;

        //Cambiar aquí los datos para otra BD y usuario
        private const string PUERTO = "5432";
        private const string BASE_DE_DATOS = "tareas";
        private const string USUARIO = "postgres";
        private const string PASSWORD = "1234";
        private const string SERVER = "localhost";
        /// <summary>
        /// Constructor vacío que inicializa los valores
        /// </summary>
        public ConexionBD()
        {
            strConexion = string.Format("Server=" + SERVER + "; " +
                                        "port=" + PUERTO + "; " +
                                        "Database=" + BASE_DE_DATOS + "; " +
                                        "User ID=" + USUARIO + "; " +
                                        "Password=" + PASSWORD);


            conexionConBD = null;
            orden = null;
            lector = null;
        }
        /// <summary>
        /// Método traído del proyecto CapaDatos
        /// Inicia una sesión en postgre recibiendo todos los datos de conexión
        /// Mejor no utilizar, ya que dificulta la adaptación en caso de cambio de BD
        /// </summary>
        /// <param name="nombreServidor"></param>
        /// <param name="baseDatos"></param>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IniciarSesionPostgre(string nombreServidor, string baseDatos, string usuario, string password)
        {
            //Iniciar sesión contra un Acess
            GDatos = new Postgre(nombreServidor, baseDatos, usuario, password);
            return GDatos.Autentificar();
        }
        /// <summary>
        /// Método traído del proyecto CapaDatos
        /// Inicia una sesión en postgre sirviéndose de los datos previamente definidos
        /// </summary>
        /// <returns></returns>
        public bool IniciarSesionPostgre()
        {
            GDatos = new Postgre(SERVER, BASE_DE_DATOS, USUARIO, PASSWORD);
            return GDatos.Autentificar();
        }

        public void FinalizarSesion()
        {
            GDatos.CerrarConexion();
        } //fin FinalizaSesion

        /// <summary>
        /// Abre la conexión a la base de datos
        /// </summary>
        public void Abrir()
        {
            //Abrir la base de datos
            conexionConBD = new NpgsqlConnection(strConexion);
            conexionConBD.Open();
        }
        /// <summary>
        /// Cierra la conexión a la base de datos
        /// </summary>
        public void Cerrar()
        {
            // Cerrar la conexión cuando ya no sea necesaria.
            if (lector != null)
            {
                lector.Close();
            }

            if (conexionConBD != null)
            {
                conexionConBD.Close();
            }
        }
        /// <summary>
        /// Ejecuta una instrucción dml que recibe como parametro
        /// </summary>
        /// <param name="SQL">instrucción dml a ejecutar</param>
        /// <returns>objeto NpgsqlDataReader con los datos resultantes de la instrucción</returns>
        public NpgsqlDataReader EjecutarDML(string SQL)
        {
            //Ejecutar DML: Select.
            orden = new NpgsqlCommand(SQL, conexionConBD);
            lector = orden.ExecuteReader();
            return lector;
        }
        /// <summary>
        /// Ejecuta una instrucción ddl que recibe como parámetro
        /// </summary>
        /// <param name="SQL">instrucción ddl</param>
        /// <returns>número de filas de la BD que se han visto afectadas por la instrucción</returns>
        public int EjecutarDDL(string SQL)
        {
            //Ejecutar DDL: Insert, Update y Delete.
            int filasAfectadas = 0;
            orden = new NpgsqlCommand(SQL, conexionConBD);
            filasAfectadas = orden.ExecuteNonQuery();
            return filasAfectadas;
        }
        public CDatos GetGDatos()
        {
            return GDatos;
        }
    }
}
