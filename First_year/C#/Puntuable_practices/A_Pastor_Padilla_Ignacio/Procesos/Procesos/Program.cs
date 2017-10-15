using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

//Ignacio Pastor Padilla - Grupo A - Ejercicio 2 - Examen Programación
namespace Procesos
{
    class Program
    {
        static void Main(string[] args)
        {
            int tiempo = 0;
            bool correcto;
            string linea;
            Proceso procesoActivo;
            
            //Hago un diccionario para poder manejar los nombres de los procesos.
            Dictionary<string, string> diccionarioProcesos = new Dictionary<string, string>();
            diccionarioProcesos.Add("I/O Lectura", "Operación de lectura de disco (1000ms)");
            diccionarioProcesos.Add("I/O Escritura", "Operación de escritura en disco (2000ms)");
            diccionarioProcesos.Add("ALU", "Operación de la ALU (1500ms)");
            diccionarioProcesos.Add("RAM", "Operación de acceso a memoria (500ms)");
            IDictionaryEnumerator enumerador;
            enumerador = diccionarioProcesos.GetEnumerator();

            do
            {
                try
                {
                    correcto = true;
                    Console.WriteLine("Indica en segundos cuánto debe durar la planificación");
                    tiempo = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("No se ha introducido un dato correcto, se produce un error: {0}", e.Message);
                    correcto = false;
                }
                catch (Exception o)
                {
                    Console.WriteLine("Se ha producido un error: {0}", o.Message);
                    correcto = false;
                }
            }
            while (correcto == false);
            tiempo *= 1000;//Pasamos el tiempo de segundos a milisegundos

            if (File.Exists("procesos.txt"))
            {
                StreamReader ficheroProcesos = File.OpenText("procesos.txt");
                Queue colaProcesos = new Queue();
                do
                {
                    linea = ficheroProcesos.ReadLine();
                    if (linea != null)
                    {
                        switch(linea)
                        {
                            case "I/O Lectura":
                                colaProcesos.Enqueue(new Proceso("I/O Lectura", 1000));

                                break;
                            case "I/O Escritura":
                                colaProcesos.Enqueue(new Proceso("I/O Escritura", 2000));
                                break;
                            case "ALU":
                                colaProcesos.Enqueue(new Proceso("ALU", 1500));
                                break;
                            case "RAM":
                                colaProcesos.Enqueue(new Proceso("RAM", 500));
                                break;
                        }
                    }
                }
                while (linea != null);

                ficheroProcesos.Close();

                Queue colaProcesosRealizados = new Queue();
                do
                {
                    procesoActivo = (Proceso) colaProcesos.Dequeue();
                    switch(procesoActivo.GetNombre())
                    {
                        case "I/O Lectura":
                            Console.WriteLine(diccionarioProcesos[procesoActivo.GetNombre()]);
                            colaProcesosRealizados.Enqueue(procesoActivo);
                            tiempo -= procesoActivo.GetTiempo();
                            Thread.Sleep(1000);
                            break;
                        case "I/O Escritura":
                            Console.WriteLine(diccionarioProcesos[procesoActivo.GetNombre()]);
                            colaProcesosRealizados.Enqueue(procesoActivo);
                            tiempo -= procesoActivo.GetTiempo();
                            Thread.Sleep(2000);
                            break;
                        case "ALU":
                            Console.WriteLine(diccionarioProcesos[procesoActivo.GetNombre()]);
                            colaProcesosRealizados.Enqueue(procesoActivo);
                            tiempo -= procesoActivo.GetTiempo();
                            Thread.Sleep(1500);
                            break;
                        case "RAM":
                            Console.WriteLine(diccionarioProcesos[procesoActivo.GetNombre()]);
                            colaProcesosRealizados.Enqueue(procesoActivo);
                            tiempo -= procesoActivo.GetTiempo();
                            Thread.Sleep(500);
                            break;
                    }
                }
                while (tiempo > 0);

                //Guardamos los procesos realizado en el fichero "procesador.log"
                try
                {
                    StreamWriter ficheroProcesosRealizados = File.AppendText("procesador.log");
                    while (colaProcesosRealizados.Count > 0)
                    {
                        procesoActivo = (Proceso)colaProcesosRealizados.Dequeue();
                        ficheroProcesosRealizados.WriteLine(procesoActivo.Mostrar());
                    }
                    ficheroProcesosRealizados.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Se ha producido un error y no se ha podido guardar en fichero los procesos realizados");
                    Console.WriteLine(e.Message);
                }

                //Sobreescribimos en el ficero "procesos.txt" los procesos pendientes
                try
                {
                    StreamWriter ficherosPendientes = File.CreateText("procesos.txt");
                    while (colaProcesos.Count > 0)
                    {
                        procesoActivo = (Proceso)colaProcesos.Dequeue();
                        ficherosPendientes.WriteLine(procesoActivo.Mostrar());
                    }
                    ficherosPendientes.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Se ha producido un error y no se ha podido guardar los procesos pendientes en fichero");
                    Console.WriteLine(e.Message);                   
                }
            }
            else
                Console.WriteLine("No se ha encontrado el fichero de procesos!");
        }
    }
}
