using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Factura
    {
        public Customer Cliente { set; get; }
        public Order Pedido { set; get; }
        public List<Orderline> ListaLineasPedido { set; get; }
        public decimal BaseImponible
        {
            get
            {
                decimal suma = 0;
                foreach(Orderline line in ListaLineasPedido)
                    suma += line.ImporteBruto;
                Pedido.NetAmount = decimal.Round(suma, 2, MidpointRounding.AwayFromZero);
                return Pedido.NetAmount;
            }
        }
        public decimal TotalImpuestos
        {
            get
            {
                return decimal.Round(BaseImponible * (Pedido.Tax / 100), 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal TotalFactura
        {
            get
            {
                Pedido.TotalAmount = decimal.Round(BaseImponible + TotalImpuestos, 2, MidpointRounding.AwayFromZero);
                return Pedido.TotalAmount;
            }
        }
        public Factura()
        {
            Cliente = new Customer();
            Pedido = new Order();
            ListaLineasPedido = new List<Orderline>();
        }
        public Factura(Customer cliente, Order pedido, List<Orderline> listaLineasPedido)
        {
            Cliente = cliente;
            Pedido = pedido;
            ListaLineasPedido = listaLineasPedido;
        }
    }
}
