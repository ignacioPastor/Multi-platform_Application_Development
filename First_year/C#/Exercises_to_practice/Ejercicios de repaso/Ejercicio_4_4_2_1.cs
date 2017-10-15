// (4.4.2.1) Crea un programa que pregunte al usuario su nombre y le responda cuál es su inicial.

using System;
public class Ejercicio_4_4_2_1
{
	public static void Main()
	{
		string nombre;
		
		Console.WriteLine("¿Cuál es (tu) nombre?");
		nombre=Console.ReadLine();
		
		Console.WriteLine("Tu nombre es {0} y tu inicial es {1}", nombre, nombre[0]);
	}
}
