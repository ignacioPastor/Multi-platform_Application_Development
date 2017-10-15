// (4.1.4.5) Crea un programa que prepare espacio para un máximo de 10 nombres.
// Deberá mostrar al usuario un menú que le permita realizar las siguientes operaciones:

// 1. Añadir un dato al final de los ya existentes.
// 2. Insertar un dato en una cierta posición (como ya se ha comentado,
//           los que queden detrás deberán desplazarse "hacia el final"
//           para dejarle hueco; por ejemplo, si el array contiene "hola",
//           "adiós" y se pide insertar "bien" en la segunda posición, el
//           array pasará a contener "hola", "bien", "adiós".
// 3. Borrar el dato que hay en una cierta posición (como se ha visto,
//           lo que estaban detrás deberán desplazarse "hacia el principio"
//           para que no haya huecos; por ejemplo, si el array contiene "hola", "bien", "adiós"
//           y se pide borrar el dato de la segunda posición, el array pasará a contener "hola", "adiós"
// 4. Mostrar los datos que contiene el array.
// 5. Salir del programa.

using System;
public class Ejercicio_4_1_4_5
{
	public static void Main()
	{
		try
		{
			string[] nombres = new string[10];
			byte opcion, cantidad=0, posicion;
			
			do
			{
				Console.WriteLine("Menu. ¿Qué quieres hacer?");
				Console.WriteLine("1. Añadir un dato al final de los ya existentes");
				Console.WriteLine("2. Insertar un dato en una cierta posición");
				Console.WriteLine("3. Borrar el dato que hay en cierta posición");
				Console.WriteLine("4. Mostrar los datos que contiene el array");
				Console.WriteLine("5. Salir del programa");
				opcion=Convert.ToByte(Console.ReadLine());
				
				switch(opcion)
				{
					case 1: //Añadir un dato al final de los ya existentes
						Console.WriteLine("Introduce el nombre para almacenarlo en la primera posición libre, la posición {0}", cantidad+1);
						nombres[cantidad]=Console.ReadLine();
						cantidad++;
						break;
					
					case 2: //Insertar un dato en una cierta posición
						Console.WriteLine("Introduce la posición en la que quieres introducir el nuevo dato");
						posicion=Convert.ToByte(Console.ReadLine());
						for (byte i = cantidad; i >= posicion-1 ; i--)
						{
							nombres[i+1]=nombres[i];
						}
						Console.WriteLine("Introduce el nuevo dato a almacenar");
						nombres[posicion-1]=Console.ReadLine();
						cantidad++;
						break;
					
					case 3: //Borrar el dato que hay en una cierta posición
						Console.WriteLine("Introduce la posición en la que está el dato que quieres borrar");
						posicion=Convert.ToByte(Console.ReadLine());
						for (byte i = --posicion ; i < cantidad ; i++)
						{
							nombres[i]=nombres[i+1];
						}
						cantidad--;
						break;
						
					case 4: //Mostrar los datos que contiene el array.
						for (byte i = 0; i < cantidad; i++)
						{
							Console.WriteLine("{0}. {1}", i+1, nombres[i]);
						}
						break;
					
					case 5: // Salir del programa.
						break;
						
					default:
						Console.WriteLine("Debes elegir una opción entre las indicadas, entre 1 y 5");
						break;
				}
			}
			while(opcion!=5);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
