using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastor_Ignacio_Facturas
{
    /// <summary>
    /// Clase que caracteriza la factura, recoge los datos de la empresa a la que se está realizando la factura, así como los
    /// datos de la factura que la identifican
    /// </summary>
    public class Factura
    {
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        public string Localidad { set; get; }
        public string Nif { set; get; }
        public int NumeroFactura { set; get; }
        public DateTime Fecha { set; get; }
        public List<Articulo> ListaArticulosEnFactura { set; get; }

        public Factura()
        {
            ListaArticulosEnFactura = new List<Articulo>();
        }
        public Factura(string nombre, string direccion, string localidad, string nif, int numeroFactura, DateTime fecha)
        {
            Nombre = nombre;
            Direccion = direccion;
            Localidad = localidad;
            Nif = nif;
            NumeroFactura = numeroFactura;
            Fecha = fecha;
            ListaArticulosEnFactura = new List<Articulo>();
        }

        
    }
}
