using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

// Ignacio Pastor Padilla Grupo A- Ejercicio 1 - Practica Tema 11 - Programación - DAM Semipresencial

//En este programa pediremos una serie de datos sobre alumnos, los guardaremos en un diccionario genérico
// y finalmente mostraremos el nombre de los alumnos junto a su nota media.

    //En la parte del programa (en el Main) pediremos al usuario que introduzca el dni, nombre y notas del alumno,
    //lo guardaremos en un diccionario y después mostraremos nombre del alumno junto a su nota media

namespace MD_E1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dni;
            Dictionary<string, Alumno> miDiccionario = new Dictionary<string, Alumno>(); //Creamos el diccionario de string y Alumnos

            do//Bucle para ir introduciendo alumnos hasta que el usuario teclee "Fin"
            {
                Console.WriteLine("Introduce el DNI del alumno. Teclea \"Fin\" para finalizar el cargado de datos");
                dni = Console.ReadLine();
                if (dni != "Fin" && dni != "")//Si no teclea "Fin" o cadena vacía, procedemos a almacenar el dni en el diccionario
                {
                    miDiccionario.Add(dni, new Alumno());//Creamos el objeto Alumno que vamos a utilizar a continuación
                    miDiccionario[dni].SetDni(dni);//Vinculamos el dni del alumno (el Key) con la propiedad dni del alumno

                    do//Controlamos que no quede el nombre con un valor vacío, y es así, lo volvemos a pedir
                    {
                        Console.WriteLine("Introduce el nombre del alumno");
                        miDiccionario[dni].SetNombre(Console.ReadLine());//Guardamos el nombre del alumno
                        if (miDiccionario[dni].GetNombre() == "")
                            Console.WriteLine("No puedes dejar vacío este campo");
                    }
                    while (miDiccionario[dni].GetNombre() == "");
                    do//En caso de que se introduzcan datos que no sean números, controlaremos el error en la clase alumnos
                    {//y mediante un bool informaremos de que no se han almacenado las notas. Volveremos a pedirlas
                        Console.WriteLine("Introduce las notas del alumno, separadas por espacios");
                        Console.WriteLine("Para partes decimales usa \",\" y no \".\"");
                        miDiccionario[dni].SetMiLista(Console.ReadLine());//Pedimos y guardamos un string de notas separadas por espacios
                    }
                    while (miDiccionario[dni].GetTutoBenne() == false);
                }
                else if (dni == "")//Controlamos que el campo dni no quede vacío, si es así, lo volvemos a pedir
                    Console.WriteLine("No puedes dejar vacío este campo");
            }
            while (dni != "Fin");//Cuando el usuario introduzca "Fin" como dni, saldremos del bucle
            IDictionaryEnumerator miEnumerador = miDiccionario.GetEnumerator();//Creamos un enumerador para recorrer el diccionario

            Console.WriteLine("Proceso completado...");
            Console.WriteLine("Estadísticas de todos los alumnos introducidos:");
            while (miEnumerador.MoveNext() == true)//Con el método MoveNext del enumerador recorremos el diccionario y vamos mostrando el nombre y nota media del alumno
                Console.WriteLine("{0}: {1}", ((Alumno)miEnumerador.Value).GetNombre(), ((Alumno)miEnumerador.Value).GetNotaMedia());
        }
    }
}
