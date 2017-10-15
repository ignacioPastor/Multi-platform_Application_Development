// (2.1.9.3) Crea un programa que lea una letra tecleada por el usuario
// y diga si se trata de una vocal, una cifra numérica o una consonante,
// usando "switch".

using System;
public class Ejercicio_2_1_9_3
{
	public static void Main()
	{
		char letra;
		
		Console.WriteLine("Introduce una letra o cifra numérica de un dígito");
		letra=Convert.ToChar(Console.ReadLine());
		
		switch (letra)
		{
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9': Console.WriteLine("Has introducido una cifra numérica");
				break;
			case 'a':
			case 'e':
			case 'i':
			case 'o':
			case 'u': Console.WriteLine("Has introducido una vocal");
				break;
			default: Console.WriteLine("Has introducido una consonante");
				break;
		}
	}
}
