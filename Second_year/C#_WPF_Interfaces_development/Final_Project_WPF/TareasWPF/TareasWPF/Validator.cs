using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace CapaVista
{
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
                //VisualTreeHelper necesita tener visibilidad a la capa vista, si lo pongo en CapaNegocio no puedo
                //(porque no puedo agregar referencia a la capa vista xq se hace circularidad). Así que en la capa vista
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
