using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Customer
    {
        public int CustomerId { set; get; } //ver si se puede quitar el set y seguir usando la propiedad en el constructor
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public int Zip { set; get; }
        public string Country { set; get; }
        public short Region { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public int CreditCardType { set; get; }
        public string CreditCard { set; get; }
        public string CreditCardExpiration { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public short Age { set; get; }
        public int Income { set; get; }
        public string Gender { set; get; }

        public Customer()
        {
            FirstName = "Intoducir datos";
            LastName = "Intoducir datos";
            Address1 = "Intoducir datos";
            Address2 = "";
            City = "Intoducir datos";
            State = "Intoducir datos";
            Country = "Intoducir datos";
            Email = "Intoducir datos";
            Phone = "Intoducir datos";
            CreditCard = "Intoducir datos";
            CreditCardExpiration = "Intoducir datos";
            UserName = "";
            Password = "Intoducir datos";
            Gender = "M";

            CustomerId = 0;
            Zip = 0;
            Region = 0;
            CreditCardType = 0;
            Age = 0;
            Income = 0;
        }
        public Customer(string firstName, string lastName, string address1, string address2, string city, string state, int zip, string country,
            short region, string email, string phone, int creditCardType, string creditCard, string creditCardExpiration, string userName, string password,
            short age, int income, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
            Region = region;
            Email = email;
            Phone = phone;
            CreditCard = creditCard;
            CreditCardType = creditCardType;
            CreditCardExpiration = creditCardExpiration;
            UserName = userName;
            Password = password;
            Age = age;
            Income = income;
            Gender = gender;
        }
        public Customer(int customerId, string firstName, string lastName, string address1, string address2, string city, string state, int zip, string country,
            short region, string email, string phone, int creditCardType, string creditCard, string creditCardExpiration, string userName, string password,
            short age, int income, string gender)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
            Region = region;
            Email = email;
            Phone = phone;
            CreditCard = creditCard;
            CreditCardType = creditCardType;
            CreditCardExpiration = creditCardExpiration;
            UserName = userName;
            Password = password;
            Age = age;
            Income = income;
            Gender = gender;
        }
        public Customer(DataRow row)
        {
            CustomerId = Convert.ToInt32(row["customerid"]);
            FirstName = Convert.ToString(row["firstname"]);
            LastName = Convert.ToString(row["lastname"]);
            Address1 = Convert.ToString(row["address1"]);
            Address2 = Convert.ToString(row["address2"]);
            City = Convert.ToString(row["city"]);
            State = Convert.ToString(row["state"]);
            Zip = Convert.ToInt32(row["zip"]);
            Country = Convert.ToString(row["country"]);
            Region = Convert.ToInt16(row["region"]);
            Email = Convert.ToString(row["email"]);
            Phone = Convert.ToString(row["phone"]);
            CreditCard = Convert.ToString(row["creditcard"]);
            CreditCardType = Convert.ToInt32(row["creditcardtype"]);
            CreditCardExpiration = Convert.ToString(row["creditcardexpiration"]);
            UserName = Convert.ToString(row["username"]);
            Password = Convert.ToString(row["password"]);
            Age = Convert.ToInt16(row["age"]);
            Income = Convert.ToInt32(row["income"]);
            Gender = Convert.ToString(row["gender"]);
        }
        

    }
}
