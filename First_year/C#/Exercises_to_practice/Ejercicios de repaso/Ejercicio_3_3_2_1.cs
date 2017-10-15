// (3.3.2.1) Crea un programa que pida al usuario que teclee cuatro letras
// y las muestre en pantalla juntas, pero en orden inverso,
// y entre comillas dobles. Por ejemplo si las letras que se teclean
// son a, l, o, h, escribiría "hola".

using System;
public class Ejercicio_3_3_2_1
{
	public static void Main()
	{
		try
		{
			char letra1, letra2, letra3, letra4;
			
			Console.WriteLine("Introduce una letra");
			letra1=Convert.ToChar(Console.ReadLine());
			Console.WriteLine("Introduce otra letra");
			letra2=Convert.ToChar(Console.ReadLine());
			Console.WriteLine("Introduce otra letra");
			letra3=Convert.ToChar(Console.ReadLine());
			Console.WriteLine("Introduce otra letra");
			letra4=Convert.ToChar(Console.ReadLine());
			
			Console.WriteLine("\"{0}{1}{2}{3}\"", letra4, letra3, letra2, letra1);
		}
		catch(FormatException)
		{
			Console.WriteLine("Debes introducir una letra, y solo una");
		}
	}
}
