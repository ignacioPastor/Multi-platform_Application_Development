using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace CapaModelo
{
    public abstract class CDatos
    {
        #region "Declaración de Variables"
 
        protected string MServidor = "";  // Servidor
        protected string MBase = ""; // Base de datos
        protected string MUsuario = ""; // Usuario
        protected string MPassword = ""; // Contraseña
        protected string MCadenaConexion = ""; // Cadena de conexión
        protected NpgsqlConnection MConexion; // La conexión
        protected DataSet myDatasetBD = new DataSet();
        public Dictionary<NpgsqlDataAdapter, string> myCollectionAdapter = new Dictionary<NpgsqlDataAdapter, string>();
        NpgsqlCommand orden;
        NpgsqlDataReader lector;

        #endregion

        #region "Propiedades"

        // Nombre del equipo servidor de datos. 
        public string Servidor
        {
            get { return MServidor; }
            set { MServidor = value; }
        } // end Servidor
 
        // Nombre de la base de datos a utilizar.
        public string Base
        {
            get { return MBase; }
            set { MBase = value; }
        } // end Base
 
        // Nombre del Usuario de la BD. 
        public string Usuario
        {
            get { return MUsuario; }
            set { MUsuario = value; }
        } // end Usuario
 
        // Password del Usuario de la BD. 
        public string Password
        {
            get { return MPassword; }
            set { MPassword = value; }
        } // end Password
 
        // Cadena de conexión completa a la base. // Se debe implementar en las clases derivadas
        public abstract string CadenaConexion
        { get; set; }
 
        #endregion
 
        #region "Privadas"
 
        // Crea u obtiene un objeto para conectarse a la base de datos. 
        protected NpgsqlConnection Conexion
        {
            get
            {
                // si aun no tiene asignada la cadena de conexión lo hace
                if (MConexion == null)
                    MConexion = CrearConexion(CadenaConexion);
 
                // si no esta abierta aun la conexión, lo abre
                if (MConexion.State != ConnectionState.Open)
                    MConexion.Open();
 
                // retorna la conexión en modo interfaz, para que se adapte a cualquier implementación de los distintos fabricantes de motores de bases de datos
                return MConexion;
            } // end get
        } // end Conexion
 
        #endregion
 
        #region "Obtener datos de la BD"
        /// <summary>
        /// Crea un adaptador, lo configura para actualizarse, y añade la tabla indicada al dataSetBD
        /// </summary>
        /// <param name="comandoSql">select que recupera una tabla de la BD</param>
        /// <param name="tipo">el nombre de la tabla</param>
        public void CargarDataSet(string comandoSql, string tipo)
        {
            NpgsqlDataAdapter miAdaptador = new NpgsqlDataAdapter();
            miAdaptador = CrearDataAdapterSql(comandoSql);
            NpgsqlCommandBuilder cbuilder = new NpgsqlCommandBuilder(miAdaptador);

            miAdaptador.InsertCommand = cbuilder.GetInsertCommand();
            if (tipo != "orderlines")//La tabla orderlines no admite updates
            {
                miAdaptador.UpdateCommand = cbuilder.GetUpdateCommand();
                miAdaptador.DeleteCommand = cbuilder.GetDeleteCommand(); //peta aquí también
            }

            myCollectionAdapter.Add(miAdaptador, tipo);

            miAdaptador.Fill(myDatasetBD, tipo);
        }
        /// <summary>
        /// Me devuelve el dataset que contiene toda la BD (la que he ido yo cargando)
        /// </summary>
        /// <returns>el dataSet con todas las tablas que haya cargado de la BD</returns>
        public DataSet GetDatasetBD()
        {
            return myDatasetBD;
        }
        public Dictionary<NpgsqlDataAdapter, string> GetCollectionAdapter()
        {
            return myCollectionAdapter;
        }
        /// <summary>
        /// Ejecuta una instrucción dml que recibe como parametro
        /// </summary>
        /// <param name="SQL">instrucción dml a ejecutar</param>
        /// <returns>objeto NpgsqlDataReader con los datos resultantes de la instrucción</returns>
        public NpgsqlDataReader EjecutarDML(string SQL)
        {
            //Ejecutar DML: Select.

            orden = new NpgsqlCommand(SQL, MConexion);
            lector = orden.ExecuteReader();
            return lector;
        }
        public int EjecutarDDL(string SQL)
        {
            //Ejecutar DDL: Insert, Update y Delete.
            int filasAfectadas = 0;
            orden = new NpgsqlCommand(SQL, MConexion);
            filasAfectadas = orden.ExecuteNonQuery();
            return filasAfectadas;
        }
        // Obtiene un DataSet a partir de un Query Sql.
        public DataSet ObtenerDataSetSql(string comandoSql, string tipo)
        {
            var mDataSet = new DataSet();

            //nuevo

            ////NpgsqlConnection conn = new NpgsqlConnection(comandoSql);
            //NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM products;", MConexion);

            //DataSet myDataSet = new DataSet();
            //adapter.Fill(myDataSet, "products");
            //return myDataSet;

            //nuevo

            CrearDataAdapterSql(comandoSql).Fill(mDataSet, tipo);
            return mDataSet;
        } // end TraerDataSetSql
 
        //Obtiene un DataTable a partir de un Query SQL
        public DataTable ObtenerDataTableSql(string comandoSql, string tipo)
        { return ObtenerDataSetSql(comandoSql, tipo).Tables[0].Copy(); } // end TraerDataTableSql
 
        // Obtiene un DataReader a partir de una sql
        public NpgsqlDataReader ObtenerDataReaderSql(string comandoSql)
        {
            var com = ComandoSql(comandoSql);
            return com.ExecuteReader();
        } // end TraerDataReaderSql  

        // Obtiene un Valor de una funcion Escalar a partir de un Query SQL
        public object ObtenerValorEscalarSql(string comandoSql)
        {
            var com = ComandoSql(comandoSql);
            return com.ExecuteScalar();
        } // end TraerValorEscalarSql
 
        #endregion
 
        #region "Acciones"
        protected abstract NpgsqlConnection CrearConexion(string cadena);
        //protected abstract IDbCommand Comando(string procedimientoAlmacenado);
        protected abstract NpgsqlCommand ComandoSql(string comandoSql);
        //protected abstract IDataAdapter CrearDataAdapter(string procedimientoAlmacenado, params Object[] args);
        protected abstract NpgsqlDataAdapter CrearDataAdapterSql(string comandoSql);
        //protected abstract void CargarParametros(IDbCommand comando, Object[] args);
 
        // metodo sobrecargado para autentificarse contra el motor de BBDD
        public bool Autentificar()
        {
            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();
            return true;
        }// end Autenticar
 
        // metodo sobrecargado para autentificarse contra el motor de BBDD
        public bool Autentificar(string vUsuario, string vPassword)
        {
            MUsuario = vUsuario;
            MPassword = vPassword;
            MConexion = CrearConexion(CadenaConexion);
 
            MConexion.Open();
            return true;
        }// end Autenticar
 
 
        // cerrar conexion
        public void CerrarConexion()
        {
            if (Conexion!=null)
                if (Conexion.State != ConnectionState.Closed)
                    MConexion.Close();
        }
 
        // end CerrarConexion
 
 
        // Ejecuta un query sql
        public int EjecutarSql(string comandoSql)
        { return ComandoSql(comandoSql).ExecuteNonQuery(); } // end Ejecutar

        #endregion
 
        #region "Transacciones"
 
        protected IDbTransaction MTransaccion;
        protected bool EnTransaccion;
 
        //Comienza una Transacción en la base en uso. 
        public void IniciarTransaccion()
        {
            try
            {
                MTransaccion = Conexion.BeginTransaction();
                EnTransaccion = true;
            }// end try
            finally
            { EnTransaccion = false; }
        }// end IniciarTransaccion
 
 
        //Confirma la transacción activa. 
        public void TerminarTransaccion()
        {
            try
            { MTransaccion.Commit(); }
            finally
            {
                MTransaccion = null;
                EnTransaccion = false;
            }// end finally
        }// end TerminarTransaccion
 
 
        //Cancela la transacción activa.
        public void AbortarTransaccion()
        {
            try
            { MTransaccion.Rollback(); }
            finally
            {
                MTransaccion = null;
                EnTransaccion = false;
            }// end finally
        }// end AbortarTransaccion
 
 
        #endregion
 
    }// end class gDatos
}// end namespace