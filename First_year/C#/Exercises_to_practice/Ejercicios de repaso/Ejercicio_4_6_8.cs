// (4.6.8) Mejora la base de datos de ficheros (ejemplo 04_06a) para que se pueda modificar
// un cierto dato a partir de su número (por ejemplo, el dato número 3). En esa modificación,
// se deberá permitir al usuario pulsar Intro sin teclear nada, para indicar que no desea
// modificar un cierto dato, en vez de reemplazarlo por una cadena vacía.

using System;
public class Ejercicio_4_6_8
{
	struct datosPersona
	{
		public string nombre;
		public string direccion;
		public uint telefono;
		public byte edad;
	}
	public static void Main()
	{
		try
		{
			datosPersona[] datos = new datosPersona[50];
			byte opcion, cantidad=0, edad, i, posicion;
			char inicial;
			bool encontrado;
			string comprobador;
			
			do
			{
				Console.WriteLine("Introduce el nombre");
				datos[cantidad].nombre=Console.ReadLine();
				if(datos[cantidad].nombre!="")
				{
					Console.WriteLine("Introduce la dirección");
					datos[cantidad].direccion=Console.ReadLine();
					Console.WriteLine("Introduce el teléfono");
					datos[cantidad].telefono=Convert.ToUInt32(Console.ReadLine());
					Console.WriteLine("Introduce la edad");
					datos[cantidad].edad=Convert.ToByte(Console.ReadLine());
					cantidad++;
				}
			}
			while (datos[cantidad].nombre!=""&&cantidad<50);
			
			do
			{
				encontrado=false;
				Console.WriteLine("Menú");
				Console.WriteLine("1. Mostrar la lista de todos los nombres");
				Console.WriteLine("2. Mostrar las personas de una cierta edad");
				Console.WriteLine("3. Mostrar las personas cuya inicial sea la que el usuario indique");
				Console.WriteLine("4. Modificar un cierto dato");
				Console.WriteLine("0. Salir del programa");
				opcion=Convert.ToByte(Console.ReadLine());
				
				switch (opcion)
				{
					case 1: //Mostrar la lista de todos los nombres
						for (i = 0; i < cantidad; i++)
						{
							Console.WriteLine("{0}. {1}; Dirección: {2}; Tlf: {3}; {4} años", i+1, datos[i].nombre, datos[i].direccion, datos[i].telefono, datos[i].edad);
						}
						break;
						
					case 2: //Mostrar las personas de una cierta edad
						Console.WriteLine("Introduce la edad por la que quieres realizar la búsqueda");
						edad=Convert.ToByte(Console.ReadLine());
						for (i = 0; i < cantidad; i++)
						{
							if(edad==datos[i].edad)
							{
								Console.WriteLine("{0}. {1}; {2} años", i+1, datos[i].nombre, datos[i].edad);
								encontrado=true;
							}
						}
						if(!encontrado)
							Console.WriteLine("No hay resultados para esa búsqueda");
						break;
						
					case 3: //Mostrar las personas cuya inicial sea la que el usuario indique
						Console.WriteLine("Indica qué inicial quieres buscar");
						inicial=Convert.ToChar(Console.ReadLine());
						for (i = 0; i < cantidad; i++)
						{
							if(inicial.ToString().ToUpper()==datos[i].nombre[0].ToString().ToUpper())
							{
								Console.WriteLine("{0}. {1}; Dirección: {2}; Tlf: {3}; {4} años", i+1, datos[i].nombre, datos[i].direccion, datos[i].telefono, datos[i].edad);
								encontrado=true;
							}
						}
						if(!encontrado)
							Console.WriteLine("No hay resultados para esa búsqueda");
						break;
					case 4: // Modificar un cierto dato
						Console.WriteLine("Indica la posición del fichero que quieres modificar");
						posicion=Convert.ToByte(Console.ReadLine());
						posicion--;
						
						Console.WriteLine("Datos almacenados: {0}. Introduce el nuevo nombre (pulsa ENTER para no modificar este campo)", datos[posicion].nombre);
						comprobador=Console.ReadLine();
						if(comprobador!="")
							datos[posicion].nombre=comprobador;
						Console.WriteLine("Datos almacenados: {0}. Introduce la nueva dirección (pulsa ENTER para no modificar este campo)", datos[posicion].direccion);
						comprobador=Console.ReadLine();
						if(comprobador!="")
							datos[posicion].direccion=comprobador;
						Console.WriteLine("Datos almacenados: {0}. Introduce el nuevo teléfono (pulsa ENTER para no modificar este campo)", datos[posicion].telefono);
						comprobador=Console.ReadLine();
						if(comprobador!="")
							datos[posicion].telefono=Convert.ToUInt32(comprobador);
						Console.WriteLine("Datos almacenados: {0}. Introduce la nueva edad (pulsa ENTER para no modificar este campo)", datos[posicion].edad);
						comprobador=Console.ReadLine();
						if(comprobador!="")
							datos[posicion].edad=Convert.ToByte(comprobador);						
						break;
						
					case 0: //Salir del programa
						Console.WriteLine("Fin del programa");
						break;
						
					default:
						Console.WriteLine("Esa no es una opción válida");
						break;
				}
			}
			while (opcion!=0);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}	
}
