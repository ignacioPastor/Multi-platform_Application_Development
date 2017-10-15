using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
///<author>Ignacio Pastor Padilla</author>
/// <summary>
/// Programa para probar el correcto funcionamiento de las clases Telefono, Movil y MiniAgenda
/// </summary>
namespace Pastor_Ignacio_POO
{
    class Program
    {
        //Prueba la correcta validación de Telefono.numero
        public static void PruebaNumero()
        {
            Console.WriteLine("Prueba Telefono.Numero");
            Telefono telf = new Telefono();
            string n1 = "+34-123456789";    // Comprobamos que acepta el formato correcto
            string n2 = "123456789";    // Que rechaza un número sin el prefijo
            string n3 = "651650233-+34";    //Que rechaza el orden incorrecto
            string n4 = "34-651650233+";    //Que el símbolo + debe estar al principio de la cadena

            Console.WriteLine(n1); //Mostramos el número con el que vamos a trabajar para poder seguir bien el proceso por pantalla
            try {
                telf.Numero = n1;   //Asignamos
                Console.WriteLine("Funcionamiento correcto");   //Si se asigna correctamente, se llega a este mensaje que informa todo ok
            } catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); } //Caso de que no se valide, se lanza una
            Console.WriteLine(n2);                                                  // excepción desde Telefono que se captura aquí
            try {
                telf.Numero = n2;
                Console.WriteLine("Funcionamiento correcto");
            }catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); }
            Console.WriteLine(n3);
            try {
                telf.Numero = n3;
                Console.WriteLine("Funcionamiento correcto");
            }catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); }
            Console.WriteLine(n4);
            try {
                telf.Numero = n4;
                Console.WriteLine("Funcionamiento correcto");
            }catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); }
            Console.WriteLine();
        }
        //Prueba de correcta validación de Telefono.Propietario
        public static void PruebaPropietario()
        {
            Telefono telf = new Telefono();
            Console.WriteLine("Prueba Telefono.Propietario");
            string n1 = "nnnnnnnnnnnnn";
            Console.WriteLine("\"nnnnnnnnnnnnn\"; valor.Length = " + n1.Length); //Mostramos el valor sometido a prueba y sus posiciones
            try {
                telf.Propietario = n1; //Asignamos 
                Console.WriteLine("Funcionamiento correcto"); //Si se valida llega aquí y se informa de que ha funcionado correctamente
            } catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); } //No valida, y salta una excepción
            string n2 = "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn"
                + "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn"
                + "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn"
                + "nnnnnnnnnnnnnnnnnnnnnnnnn";
            Console.WriteLine("\"nnnnnnnnnnnnnnnnnnnnnnn...\"; valor.Length = " + n2.Length);
            try {
                telf.Propietario = n2;
            Console.WriteLine("Funcionamiento correcto");
            }catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); }
            Console.WriteLine();
        }
        // Prueba de la correcta validación de Telefono.tarifa
        public static void PruebaTarifa()
        {
            Telefono telf = new Telefono();
            Console.WriteLine("Prueba Telefono.Tarifa");
            string n1 = "nnnnnnnnnnnnn";
            Console.WriteLine("\"nnnnnnnnnnnnn\"; valor.Length = " + n1.Length);//Mostramos el valor sometido a prueba y sus posiciones
            try {
                telf.Tarifa = n1;
            Console.WriteLine("Funcionamiento correcto"); //Si se valida llega aquí y se informa de que ha funcionado correctamente
            } catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); }
                string n2 = "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn"
                + "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn"
                + "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn"
                + "nnnnnnnnnnnnnnnnnnnnnnnnn";
            Console.WriteLine("\"nnnnnnnnnnnnnnnnnnnnnnn...\"; valor.Length = " + n2.Length); //No valida, y salta una excepción
            try {
                telf.Tarifa = n2;
                Console.WriteLine("Funcionamiento correcto");
            } catch(Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); }
            Console.WriteLine();
        }
        // Prueba del correcto funcionamiento de la sobrecarga del método ToString
        public static void PruebaToString()
        {
            Console.WriteLine("Prueba Telefono.ToString");
            try {
            Telefono telf = new Telefono(23, "+34-651650233", "Ignacio Pastor Padilla", Telefono.Tipo.Movil, "VodafoneOne");
            Console.WriteLine(telf.ToString());
            }catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); }
            Console.WriteLine();
        }
        // Prueba del correcto funcionamiento de los métodos de la clase Movil
        public static void PruebaMovil()
        {
            Console.WriteLine();
            Console.WriteLine("Prueba Movil");
            Console.WriteLine();
            try
            {   //Creamos 5 móviles
                Movil m1 = new Movil(1234, "+34-654654654", "Zubiri", Telefono.Tipo.Movil, "Orange.Ardilla", 741852896);
                Movil m2 = new Movil(1235, "+34-654654657", "Marcos", Telefono.Tipo.Movil, "MovistarPlus", 21541);
                Movil m3 = new Movil(1239, "+34-654654658", "Eugenia", Telefono.Tipo.Movil, "PepePhone5G", 465465465);
                Movil m4 = new Movil(1238, "+34-654654659", "Aaron", Telefono.Tipo.Movil, "Vodafone.Red", 14278);
                Movil m5 = new Movil(1237, "+34-654654656", "Rosa", Telefono.Tipo.Movil, "Airtel.Prepago", 895);

                List<Movil> moviles = new List<Movil>(); // Los añadimos a una lista de móviles
                moviles.Add(m1);
                moviles.Add(m2);
                moviles.Add(m3);
                moviles.Add(m4);
                moviles.Add(m5);

                //Comprobamos que la implementación IComparable funciona correctamente
                Console.WriteLine("Prueba implementación IComparable");
                Console.WriteLine("Mostramos antes de ordenar"); //Mostramos los datos desordenados
                for (int i = 0; i < moviles.Count; i++)
                    Console.WriteLine(moviles[i].ToString());
                Console.WriteLine();
                Console.WriteLine("Ordenamos y mostramos"); // Mostramos los datos una vez ordenados para mostrar que ha funcionado bien
                moviles.Sort();
                for (int i = 0; i < moviles.Count; i++)
                    Console.WriteLine(moviles[i].ToString());
                Console.WriteLine();
            }
            catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); }
        }
        //Main que lanza las distintas pruebas
        static void Main(string[] args)
        {
            PruebaNumero();
            PruebaPropietario();
            PruebaTarifa();
            PruebaToString();
            PruebaMovil();
            PruebaMiniAgenda();

        }
        //Prueba de la clase MiniAgenda
        public static void PruebaMiniAgenda()
        {
            Console.WriteLine();
            Console.WriteLine("Pueba MiniAgenda");
            Console.WriteLine();
            try
            {
                //Creamos 5 móviles
                MiniAgenda agenda = new MiniAgenda();
                Movil m1 = new Movil(1234, "+34-654654654", "Zubiri", Telefono.Tipo.Movil, "Orange.Ardilla", 741852896); //Constructor args
                Movil m2 = new Movil(1235, "+34-654654657", "Marcos", Telefono.Tipo.Movil, "MovistarPlus", 21541);
                Movil m3 = new Movil(1239, "+34-654654658", "Eugenia", Telefono.Tipo.Movil, "PepePhone5G", 465465465);
                Console.WriteLine("Añadimos 5 nuevos contactos con los métodos de añadir objeto, y pasando argumentos");
                agenda.NuevoMovil(m1);
                agenda.NuevoMovil(m2);
                agenda.NuevoMovil(m3);
                agenda.NuevoMovil(1238, "+34-654654659", "Aaron", Telefono.Tipo.Movil, "Vodafone.Red", 14278);//Pasando args para que se
                agenda.NuevoMovil(1237, "+34-654654656", "Rosa", Telefono.Tipo.Movil, "Airtel.Prepago", 895);//cree el movil en MiniAgenda

                //Comprobamos que podemos recuperar correctamente los contactos
                Console.WriteLine("Mostramos la lista de contactos con el método \"MostrarContactos\"");
                ImprimirListaMovil(agenda.MostrarContactos());
                Console.WriteLine();

                //Comprobamos la búsqueda por propietario
                Console.WriteLine("Prueba buscar por propietario");
                Console.WriteLine("Buscar por propietario: \"arco\"");
                ImprimirListaMovil(agenda.BuscarPropietario("arco")); //Búsqueda con string parcial
                Console.WriteLine("Buscar por propietario: \"rosa\"");
                ImprimirListaMovil(agenda.BuscarPropietario("rosa")); //Busqueda ignorando mayúsculas y minúsculas
                Console.WriteLine("Buscar por propietario: \"Ignacio\"");
                ImprimirListaMovil(agenda.BuscarPropietario("Ignacio")); //Busqueda de un elemento que no está en la agenda
                Console.WriteLine();

                //Comprobamos la búsqueda por número
                Console.WriteLine("Prueba buscar por número");
                Console.WriteLine("Buscar por número: \"654654654\""); 
                ImprimirListaMovil(agenda.BuscarNumero("654654654"));   //Número parcial
                Console.WriteLine("Buscar por número: \"+34-654654659\"");
                ImprimirListaMovil(agenda.BuscarNumero("+34-654654659"));   //Número completo
                Console.WriteLine("Buscar por número: \"654789321\"");
                ImprimirListaMovil(agenda.BuscarNumero("654789321"));   //Buscando un número que no está almacenado
                Console.WriteLine();
            }
            catch (Exception e) { Console.WriteLine("Ha habido un error: " + e.Message); }
        }
        //Muestra por pantalla los distintos contactos almacenados en la lista que se le pasa
        public static void ImprimirListaMovil(List<Movil> l)
        {
            if(l.Count == 0)
                Console.WriteLine("No hay datos que mostrar");
            else
                for (int i = 0; i < l.Count; i++)
                    Console.WriteLine(l[i].ToString());
        }
    }
}
