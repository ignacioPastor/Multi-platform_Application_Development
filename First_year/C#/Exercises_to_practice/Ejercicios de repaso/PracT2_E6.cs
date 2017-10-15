// Practica Evaluable Tema2
// Ejercicio 6

using System;
public class PracT2_E6
{
	public static void Main()
	{
		char codigo;
		
		Console.WriteLine("Introduzca su código de usuario");
		codigo=Convert.ToChar(Console.ReadLine());
		
		switch (codigo)
		{
			case 'J':
			case 'j':
				Console.WriteLine("Hola Juan");
				break;
			case 'M':
			case 'm':
				Console.WriteLine("Hola María");
				break;
			case 'A':
			case 'a':
				Console.WriteLine("Hola Antonio");
				break;
			case 'V':
			case 'v':
				Console.WriteLine("Hola Verónica");
				break;
			case 'S':
			case 's':
				Console.WriteLine("Hola Susana");
				break;
		}
	}
}
