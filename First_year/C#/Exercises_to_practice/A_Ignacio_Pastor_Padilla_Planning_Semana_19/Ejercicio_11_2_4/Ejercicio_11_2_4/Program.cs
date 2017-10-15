using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
/*
(11.2.4) La "notación polaca inversa" es una forma de expresar operaciones que consiste en indicar los operandos
antes del correspondiente operador. Por ejemplo, en vez de "3+4" se escribiría "3 4 +". Es una notación que no necesita
paréntesis y que se puede resolver usando una pila: si se recibe un dato numérico, éste se guarda en la pila; si se recibe
un operador, se obtienen los dos operandos que hay en la cima de la pila, se realiza la operación y se apila su resultado.
El proceso termina cuando sólo hay un dato en la pila. Por ejemplo, "3 4 +" se convierte en: apilar 3, apilar 4, sacar dos
datos y sumarlos, guardar 7, terminado. Impleméntalo y comprueba si el resultado de "3 4 6 5 - + * 6 +" es 21.
*/
namespace Ejercicio_11_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string entrada, prueba;
            int numero = 0;
            int n1, n2, resultado;
            int datoFinal;
            bool esNumero;
            bool salir = false;
            int saliendo = 1;
            Stack miPila = new Stack();

            do
            {
                esNumero = true;
                Console.WriteLine("Introduce un operando o símbolo");
                entrada = Console.ReadLine();
                try
                {
                    numero = Convert.ToInt32(entrada);
                }
                catch
                {
                    esNumero = false;
                    Console.WriteLine("Entra en el catch");
                }
                if (esNumero == true)
                {
                    Console.WriteLine("Entra en el if de que numero es true");
                    miPila.Push(numero);
                }
                else
                {
                    Console.WriteLine("Entra en el else de que no es número");
                    if (entrada == "+")
                    {
                        n2 = (int)miPila.Pop();
                        n1 = (int)miPila.Pop();
                        resultado = n1 + n2;
                        miPila.Push(resultado);
                        if (miPila.Count == 1)
                        {
                            

                            
                            if (saliendo == 0)
                            {
                                salir = true;
                                datoFinal = (int)miPila.Pop();
                                Console.WriteLine("datoFinal = " + datoFinal);
                            }
                            else
                            saliendo--;
                        }
                    }
                    else if (entrada == "-")
                    {
                        Console.WriteLine("Entra en el else if de que has metido un -");
                        n2 = (int) miPila.Pop();
                        //prueba = (string)miPila.Pop();
                        Console.WriteLine("Saca n1");

                        n1 = (int) miPila.Pop();
                        Console.WriteLine("Saca n2");
                        resultado = n1 - n2;
                        Console.WriteLine("Hace el resultado");
                        miPila.Push(resultado);
                        Console.WriteLine("Carga el resultado");
                        if (miPila.Count == 1)
                        {
                            

                            if (saliendo == 0)
                            {
                                salir = true;
                                datoFinal = (int)miPila.Pop();
                                Console.WriteLine("datoFinal = " + datoFinal);
                            }
                            else
                            saliendo--;
                        }
                    }
                    else if (entrada == "*")
                    {
                        n2 = (int)miPila.Pop();
                        n1 = (int)miPila.Pop();
                        resultado = n1 * n2;
                        miPila.Push(resultado);
                        if (miPila.Count == 1)
                        {
                            

                            if (saliendo == 0)
                            {
                                salir = true;
                                datoFinal = (int)miPila.Pop();
                                Console.WriteLine("datoFinal = " + datoFinal);
                            }
                            else
                            saliendo--;
                        }
                    }
                    else
                        Console.WriteLine("Valor introducido no reconocido");
                }
            }
            while (salir == false);
        }
    }
}
