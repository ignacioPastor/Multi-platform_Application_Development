// (2.1.2.1) Crea un programa que pida al usuario un número entero.
// Si es múltiplo de 10, informará al usuario y pedirá un segundo número,
// para decir a continuación si este segundo número también es múltiplo de 10.

using System;
public class Ejercicio_2_1_2_1
{
	public static void Main()
	{
		Console.WriteLine("Introduce un número");
		int n1=Convert.ToInt32(Console.ReadLine());
		if (n1%10==0)
		{
			Console.WriteLine("Has introducido un múltiplo de diez, introduce ahora otro número");
			int n2=Convert.ToInt32(Console.ReadLine());
			if (n2%10==0)
				Console.WriteLine("Este número también es múltiplo de diez");
			else Console.WriteLine("Este segundo número no es múltiplo de diez");
			
		}
		else Console.WriteLine("El número introducido no es múltiplo de diez");	
	}
}
