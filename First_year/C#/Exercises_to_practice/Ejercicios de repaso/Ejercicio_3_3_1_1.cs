// (3.3.1.1) Crea un programa que pida una letra al usuario
// y diga si se trata de una vocal.

using System;
public class Ejercicio_3_3_1_1
{
	public static void Main()
	{
		char letra;
		try
		{
			Console.WriteLine("Introduce una letra");
			letra=Convert.ToChar(Console.ReadLine());
			if(letra=='a'||letra=='e'||letra=='i'||letra=='o'||letra=='u')
				Console.WriteLine("{0} es una vocal", letra);
			else Console.WriteLine("{0} no es una vocal", letra);
		}
		catch (FormatException)
		{
			Console.WriteLine("Debes introducir una letra");
		}
	}
}
