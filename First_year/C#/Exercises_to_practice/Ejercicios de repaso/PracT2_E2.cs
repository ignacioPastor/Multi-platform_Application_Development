// Practica Evaluable Tema2
// Ejercicio 2

using System;
public class PracT2_E2
{
	public static void Main()
	{
		int talla1, talla2, talla3, talla4;
		
		Console.WriteLine("Introduce la talla de zapato de la primera persona");
		talla1=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce la talla de zapato de la segunda persona");
		talla2=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce la talla de zapato de la tercera persona");
		talla3=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce la talla de zapato de la cuarta persona");
		talla4=Convert.ToInt32(Console.ReadLine());
		
		if(talla1>40&&talla2>40&&talla3>40&&talla4>40)
			Console.WriteLine("Todos calzan más de un 40");
		else if(talla1<=40&&talla2<=40&&talla3<=40&&talla4<=40)
			Console.WriteLine("Ninguno calza más de un 40");
		else Console.WriteLine("Hay algunos que calzan más de un 40 y otros que no");
	}
}
