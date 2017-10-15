using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastor_Ignacio_Facturas
{
    public class Articulo
    {
        public DateTime Fecha { set; get; }
        public float Cantidad { set; get; }
        public string Descripcion { set; get; }
        public float ImpBruto { set; get; }
        public float Importe { set; get; }

        public Articulo()
        {

        }
        public Articulo(DateTime fecha, float cantidad, string descripcion, float impBruto, float importe)
        {
            Fecha = fecha;
            Cantidad = cantidad;
            Descripcion = descripcion;
            ImpBruto = impBruto;
            Importe = importe;
        }
    }
}
