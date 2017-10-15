using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Orderline
    {
        public int OrderlineId { set; get; }
        public int OrderId { set; get; }
        public int ProdId { set; get; }
        public short Quantity { set; get; }
        public DateTime OrderDate { set; get; }
        public products ProductoLine { set; get; }
        public decimal ImporteBruto
        {
            get { return decimal.Round(ProductoLine.Price * Quantity, 2, MidpointRounding.AwayFromZero); }
        }
        public Orderline()
        {
            OrderlineId = 0;
            OrderId = 0;
            ProdId = 0;
            Quantity = 0;
            OrderDate = DateTime.Now;
        }
        public Orderline(products producto, Order pedido, List<Orderline> listaLineasPedido)
        {
            int maxId = 0;
            foreach(Orderline line in listaLineasPedido)
                if (line.OrderlineId > maxId)
                    maxId = line.OrderlineId;

            OrderlineId = ++maxId;
            OrderId = pedido.OrderId;
            ProdId = producto.ProdId;
            Quantity = 1;
            OrderDate = DateTime.Now;
            ProductoLine = producto;
        }
        public Orderline(int orderId, int prodId, short quantity, DateTime orderDate)
        {
            OrderId = orderId;
            ProdId = prodId;
            Quantity = quantity;
            OrderDate = orderDate;
        }
        public Orderline(int orderlineId, int orderId, int prodId, short quantity, DateTime orderDate)
        {
            OrderlineId = orderlineId;
            OrderId = orderId;
            ProdId = prodId;
            Quantity = quantity;
            OrderDate = orderDate;
        }
        public Orderline(int orderlineId, int orderId, int prodId, short quantity, DateTime orderDate, products productoLine)
        {
            OrderlineId = orderlineId;
            OrderId = orderId;
            ProdId = prodId;
            Quantity = quantity;
            OrderDate = orderDate;
            ProductoLine = productoLine;
        }
        public Orderline(DataRow row)
        {
            OrderlineId = Convert.ToInt32(row["orderlineid"]); ;
            OrderId = Convert.ToInt32(row["orderid"]); ;
            ProdId = Convert.ToInt32(row["prod_id"]); ;
            Quantity = Convert.ToInt16(row["quantity"]); ;
            OrderDate = Convert.ToDateTime(row["orderdate"]); ;
        }
        public Orderline(DataRow row, products productoLine)
        {
            OrderlineId = Convert.ToInt32(row["orderlineid"]); ;
            OrderId = Convert.ToInt32(row["orderid"]); ;
            ProdId = Convert.ToInt32(row["prod_id"]); ;
            Quantity = Convert.ToInt16(row["quantity"]); ;
            OrderDate = Convert.ToDateTime(row["orderdate"]);
            ProductoLine = productoLine;
        }
    }
}
