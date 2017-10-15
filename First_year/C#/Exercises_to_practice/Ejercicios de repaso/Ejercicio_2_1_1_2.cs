// Crea un programa que pida al usuario dos números enteros y diga cuál es el mayor de ellos.

using System;
public class Ejercicio_2_1_1_2
{
	public static void Main()
	{
		Console.WriteLine("Introduce un número");
		int n1=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce otro número");
		int n2=Convert.ToInt32(Console.ReadLine());
		
		if (n1>n2)
			Console.WriteLine("{0} es mayor que {1}", n1, n2);
		else if (n2>n1)
			Console.WriteLine("{0} es mayor que {1}", n2, n1);
		else Console.WriteLine("Los números son iguales");
	}
}
