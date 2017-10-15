using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace CapaModelo
{
    public sealed class Postgre : CDatos
    {
        public override string CadenaConexion
        {
            get
            {
                if (MCadenaConexion.Length == 0)
                {
                    if (MServidor.Length != 0)
                    {
                        var sCadena = new System.Text.StringBuilder("");
                        sCadena.Append("Server= <SERVIDOR> ; port= 5432 ; Database= <BASE> ; " +
                                        "User ID=<USER> ; Password= <PASSWORD>");
                        sCadena.Replace("<SERVIDOR>", Servidor);
                        sCadena.Replace("<BASE>", Base);
                        sCadena.Replace("<USER>", Usuario);
                        sCadena.Replace("<PASSWORD>", Password);
                        MCadenaConexion = sCadena.ToString();
                        return MCadenaConexion;
                    }
                    throw new Exception("No se puede establecer la cadena de conexión en la clase Postgre.");
                }
                return MCadenaConexion;

            }// end get
            set
            { MCadenaConexion = value; } // end set
        }

        protected override NpgsqlCommand ComandoSql(string comandoSql)
        {
            var com = new NpgsqlCommand(comandoSql, (NpgsqlConnection)Conexion);
            return com;
        }

        protected override NpgsqlConnection CrearConexion(string cadenaConexion)
        { return new NpgsqlConnection(cadenaConexion); }

        protected override NpgsqlDataAdapter CrearDataAdapterSql(string comandoSql)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter((NpgsqlCommand)ComandoSql(comandoSql));
            return da;
        } 

        //public Postgre()
        //{
        //    Base = "";
        //    Servidor = "";
        //    Usuario = "";
        //    Password = "";
        //}
        public Postgre(string servidor, string bd, string usuario, string pass)
        {
            Servidor = servidor;
            Base = bd;
            Usuario = usuario;
            Password = pass;

        }

}
}
