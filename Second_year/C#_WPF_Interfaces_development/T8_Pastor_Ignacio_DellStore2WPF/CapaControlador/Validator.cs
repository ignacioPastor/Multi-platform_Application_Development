using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace CapaControlador
{
    /// <summary>
    /// Clase muy interesante que he encontrado por internet. Sirve para forzar la validación de un control y sus hijos
    /// cuando se carga el formulario. Soluciona el problema de que hasta que no se modifica un campo (PropertyChanged / LostFocus)
    /// no se hace la validación, pudiendo enviar el formulario con datos erróneos.
    /// He descubierto ya al final, cuando intentaba que se validase si existía o no el nombre de usuario en customers.
    /// Así que para el global de los formularios he buscado otras soluciones como rellenar los campos con datos válidos de inicio,
    /// solo utilizo esta clase para validar el campo UserName de Alta Clientes.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// This method forces WPF to validate the child controls of the control passed in as a parameter.
        /// </summary>
        /// <param name="parent">Type: DependencyObject. The control which is the descendent root control to validate.</param>
        /// <returns>Type: bool. The validation result</returns>
        public static bool IsValid(DependencyObject parent)
        {
            // Validate all the bindings on the parent
            bool valid = true;
            LocalValueEnumerator localValues = parent.GetLocalValueEnumerator();
            while (localValues.MoveNext())
            {
                LocalValueEntry entry = localValues.Current;
                if (BindingOperations.IsDataBound(parent, entry.Property))
                {
                    Binding binding = BindingOperations.GetBinding(parent, entry.Property);
                    foreach (ValidationRule rule in binding.ValidationRules)
                    {
                        ValidationResult result = rule.Validate(parent.GetValue(entry.Property), null);
                        if (!result.IsValid)
                        {
                            BindingExpression expression = BindingOperations.GetBindingExpression(parent, entry.Property);
                            Validation.MarkInvalid(expression, new ValidationError(rule, expression, result.ErrorContent, null));
                            valid = false;
                        }
                    }
                }
            }

            // Validate all the bindings on the children
            for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (!IsValid(child))
                {
                    valid = false;
                }
            }

            return valid;
        }

    }
}
