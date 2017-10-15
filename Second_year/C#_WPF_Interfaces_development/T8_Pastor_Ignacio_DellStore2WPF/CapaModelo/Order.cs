using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Order
    {
        public int OrderId { set;  get; } // ver si se puede quitar el set y seguir usando la propiedad en el constructor
        public DateTime OrderDate { set; get; }
        public int CustomerId { set; get; }
        private decimal netAmount;
        public decimal NetAmount
        {
            set
            {
                netAmount = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
            }
            get
            {
                return netAmount;
            }
        }
        private decimal tax;
        public decimal Tax {
            set
            {
                tax = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
            }
            get
            {
                return tax;
            }
        }
        private decimal totalAmount;
        public decimal TotalAmount
        {
            set
            {
                totalAmount = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
            }
            get
            {
                return totalAmount;
            }
        }
        public Order()
        {
            OrderId = 0;
            OrderDate = DateTime.Now;
            CustomerId = 0;
            NetAmount = 0;
            Tax = 21;
            TotalAmount = 0;
        }
        public Order(DateTime orderDate, int customerId, decimal netAmount, decimal tax, decimal totalAmount)
        {
            OrderDate = orderDate;
            CustomerId = customerId;
            NetAmount = netAmount;
            Tax = tax;
            TotalAmount = totalAmount;
        }
        public Order(int orderId, DateTime orderDate, int customerId, decimal netAmount, decimal tax, decimal totalAmount)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            CustomerId = customerId;
            NetAmount = netAmount;
            Tax = tax;
            TotalAmount = totalAmount;
        }
        public Order(DataRow row)
        {
            OrderId = Convert.ToInt32(row["orderid"]);
            OrderDate = Convert.ToDateTime(row["orderdate"]);
            CustomerId = Convert.ToInt32(row["customerid"]);
            NetAmount = Convert.ToDecimal(row["netamount"]);
            Tax = Convert.ToDecimal(row["tax"]);
            TotalAmount = Convert.ToDecimal(row["totalamount"]);
        }
    }
}
