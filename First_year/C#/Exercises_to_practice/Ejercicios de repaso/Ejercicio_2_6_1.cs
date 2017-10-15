// (2.6.1) Crea un programa que pregunte al usuario su edad y su año de
// nacimiento. Si la edad que introduce no es un número válido,
// mostrará un mensaje de aviso. Lo mismo ocurrirá si el año de
// nacimiento no es un número válido.

using System;
public class Ejercicio_2_6_1
{
	public static void Main()
	{
		int edad=0, anyoNacimiento=0;
		try
		{
			Console.WriteLine("Intruduce tu edad");
			edad=Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Introduce tu año de nacimiento");
			anyoNacimiento=Convert.ToInt32(Console.ReadLine());
			
			Console.WriteLine("Naciste en el año {0} y tienes {1} años", anyoNacimiento, edad);
		}
		catch(FormatException)
		{
			Console.WriteLine("Número no válido");
		}

	}
}
