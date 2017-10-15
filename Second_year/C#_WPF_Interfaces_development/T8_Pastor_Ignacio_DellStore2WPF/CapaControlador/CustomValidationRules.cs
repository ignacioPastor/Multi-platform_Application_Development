using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using System.Globalization;
using System.Data;

namespace CapaControlador
{

    public class StringValidation_Length50 : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value.ToString();
            if (cadena.Length > 50)
                return new ValidationResult(false, "50 caracteres como máximo.");
            else
                return new ValidationResult(true, null);
        }
    }
    public class IntegerValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                int n = Convert.ToInt32(value.ToString());
                return new ValidationResult(true, null);
            }
            catch(FormatException) { return new ValidationResult(false, "Debe ser un número entero."); }
            catch (OverflowException) { return new ValidationResult(false, "Número demasiado grande."); }
        }
    }
    public class IntegerNullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
                return new ValidationResult(true, null);
            try
            {
                int n = Convert.ToInt32(value.ToString());
                return new ValidationResult(true, null);
            }
            catch (FormatException) { return new ValidationResult(false, "Debe ser un número entero."); }
            catch (OverflowException) { return new ValidationResult(false, "Número demasiado grande."); }
        }
    }
    public class DecimalValidation_2Decimals : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                decimal n = Convert.ToDecimal(value.ToString());
                if (Decimal.Round(n, 2) != n)
                    return new ValidationResult(false, "Por favor, introduzca dos decimales como máximo.");
                return new ValidationResult(true, null);
            }
            catch (FormatException) { return new ValidationResult(false, "Debe ser un número."); }
            catch (OverflowException) { return new ValidationResult(false, "El número es demasiado grande."); }
        }
    }
    public class SpecialValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                short n = Convert.ToInt16(value.ToString());
                if (n != 0 && n != 1)
                    return new ValidationResult(false, "Las opciones válidas son \"0\" y \"1\"");
                return new ValidationResult(true, null);
            }
            catch (FormatException) { return new ValidationResult(false, "Debe ser un número entero."); }
            catch (OverflowException) { return new ValidationResult(false, "Número demasiado grande."); }
        }
    }
    public class NotNullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
                return new ValidationResult(false, "El campo no puede quedar vacío");
            return new ValidationResult(true, null);
        }
    }
    public class GenderValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
                
                string genero = value.ToString();
            if (genero == "")
                return new ValidationResult(true, null);
                if (genero != "M" && genero != "F")
                    return new ValidationResult(false, "Las opciones válidas son \"M\" y \"F\"");
                return new ValidationResult(true, null);
        }
    }
    public class ShortValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                int n = Convert.ToInt16(value.ToString());
                return new ValidationResult(true, null);
            }
            catch (FormatException) { return new ValidationResult(false, "Debe ser un número entero."); }
            catch (OverflowException) { return new ValidationResult(false, "Número demasiado grande."); }
        }
    }
    public class ShortNullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
                return new ValidationResult(true, null);
            try
            {
                int n = Convert.ToInt16(value.ToString());
                return new ValidationResult(true, null);
            }
            catch (FormatException) { return new ValidationResult(false, "Debe ser un número entero."); }
            catch (OverflowException) { return new ValidationResult(false, "Número demasiado grande."); }
        }
    }
    public class UQDuplicateCustomers : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            string user = value.ToString();
            DataRow[] n = Controlador.dataSetBD.Tables["customers"].Select("username = '" + user + "'");
            int nLength = n.Length;
            if (n.Length > 0)
                return new ValidationResult(false, "Este usuario ya existe en la BD");
            return new ValidationResult(true, null);
        }
    }
}
