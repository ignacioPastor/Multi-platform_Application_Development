using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    class CustomException : Exception
    {
        public CustomException(string message)
            : base(message) { }

    }
    public class products /*: IDataErrorInfo*/
    {
        public int ProdId { set; get; }
        public int Category { set; get; }
        public string Title { get; set; }
        public string Actor { set; get; }
        private decimal price;
        public decimal Price
        {
            set { price = value; }
            get { return decimal.Round(price, 2, MidpointRounding.AwayFromZero); }
        }
        public short Special { set; get; }
        public int CommonProdId { set; get; }

        public products()
        {
            ProdId = 0;
            Category = 0;
            Title = "TITLE PRODUCTO";
            Actor = "";
            Price = 0;
            Special = 0;
            CommonProdId = 0;
        }
        public products(int category, string title, string actor, decimal price, short special, int commonProdId)
        {
            Category = category;
            Title = title;
            Actor = actor;
            Price = price;
            Special = special;
            CommonProdId = commonProdId;
        }
        public products(int prodId, int category, string title, string actor, decimal price, short special, int commonProdId)
        {
            ProdId = prodId;
            Category = category;
            Title = title;
            Actor = actor;
            Price = price;
            Special = special;
            CommonProdId = commonProdId;
        }
        public products(DataRow row)
        {
            ProdId = Convert.ToInt32(row["prod_id"]);
            Category = Convert.ToInt32(row["category"]);
            Title = Convert.ToString(row["title"]);
            Actor = Convert.ToString(row["actor"]);
            Price = Convert.ToDecimal(row["price"]);
            Special = Convert.ToInt16(row["special"]);
            CommonProdId = Convert.ToInt32(row["common_prod_id"]);
        }

        //public string Error
        //{
        //    //get { throw new NotImplementedException(); }
        //    get { return "patata"; }
        //}

        //public string this[string columnName] // ver como gestionar el tema de los integer vacíos
        //{
        //    get
        //    {
        //        string result = null;
        //        if (columnName == "ProdId")
        //        {
        //            if (ProdId == null)
        //                result = "Introduzca un prod Id";
        //        }
        //        if (columnName == "Category")
        //        {
        //            if (Category == null)
        //                result = "Introduzca una categoría";
        //        }
        //        if (columnName == "Title")
        //        {
        //            if (string.IsNullOrEmpty(Title))
        //                result = "Introduzca un título";
        //            else if (Title.Length > 50)
        //                result = "El máximo de caracteres es 50";
        //        }
        //        if (columnName == "Actor")
        //        {
        //            if (string.IsNullOrEmpty(Actor))
        //                result = "Introduzca un actor";
        //            else if (Actor.Length > 50)
        //                result = "El máximo de caracteres es 50";
        //        }
        //        if (columnName == "Price")
        //        {
        //            if (Price == null)
        //                result = "Introduzca un precio";
        //        }
        //        if (columnName == "Special") // En realidad Special puede ser nulo
        //        {
        //            if (Special == null)
        //                result = "Indique la valoración de Special";
        //        }
        //        if( columnName == "CommonProdId")
        //        {
        //            if (CommonProdId == null)
        //                result = "Indique un balor de common prod id";
        //        }
        //        return result;
        //    }
        //}

        public DataRow getProductAsRow(DataTable tablaModelo)
        {
            DataRow row = tablaModelo.NewRow();

            row["prod_id"] = ProdId;
            row["category"] = Category;
            row["title"] = Title;
            row["actor"] = Actor;
            row["price"] = Price;
            row["special"] = Special;
            row["common_prod_id"] = CommonProdId;

            return row;
        }

    }
}
