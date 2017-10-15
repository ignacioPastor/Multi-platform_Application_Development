// (4.6.3) Un programa que sea capaz de almacenar los datos de 50 personas:
// nombre, dirección, teléfono, edad (usando una tabla de structs)
// Deberá ir pidiendo los datos uno por uno, hasta que un nombre se introduzca vacío
// (se pulse Intro sin teclear nada). Entonces deberá aparecer un menú que permita:
// 1. Mostrar la lista de todos los nombres.
// 2. Mostrar las personas de una cierta edad.
// 3. Mostrar las personas cuya inicial sea la que el usuario indique.
// 4. Salir del programa

using System;
public class Ejercicio_4_6_3
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
			byte opcion, cantidad=0, edad, i;
			char inicial;
			bool encontrado;
			
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
