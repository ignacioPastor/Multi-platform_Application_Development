using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

//Ignacio Pastor Padilla - Ejercicio 2 - Practica Memoria Dinámica - Tema 11 - Programación - DAM Semi Grupo A

//En este programa pediremos un entero al usuario, y le mostraremos ese número expresado en binario

namespace MD_E3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar;//bool con el que controlaremos que se 
            int numeroDecimal = 0, resto;
            Stack miPila = new Stack();//Creamos la pila

            do//Hacemos un bucle para que en caso de error al introducir el número, el programa vuelva a pedírselo
            {
                continuar = true;//En caso de que se haya producido previamente un error, volvemos a poner el bool en true para que pueda salir del bucle
                Console.WriteLine("Introduce un número entero");
                try//Usamos try/catch para controlar entrada de formato correcta y otros errores, como pueda ser exceder el tamaño de un int32
                {
                    numeroDecimal = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ha habido un error: {0}", e.Message);
                    continuar = false;
                }
                catch(Exception o)
                {
                    Console.WriteLine("Ha habido un error: {0}", o.Message);
                    continuar = false;
                }
                if(numeroDecimal < 0)//Con el algoritmo de conversión a binario que tenemos que usar, caso de poner un número negativo
                {                    //se genera un bucle que acabará por lanzar una excepción de sasturación de memoria
                    Console.WriteLine("Debes introducir un número positivo");
                    continuar = false;
                }
            }
            while (continuar == false);
            do//Bucle para llevar a cabo el algoritmo de conversión a binario
            {
                resto = numeroDecimal % 2;//Calculamos el resto de dividir el número entre dos, y lo guardamos en la pila
                miPila.Push(resto);
                numeroDecimal /= 2;//Dividimos el número entre dos y le asignamos ese valor para seguir procediendo con el algoritmo
            }
            while (numeroDecimal != 1);//Cuando el número valga 1, saldremos del bucle
            miPila.Push(1);//Debemos añadir un "1" en último término

            Console.WriteLine("El número expresado en binario sería:");
            while (miPila.Count > 0)//Bucle para vaciar la pila, mientras queden objetos en la pila va "desapilando"
                Console.Write(miPila.Pop());
            Console.WriteLine();
        }
    }
}
