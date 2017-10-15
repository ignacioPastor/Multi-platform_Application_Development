using CapaModelo;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador
{
    public class Controlador
    {
        public ObservableCollection<products> listProducts; //Binding sin conectar con la BD
       
        static public DataSet dataSetBD;
        
        public ConexionBD conexion;
        public Controlador()
        {
           listProducts = new ObservableCollection<products>(); //Binding sin conectar con la BD
           Initialize();
        }
        private void Initialize()
        {
            conexion = new ConexionBD();
        }
       
        public ObservableCollection<products> GetListProdutc()
        {
            return listProducts;
        }
        /// <summary>
        /// No voy a utilizar esta función porque tarda demasiado (4,5s), lanzaré esta búsqueda desde otro hilo en la propia ventana
        /// </summary>
        /// <returns></returns>
        public int GetProdIdEstimada()
        {
            DataRow[] n = dataSetBD.Tables["products"].Select("prod_id = max(prod_id)"); //Tarda demasiado
            return (int) n[0][0] + 1; 
        }
        public ObservableCollection<int> GetCategoriasProductos()
        {
            ObservableCollection<int> categorias = new ObservableCollection<int>();
            var groupbyfilter = (from d in dataSetBD.Tables["products"].AsEnumerable() group d by d["category"]);
            foreach (IGrouping<object, DataRow> cat in groupbyfilter)
            {
                try
                {
                    categorias.Add((Int32)cat.Key);
                }catch(Exception e)
                {
                    //Aquí no sé por qué, pero cuando cancelas la ventana de dar de alta un producto, si después abres en Modificar Producto,
                    // coge un valor vacío y lanza una excepción. Con este catch no metemos ese valor y se soluciona.
                }
            }
            categorias = new ObservableCollection<int>(categorias.OrderBy(i => i));

            return categorias;
        }
        /// <summary>
        /// Esta función carga todas las tablas de la BD en el DataSet del Programa
        /// </summary>
        public void CargarDatosDataset()
        {
            conexion.IniciarSesionPostgre("localhost", "dellstore2", "postgres", "1234"); //Conecto con postgre en conexion

            conexion.GetGDatos().CargarDataSet("select * from customers", "customers");
            conexion.GetGDatos().CargarDataSet("select * from products", "products");
            conexion.GetGDatos().CargarDataSet("select * from orders", "orders");
            conexion.GetGDatos().CargarDataSet("select * from orderlines", "orderlines");

            dataSetBD = conexion.GetGDatos().GetDatasetBD();
            conexion.FinalizarSesion();
        }
        public DataTable GetDataTable(string nombreDataTable)
        {
            return dataSetBD.Tables[nombreDataTable];
        }
        public string GuardarDatosEnBD(string tipo)
        {
            if (dataSetBD.HasChanges() && !(dataSetBD.HasErrors))
            {
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
        public DataSet GetDataSet()
        {
            return dataSetBD;
        }
        public void Update(Factura factura)
        {
            conexion.IniciarSesionPostgre("localhost", "dellstore2", "postgres", "1234"); //Conecto con postgre en conexion
            if (factura.ListaLineasPedido.Count > 0)
            {
                int idPedido = factura.ListaLineasPedido[0].OrderId;
                conexion.GetGDatos().EjecutarDML("delete from orderlines "
                        + " where orderid = " + idPedido);
            }
            conexion.FinalizarSesion();

            foreach (Orderline line in factura.ListaLineasPedido)
            {
            conexion.IniciarSesionPostgre("localhost", "dellstore2", "postgres", "1234"); //Conecto con postgre en conexion

                conexion.GetGDatos().EjecutarDML("insert into orderlines values ( " + line.OrderlineId + ", "
                    + line.OrderId + ", " + line.ProdId + ", " + line.Quantity + ", '" + line.OrderDate + "' );");
                conexion.FinalizarSesion();
            }
        }
        /// <summary>
        /// Inserta en la BD un Order
        /// </summary>
        /// <param name="factura"></param>
        public void InsertOrder(Factura factura)
        {
            conexion.IniciarSesionPostgre("localhost", "dellstore2", "postgres", "1234"); //Conecto con postgre en conexion

            decimal netAmount = factura.Pedido.NetAmount;
            decimal totalAmount = factura.Pedido.TotalAmount;
            decimal tax = factura.Pedido.Tax;
            double nuevo = 2.5;

            var sCadena = new System.Text.StringBuilder("");
            sCadena.Append("insert into orders ( orderdate , customerid , netamount , tax , totalamount ) "
                + " values ( '<ORDERDATE>' , <CUSTOMERID> , <NETAMOUNT>, <TAX> , <TOTALAMOUNT> )");
            sCadena.Replace("<ORDERDATE>", factura.Pedido.OrderDate.Date.ToString());
            sCadena.Replace("<CUSTOMERID>", factura.Cliente.CustomerId.ToString());
            sCadena.Replace("<NETAMOUNT>", factura.Pedido.NetAmount.ToString().Replace(",","."));
            sCadena.Replace("<TAX>", factura.Pedido.Tax.ToString().Replace(",", "."));
            sCadena.Replace("<TOTALAMOUNT>", factura.Pedido.TotalAmount.ToString().Replace(",", "."));

            conexion.GetGDatos().EjecutarDDL(sCadena.ToString());

            conexion.FinalizarSesion();
        }
        /// <summary>
        /// Inserta en la BD una lista de Orderlines
        /// </summary>
        /// <param name="factura"></param>
        public void InsertOrderlines(Factura factura)
        {
            foreach (Orderline line in factura.ListaLineasPedido)
            {
                conexion.IniciarSesionPostgre("localhost", "dellstore2", "postgres", "1234"); //Conecto con postgre en conexion

                var sCadena = new System.Text.StringBuilder("");
                sCadena.Append("insert into orderlines ( orderlineid , orderid , prod_id , quantity , orderdate ) "
                    + " values ( <ORDERLINEID> , <ORDERID> , <PROD_ID> , <QUANTITY> , '<ORDERDATE>' )");
                sCadena.Replace("<ORDERLINEID>", line.OrderlineId.ToString());
                sCadena.Replace("<ORDERID>", line.OrderId.ToString());
                sCadena.Replace("<PROD_ID>", line.ProdId.ToString());
                sCadena.Replace("<QUANTITY>", line.Quantity.ToString().Replace(",", "."));
                sCadena.Replace("<ORDERDATE>", line.OrderDate.Date.ToString().Replace(",", "."));

                conexion.GetGDatos().EjecutarDDL(sCadena.ToString());

                conexion.FinalizarSesion();
            }
        }
    }
}
