using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace CapaNegocio
{
    public class ComboBoxValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
                return new ValidationResult(false, "Debes seleccionar una opción del desplegable.");
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
            catch (FormatException) { return new ValidationResult(false, "Debe ser un número entero."); }
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
    public class NotNullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
                return new ValidationResult(false, "El campo no puede quedar vacío");
            return new ValidationResult(true, null);
        }
    }
    public class StringValidation_Length255 : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value.ToString();
            if (cadena.Length > 255)
                return new ValidationResult(false, "255 caracteres como máximo.");
            else
                return new ValidationResult(true, null);
        }
    }
    public class StringValidation_Length60 : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value.ToString();
            if (cadena.Length > 60)
                return new ValidationResult(false, "60 caracteres como máximo.");
            else
                return new ValidationResult(true, null);
        }
    }
    public class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if(value == null)
                    return new ValidationResult(false, "El campo no puede quedar vacío");
                DateTime d = Convert.ToDateTime(value);
                if(d == null)
                    return new ValidationResult(false, "El campo no puede quedar vacío");
                return new ValidationResult(true, null);
            }
            catch(Exception)
            {
                return new ValidationResult(false, "No es una fecha válida");
            }
        }
    }
}
