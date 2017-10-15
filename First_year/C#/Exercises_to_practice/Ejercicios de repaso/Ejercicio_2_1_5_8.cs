// (2.1.5.8) Crea un programa que pida al usuario dos números enteros y
// diga "Uno de los números es positivo", "Los dos números son positivos"
// o bien "Ninguno de los números es positivo", según corresponda.

using System;
public class Ejercicio_2_1_5_8
{
	public static void Main()
	{
		int n1, n2;
		
		Console.WriteLine("Introduce un número entero");
		n1=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce otro número entero");
		n2=Convert.ToInt32(Console.ReadLine());
		
		if (n1>0&&n2<0||n1<0&&n2>0)
			Console.WriteLine("Uno de los números es positivo");
		else if (n1>0&&n2>0)
			Console.WriteLine("Los dos números son positivos");
		else Console.WriteLine("Ninguno de los números es positivo");
	}
}
